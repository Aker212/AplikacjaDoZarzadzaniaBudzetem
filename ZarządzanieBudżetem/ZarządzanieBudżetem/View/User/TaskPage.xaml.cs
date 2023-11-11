using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using ZarządzanieBudżetem.ImportExel;
using ZarządzanieBudżetem.Models;

namespace ZarządzanieBudżetem.View.User
{
    /// <summary>
    /// Logika interakcji dla klasy TaskPage.xaml
    /// </summary>
    public partial class TaskPage : Page
    {
        public List<Zadania> Tasks { get; set; }
        private DataStore dataStore;
        public TaskPage()
        {
            InitializeComponent();
            dataStore = new DataStore();
            Tasks = dataStore.GetTasksForProject();
            DataContext = this;
        }

        private void TaskListView_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {


            var scrollViewer = VisualTreeHelper.GetChild(TaskListView, 0) as ScrollViewer;

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

        private void EndTask_Click(object sender, RoutedEventArgs e)
        {
            // Sprawdź, czy coś jest zaznaczone w liście
            if (TaskListView.SelectedItem != null)
            {
                // Sprawdź, czy wybrany element ma właściwość Zakończone
                if (TaskListView.SelectedItem is Zadania selectedItem)
                {
                    if (selectedItem.Zakończone == false)
                    {
                        selectedItem.Zakończone = true;
                    }

                    else if (selectedItem.Zakończone == true)
                    {
                        selectedItem.Zakończone = false;
                    }

                    using (var context = new ApplicationDbContext())
                    {
                        // Zaktualizuj dane w bazie danych
                        context.Entry(selectedItem).State = EntityState.Modified;
                        context.SaveChanges();
                    }

                    // Odśwież widok, jeśli Twoja kolekcja implementuje INotifyPropertyChanged
                    CollectionViewSource.GetDefaultView(Tasks).Refresh();

                }
            }
            else { MessageBox.Show("najpierw wybierz pole do zmiany"); }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationDbContext()) // Zastąp ApplicationDbContext odpowiednim kontekstem bazodanowym
            {
                // Pętla po wszystkich zadaniach w DataGrid
                foreach (var task in Tasks)
                {
                    // Tutaj możesz dodać logikę zapisywania zmian w bazie danych dla każdego zadania
                    var existingTask = context.Tasks.Find(task.IdZadania);

                    if (existingTask != null)
                    {
                        // Aktualizuj pola zadania na podstawie zmian wprowadzonych w interfejsie użytkownika
                        existingTask.Nazwa_Kosztu = task.Nazwa_Kosztu;
                        existingTask.Wartość_Ogółem = task.Wartość_Ogółem;
                        existingTask.Wydatki_Kwalifikowane = task.Wydatki_Kwalifikowane;
                        existingTask.Dofinansowanie = task.Dofinansowanie;
                        existingTask.Kategoria_Kosztów = task.Kategoria_Kosztów;
                        existingTask.Ilość_Personelu = task.Ilość_Personelu;
                        existingTask.Zakończone = task.Zakończone;
                    }
                }

                // Zapisz zmiany w bazie danych
                context.SaveChanges();
                MessageBox.Show("Zapisano zmiany");


            }
            }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            // Otwórz okno dialogowe do wyboru pliku Excela
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Pliki Excela (*.xlsx)|*.xlsx|Wszystkie pliki (*.*)|*.*",
                Title = "Wybierz plik Excela"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                // Pobierz ścieżkę do wybranego pliku Excela
                string excelFilePath = openFileDialog.FileName;

                // Utwórz instancję klasy ExcelImporter i zaimportuj dane
                var excelImporter = new ExcelImporter();
                excelImporter.ImportData(excelFilePath);

                // Dodaj kod obsługujący, co ma się stać po zaimportowaniu danych (np. wyświetlenie komunikatu)
                CollectionViewSource.GetDefaultView(Tasks).Refresh();
                MessageBox.Show("Dane zostały zaimportowane pomyślnie.");
            }

        }
    }
}
