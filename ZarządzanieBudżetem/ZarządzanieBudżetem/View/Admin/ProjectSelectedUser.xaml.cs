using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZarządzanieBudżetem.Models;
using ZarządzanieBudżetem.View.User;

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
