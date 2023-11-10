using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using ZarządzanieBudżetem.Models;

namespace ZarządzanieBudżetem.View.User
{
    /// <summary>
    /// Logika interakcji dla klasy UserProjectPage.xaml
    /// </summary>
    public partial class UserProjectPage : Page
    {
        public List<Projekty> Projects { get; set; }
        private DataStore dataStore;

        public UserProjectPage()
        {

            InitializeComponent();
            dataStore = new DataStore();
            Projects = dataStore.GetProjects();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserAddProjectPage());
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ProjectList.SelectedItem != null)
            {
                Projekty selectedProject = (Projekty)ProjectList.SelectedItem;


                App.CurrentProjectId = selectedProject.IdProjektu;
                NavigationService.Navigate(new TaskPage());




            }
        }
    }
}
