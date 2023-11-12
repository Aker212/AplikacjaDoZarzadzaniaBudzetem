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
    }
}
