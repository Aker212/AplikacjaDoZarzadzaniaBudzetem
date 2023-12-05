using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ZarządzanieBudżetem.Models;

namespace ZarządzanieBudżetem.View.User
{
    /// <summary>
    /// Logika interakcji dla klasy AddInvPage.xaml
    /// </summary>
    public partial class AddInvPage : Page
    {
        public AddInvPage()
        {
            InitializeComponent();
        }

        private void AddInv_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NrFakturyTextBox.Text))
            {
                MessageBox.Show("Wypełnij pole nr_faktury przed dodaniem.");
                return;
            }

            // Pobierz wartości z pól
            string nrFaktury = NrFakturyTextBox.Text;
            decimal kwota = decimal.Parse(KwotaTextBox.Text);
            DateTime dataFaktury = (DataFakturyDatePicker.SelectedDate ?? DateTime.Now).Date;
            string opis = OpisTextBox.Text;
            string jednostka = JednostkaTextBox.Text;
            string budynek = BudynekTextBox.Text;
            string pokoj = PokojTextBox.Text;



            string dataString = dataFaktury.ToString("dd-MM-yyyy");

            using (var context = new ApplicationDbContext())
            {
                var newInv = new Faktury
                {
                    Nr_faktury = nrFaktury,
                    Kwota = kwota,
                    Data_Faktury = DateTime.ParseExact(dataString, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Opis = opis,
                    Jednostka = jednostka,
                    Budynek = budynek,
                    Pokój = pokoj,
                    IdZadania = App.CurrentTaskId

                };

                context.Invoices.Add(newInv);
                context.SaveChanges();
                MessageBox.Show("Faktura została pomyślnie dodana.");

                // Wywołaj procedurę sumującą po dodaniu faktury
                context.Database.ExecuteSqlCommand("EXEC SumaWydatkowDlaZadania @IdZadania", new SqlParameter("@IdZadania", App.CurrentTaskId));
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
