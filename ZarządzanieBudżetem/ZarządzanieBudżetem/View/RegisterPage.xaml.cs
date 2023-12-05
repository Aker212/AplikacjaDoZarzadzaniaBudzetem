using System.Windows;
using System.Windows.Controls;
using ZarządzanieBudżetem.Models;

namespace ZarządzanieBudżetem.View
{
    /// <summary>
    /// Logika interakcji dla klasy RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }

        private void Register_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Sprawdź, czy wszystkie pola są uzupełnione
            if (string.IsNullOrEmpty(EmailTextBox.Text) || string.IsNullOrEmpty(PasswordBox.Password) ||
                string.IsNullOrEmpty(PasswordBoxRepat.Password))
            {
                MessageBox.Show("Wypełnij wszystkie pola przed aktualizacją.");
                return;
            }

            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;
            string passwordRepaty = PasswordBoxRepat.Password;
            string role = "User";
            string salt = PasswordHasher.GenerateSalt();
            string hashedPassword = PasswordHasher.HashPassword(password, salt);



            DataStore userDataStorage = new DataStore();
            bool isEmailExists = userDataStorage.IsEmailAlreadyExists(email);

            if (isEmailExists)
            {
                MessageBox.Show("Użytkownik z takim emailem już istnieje.");
            }

            else
            {

                if (password == passwordRepaty)
                {


                    using (var context = new ApplicationDbContext())
                    {
                        var newUser = new Użytkownicy
                        {
                            Email = email,
                            Hasło = hashedPassword,
                            Sól = salt,
                            Rola = role

                        };

                        context.Users.Add(newUser);
                        context.SaveChanges();
                        MessageBox.Show("Użytkownik został pomyślnie utworzony.");
                        NavigationService.Navigate(new LoginPage());

                    }
                }
                else
                {
                    MessageBox.Show("Hasła się różnią.");
                }
            }
        }
    }
}
