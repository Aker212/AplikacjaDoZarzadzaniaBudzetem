using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ZarządzanieBudżetem.Models;

namespace ZarządzanieBudżetem.View.User
{
    /// <summary>
    /// Logika interakcji dla klasy UserAddProjectPage.xaml
    /// </summary>
    public partial class UserAddProjectPage : Page
    {
        public UserAddProjectPage()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {



            DateTime data = DateTime.Now;
            string dataString = data.ToString("yyyy-MM-dd");

            using (var context = new ApplicationDbContext())
            {
                // Sprawdź, czy wszystkie pola są uzupełnione
                if (string.IsNullOrEmpty(NameTextBox.Text) || string.IsNullOrEmpty(LpColumnTextBox.Text) ||
                    string.IsNullOrEmpty(NazwaKosztuColumnTextBox.Text) || string.IsNullOrEmpty(WartoscOgolnaColumnTextBox.Text) ||
                    string.IsNullOrEmpty(WydatkiKwalifikowaneColumnTextBox.Text) || string.IsNullOrEmpty(DofinansowanieColumnTextBox.Text) ||
                    string.IsNullOrEmpty(KategoriaKosztowColumnTextBox.Text))
                {
                    MessageBox.Show("Wypełnij wszystkie pola przed aktualizacją.");
                    return;
                }

                var newProject = new Projekty
                {
                    Nazwa = NameTextBox.Text,
                    LpColumn = int.Parse(LpColumnTextBox.Text),
                    NazwaKosztuColumn = int.Parse(NazwaKosztuColumnTextBox.Text),
                    WartoscOgolnaColumn = int.Parse(WartoscOgolnaColumnTextBox.Text),
                    WydatkiKwalifikowaneColumn = int.Parse(WydatkiKwalifikowaneColumnTextBox.Text),
                    DofinansowanieColumn = int.Parse(DofinansowanieColumnTextBox.Text),
                    KategoriaKosztowColumn = int.Parse(KategoriaKosztowColumnTextBox.Text),
                    Data_Utworzenia = DateTime.ParseExact(dataString, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Ostatnie_Użycie = DateTime.Now,
                    IdUżytkownika = App.CurrentUserId

                };

                context.Projects.Add(newProject);
                context.SaveChanges();
                MessageBox.Show("Projekt został pomyślnie utworzony.");
                NavigationService.Navigate(new UserProjectPage());

            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserProjectPage());
        }
    }
}
