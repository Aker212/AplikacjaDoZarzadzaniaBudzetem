using System.Windows;
using ZarządzanieBudżetem.View;

namespace ZarządzanieBudżetem
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContent.Navigate(new LoginPage());
        }

       
    }
}
