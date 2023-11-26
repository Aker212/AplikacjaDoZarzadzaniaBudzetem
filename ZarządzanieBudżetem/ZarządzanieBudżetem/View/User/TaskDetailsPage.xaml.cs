using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Logika interakcji dla klasy TaskDetailsPage.xaml
    /// </summary>
    public partial class TaskDetailsPage : Page
    {
        public List<Faktury> Invoices { get; set; }
        public List<Wnioski> Requests { get; set; }
        private DataStore dataStore;
        public TaskDetailsPage()
        {
            
            InitializeComponent();
            dataStore = new DataStore();         
            Invoices = dataStore.GetInvoices(); 
            Requests = dataStore.GetRequests();
            DataContext = this;
        }


        private void InvoiceListView_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {


            var scrollViewer = VisualTreeHelper.GetChild(InvoiceListView, 0) as ScrollViewer;

            if (scrollViewer != null)
            {

                if (e.Delta > 0)
                {
                    scrollViewer.LineUp();
                }
                else
                {
                    scrollViewer.LineDown();
                }

                e.Handled = true;
            }
        }
        
        private void WnioskiListView_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {


            var scrollViewer = VisualTreeHelper.GetChild(InvoiceListView, 0) as ScrollViewer;

            if (scrollViewer != null)
            {

                if (e.Delta > 0)
                {
                    scrollViewer.LineUp();
                }
                else
                {
                    scrollViewer.LineDown();
                }

                e.Handled = true;
            }
        }

        private void AddInv_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddInvPage());

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TaskPage());
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationDbContext()) 
            {
                // Pętla po wszystkich fakturacg w DataGrid
                foreach (var inv in Invoices)
                {
                    // Tutaj możesz dodać logikę zapisywania zmian w bazie danych dla każdej faktury
                    var existingInv = context.Invoices.Find(inv.IdFaktury);

                    if (existingInv != null)
                    {
                        // Aktualizuj pola zadania na podstawie zmian wprowadzonych w interfejsie użytkownika
                        existingInv.Nr_faktury = inv.Nr_faktury;
                        existingInv.Kwota = inv.Kwota;
                        existingInv.Opis = inv.Opis;
                        existingInv.Data_Faktury = inv.Data_Faktury;
                        existingInv.Jednostka = inv.Jednostka;
                        existingInv.Budynek = inv.Budynek;
                        existingInv.Pokój = inv.Pokój;
                    }
                }

                // Zapisz zmiany w bazie danych
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("EXEC SumInvoiceAmountForTask @IdZadania", new SqlParameter("@IdZadania", App.CurrentTaskId));
                MessageBox.Show("Zapisano zmiany");
                CollectionViewSource.GetDefaultView(Invoices).Refresh();

            }

        }
    }
}
