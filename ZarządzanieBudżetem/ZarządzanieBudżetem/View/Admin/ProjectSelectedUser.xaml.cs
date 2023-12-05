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
    }
}
