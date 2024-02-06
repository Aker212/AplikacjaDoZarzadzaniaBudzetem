using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using ZarządzanieBudżetem.Models;

namespace ZarządzanieBudżetem.View.Admin
{
    /// <summary>
    /// Logika interakcji dla klasy ProjectSelectedUser.xaml
    /// </summary>
    public partial class ProjectSelectedUser : Page
    {

        public List<Projekty> Projects { get; set; }
        private DataStore dataStore;

        public ProjectSelectedUser()
        {
            InitializeComponent();
            dataStore = new DataStore();
            Projects = dataStore.GetSelectedUserProjects();
            DataContext = this;
        }


        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ProjectList.SelectedItem != null)
            {
                //Projekty selectedProject = (Projekty)ProjectList.SelectedItem;


                // App.CurrentProjectId = selectedProject.IdProjektu;
                // NavigationService.Navigate(new TaskPage());




            }
        }

        private void LogoutButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            App.CurrentUserId = 0;
            App.CurrentProjectId = 0;
            App.CurrentTaskId = 0;
            App.SellectedUserId = 0;
            App.InvoiceId = 0;
            App.LpColumn = 0;
            App.NazwaKosztuColumn = 0;
            App.WartoscOgolnaColumn = 0;
            App.WydatkiKwalifikowaneColumn = 0;
            App.DofinansowanieColumn = 0;
            App.KategoriaKosztowColumn = 0;
            NavigationService.Navigate(new LoginPage());
        }

        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdministratorPage());
        }
    }
}
