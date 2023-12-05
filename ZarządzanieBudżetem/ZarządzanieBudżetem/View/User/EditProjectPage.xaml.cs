using System;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy EditProjectPage.xaml
    /// </summary>
    public partial class EditProjectPage : Page
    {
        private Projekty editedProject;

        public EditProjectPage(Projekty project)
        {
            InitializeComponent();

            // Ustaw projekt do edycji
            editedProject = project;

            // Ustaw kontekst danych dla strony
            DataContext = editedProject;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentProjectId = 0;
            NavigationService.Navigate(new UserProjectPage());
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                // Sprawdź, czy wszystkie pola są uzupełnione
                if (string.IsNullOrEmpty(NameTextBox.Text) || string.IsNullOrEmpty(LpColumnTextBox.Text) ||
                    string.IsNullOrEmpty(NazwaKosztuColumnTextBox.Text) || string.IsNullOrEmpty(WartoscOgolnaColumnTextBox.Text) ||
                    string.IsNullOrEmpty(WydatkiKwalifikowaneColumnTextBox.Text) || string.IsNullOrEmpty(DofinansowanieColumnTextBox.Text) ||
                    string.IsNullOrEmpty(KategoriaKosztowColumnTextBox.Text))
                {
                    MessageBox.Show("Wypełnij wszystkie pola przed aktualizacją.");
                    return;
                }

                // Spróbuj parsować wartości do int, jeśli nie uda się, pokaż komunikat o błędzie
                if (!int.TryParse(LpColumnTextBox.Text, out int lpColumn) ||
                    !int.TryParse(NazwaKosztuColumnTextBox.Text, out int nazwaKosztuColumn) ||
                    !int.TryParse(WartoscOgolnaColumnTextBox.Text, out int wartoscOgolnaColumn) ||
                    !int.TryParse(WydatkiKwalifikowaneColumnTextBox.Text, out int wydatkiKwalifikowaneColumn) ||
                    !int.TryParse(DofinansowanieColumnTextBox.Text, out int dofinansowanieColumn) ||
                    !int.TryParse(KategoriaKosztowColumnTextBox.Text, out int kategoriaKosztowColumn))
                {
                    MessageBox.Show("Błąd podczas parsowania danych. Upewnij się, że wprowadzone dane są poprawne.");
                    return;
                }

                // Znajdź edytowany projekt w bazie danych
                var editedProject = context.Projects.FirstOrDefault(p => p.IdProjektu == App.CurrentProjectId);

                // Jeśli projekt nie został znaleziony, pokaż komunikat o błędzie
                if (editedProject == null)
                {
                    MessageBox.Show("Nie znaleziono projektu do edycji.");
                    return;
                }

                // Aktualizuj dane projektu
                editedProject.Nazwa = NameTextBox.Text;
                editedProject.LpColumn = lpColumn;
                editedProject.NazwaKosztuColumn = nazwaKosztuColumn;
                editedProject.WartoscOgolnaColumn = wartoscOgolnaColumn;
                editedProject.WydatkiKwalifikowaneColumn = wydatkiKwalifikowaneColumn;
                editedProject.DofinansowanieColumn = dofinansowanieColumn;
                editedProject.KategoriaKosztowColumn = kategoriaKosztowColumn;

                // Zapisz zmiany
                context.SaveChanges();

                MessageBox.Show("Projekt został pomyślnie zaktualizowany.");
                App.CurrentProjectId = 0;
                NavigationService.Navigate(new UserProjectPage());
            }

        }
    }
}
