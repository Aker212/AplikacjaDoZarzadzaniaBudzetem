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

  
    }
}
