using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Logika interakcji dla klasy AddReqPage.xaml
    /// </summary>
    public partial class AddReqPage : Page
    {
        public AddReqPage()
        {
            InitializeComponent();
        }

        private void AddReq_Click(object sender, RoutedEventArgs e)
        {
            // Pobierz wartości z pól
            string nrKsięgowy = NrKsięgowyTextBox.Text;
            decimal kwota = decimal.Parse(KwotaDofinansowaniaTextBox.Text); // Zakładam, że kwota jest liczbą, możesz dostosować odpowiednio
            DateTime dataWniosku = (DataWnioskuDatePicker.SelectedDate ?? DateTime.Now).Date;
            

            string dataString = dataWniosku.ToString("dd-MM-yyyy");

            using (var context = new ApplicationDbContext())
            {
                var newReq = new Wnioski
                {
                    NrKsięgowy = nrKsięgowy,
                    Kwota_Dofinansowania = kwota,
                    Data_Wniosku = DateTime.ParseExact(dataString, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    
                    IdZadania = App.CurrentTaskId

                };

                context.Requests.Add(newReq);
                context.SaveChanges();
                MessageBox.Show("Wniosek został pomyślnie dodany.");

                // Wywołaj procedurę sumującą po dodaniu wniosku                
                context.Database.ExecuteSqlCommand("EXEC PozostaleSrodkiDlaZadnia @IdZadania", new SqlParameter("@IdZadania", App.CurrentTaskId));


                NavigationService.Navigate(new TaskDetailsPage());

            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TaskDetailsPage());
        }
    }
}
