using System.Windows.Controls;

namespace ZarządzanieBudżetem.View
{
    /// <summary>
    /// Logika interakcji dla klasy WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage());
        }

        private void Login_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }
    }
}
