using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using ZarządzanieBudżetem.Models;

namespace ZarządzanieBudżetem.View.Admin
{
    /// <summary>
    /// Logika interakcji dla klasy AdministratorPage.xaml
    /// </summary>
    public partial class AdministratorPage : Page
    {
        public List<Użytkownicy> Users { get; set; }

        private DataStore dataStore;
        public AdministratorPage()
        {
            InitializeComponent();
            dataStore = new DataStore();

            Users = dataStore.GetUsers();
            DataContext = this;
        }



        private void Save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            using (var context = new ApplicationDbContext()) // Zastąp ApplicationDbContext odpowiednim kontekstem bazodanowym
            {
                // Pętla po wszystkich zadaniach w DataGrid
                foreach (var user in Users)
                {
                    // Tutaj możesz dodać logikę zapisywania zmian w bazie danych dla każdego zadania
                    var existingUser = context.Users.Find(user.IdUżytkownika);

                    if (existingUser != null)
                    {

                        existingUser.Email = user.Email;
                        existingUser.Rola = user.Rola;
                    }
                }

                // Zapisz zmiany w bazie danych
                context.SaveChanges();
                MessageBox.Show("Zapisano zmiany");
                CollectionViewSource.GetDefaultView(Users).Refresh();
            }
        }

        private void ChcekProject_Click(object sender, RoutedEventArgs e)
        {
            if (userViewList.SelectedItem != null)
            {
                // Sprawdź, czy wybrany element ma właściwość IdUżytkownika
                if (userViewList.SelectedItem is Użytkownicy selectedItem)
                {
                    App.SellectedUserId = selectedItem.IdUżytkownika;

                    NavigationService.Navigate(new ProjectSelectedUser());

                }


            }
            else { MessageBox.Show("najpierw wybierz pole z listy"); }
        }
    }
}
