using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
    /// Logika interakcji dla klasy UserAddProjectPage.xaml
    /// </summary>
    public partial class UserAddProjectPage : Page
    {
        public UserAddProjectPage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;

            DateTime data = DateTime.Now;
            string dataString = data.ToString("yyyy-MM-dd");

            using (var context = new ApplicationDbContext())
            {
                var newProject = new Projekty
                {
                    Nazwa = name,
                    Data_Utworzenia = DateTime.ParseExact(dataString, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    IdUżytkownika = App.CurrentUserId

                };

                context.Projects.Add(newProject);
                context.SaveChanges();
                MessageBox.Show("Projekt został pomyślnie utworzony.");
                NavigationService.Navigate(new UserProjectPage());

            }
        }
    }
}
