using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
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

                // Pętla po wszystkich fakturacg w DataGrid
                foreach (var req in Requests)
                {

                    var existingReq = context.Requests.Find(req.IdWniosku);

                    if (existingReq != null)
                    {
                        // Aktualizuj pola zadania na podstawie zmian wprowadzonych w interfejsie użytkownika
                        existingReq.NrKsięgowy = req.NrKsięgowy;
                        existingReq.Kwota_Dofinansowania = req.Kwota_Dofinansowania;
                        existingReq.Data_Wniosku = req.Data_Wniosku;
                    }
                }

                // Zapisz zmiany w bazie danych
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("EXEC SumaWydatkowDlaZadania @IdZadania", new SqlParameter("@IdZadania", App.CurrentTaskId));
                context.Database.ExecuteSqlCommand("EXEC PozostaleSrodkiDlaZadnia @IdZadania", new SqlParameter("@IdZadania", App.CurrentTaskId));
                MessageBox.Show("Zapisano zmiany");
                CollectionViewSource.GetDefaultView(Invoices).Refresh();
                CollectionViewSource.GetDefaultView(Requests).Refresh();
            }

        }

        private void ReqInv_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddReqPage());
        }

        private void DeleteInv_Click(object sender, RoutedEventArgs e)
        {
            if (InvoiceListView.SelectedItem != null)
            {
                // Pobierz wybraną fakturę
                Faktury selectedInvoice = (Faktury)InvoiceListView.SelectedItem;

                MessageBoxResult result = MessageBox.Show($"Czy na pewno chcesz usunąć fakturę o numerze {selectedInvoice.Nr_faktury}?", "Potwierdzenie usunięcia", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Usuń z bazy danych
                    using (var context = new ApplicationDbContext())
                    {
                        var invoiceToDelete = context.Invoices
                            .Where(f => f.IdFaktury == selectedInvoice.IdFaktury)
                            .FirstOrDefault();

                        if (invoiceToDelete != null)
                        {
                            // Usuń fakturę
                            context.Invoices.Remove(invoiceToDelete);

                            // Zapisz zmiany
                            context.SaveChanges();

                            // Odśwież listę faktur
                            Invoices = dataStore.GetInvoices(); 
                            InvoiceListView.ItemsSource = Invoices;
                        }
                        context.Database.ExecuteSqlCommand("EXEC SumaWydatkowDlaZadania @IdZadania", new SqlParameter("@IdZadania", App.CurrentTaskId));
                        context.Database.ExecuteSqlCommand("EXEC PozostaleSrodkiDlaZadnia @IdZadania", new SqlParameter("@IdZadania", App.CurrentTaskId));
                    }
                }
            }
            else
            {
                MessageBox.Show("Najpierw wybierz fakturę z listy.");
            }
        }

        private void DeleteReq_Click(object sender, RoutedEventArgs e)
        {
            // Sprawdź, czy coś jest zaznaczone w liście wniosków
            if (WnioskiListView.SelectedItem != null)
            {
                // Pobierz wybrany wniosek
                Wnioski selectedRequest = (Wnioski)WnioskiListView.SelectedItem;

                MessageBoxResult result = MessageBox.Show($"Czy na pewno chcesz usunąć wniosek o numerze księgowym {selectedRequest.NrKsięgowy}?", "Potwierdzenie usunięcia", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Usuń z bazy danych
                    using (var context = new ApplicationDbContext())
                    {
                        var requestToDelete = context.Requests
                            .Where(w => w.IdWniosku == selectedRequest.IdWniosku)
                            .FirstOrDefault();

                        if (requestToDelete != null)
                        {
                            // Usuń wniosek
                            context.Requests.Remove(requestToDelete);

                            // Zapisz zmiany
                            context.SaveChanges();

                            // Odśwież listę wniosków
                            Requests = dataStore.GetRequests(); 
                            WnioskiListView.ItemsSource = Requests;
                        }
                        context.Database.ExecuteSqlCommand("EXEC SumaWydatkowDlaZadania @IdZadania", new SqlParameter("@IdZadania", App.CurrentTaskId));
                        context.Database.ExecuteSqlCommand("EXEC PozostaleSrodkiDlaZadnia @IdZadania", new SqlParameter("@IdZadania", App.CurrentTaskId));
                    }
                }
            }
            else
            {
                MessageBox.Show("Najpierw wybierz wniosek z listy.");
            }
        }
    }
}
