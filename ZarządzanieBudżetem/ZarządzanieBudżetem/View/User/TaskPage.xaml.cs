using Microsoft.Win32;
using System.Collections.Generic;
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

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            // Sprawdź, czy coś jest zaznaczone w liście
            if (TaskListView.SelectedItem != null)
            {
                // Sprawdź, czy wybrany element ma właściwość IdZadania
                if (TaskListView.SelectedItem is Zadania selectedItem)
                {
                    App.CurrentTaskId = selectedItem.IdZadania;

                    NavigationService.Navigate(new TaskDetailsPage());

                }


            }
            else { MessageBox.Show("najpierw wybierz pole z listy"); }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                // Pętla po wszystkich zadaniach w DataGrid
                foreach (var task in Tasks)
                {
                    // Tutaj możesz dodać logikę zapisywania zmian w bazie danych dla każdego zadania
                    var existingTask = context.Tasks.Find(task.IdZadania);

                    if (existingTask != null)
                    {
                        // Aktualizuj pola zadania na podstawie zmian wprowadzonych w interfejsie użytkownika
                        existingTask.Lp = task.Lp;
                        existingTask.Nazwa_Kosztu = task.Nazwa_Kosztu;
                        existingTask.Wartość_Ogółem = task.Wartość_Ogółem;
                        existingTask.Wydatki_Kwalifikowane = task.Wydatki_Kwalifikowane;
                        existingTask.Dofinansowanie = task.Dofinansowanie;
                        existingTask.Kategoria_Kosztów = task.Kategoria_Kosztów;
                        existingTask.Ilość_Personelu = task.Ilość_Personelu;
                        existingTask.Zakończone = task.Zakończone;
                    }
                    if (existingTask == null)
                    {
                        // Nowy obiekt Task na podstawie danych z interfejsu użytkownika
                        var newTask = new Zadania
                        {
                            Lp = task.Lp,
                            Nazwa_Kosztu = task.Nazwa_Kosztu,
                            Wartość_Ogółem = task.Wartość_Ogółem,
                            Wydatki_Kwalifikowane = task.Wydatki_Kwalifikowane,
                            Dofinansowanie = task.Dofinansowanie,
                            Kategoria_Kosztów = task.Kategoria_Kosztów,
                            Ilość_Personelu = task.Ilość_Personelu,
                            Zakończone = task.Zakończone,
                            IdProjektu = App.CurrentProjectId
                        };

                        // Dodaj nowy obiekt do kontekstu bazy danych
                        context.Tasks.Add(newTask);

                    }
                }

                // Zapisz zmiany w bazie danych
                context.SaveChanges();
                MessageBox.Show("Zapisano zmiany");
                CollectionViewSource.GetDefaultView(Tasks).Refresh();

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


                var excelImporter = new ExcelImporter();
                excelImporter.ImportData(excelFilePath);


                Tasks = dataStore.GetTasksForProject();
                TaskListView.ItemsSource = Tasks;

            }

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserProjectPage());
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // Sprawdź, czy coś jest zaznaczone w liście
            if (TaskListView.SelectedItem != null)
            {
                // Pobierz wybrane zadanie
                Zadania selectedTask = (Zadania)TaskListView.SelectedItem;

                MessageBoxResult result = MessageBox.Show($"Czy na pewno chcesz usunąć zadanie {selectedTask.Nazwa_Kosztu}?", "Potwierdzenie usunięcia", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Usuń z bazy danych
                    using (var context = new ApplicationDbContext())
                    {
                        var taskToDelete = context.Tasks
                            .Where(z => z.IdZadania == selectedTask.IdZadania)
                            .FirstOrDefault();

                        if (taskToDelete != null)
                        {
                            // Pobierz wszystkie związane z zadaniem faktury i wnioski
                            var invoiceIdsToDelete = context.Invoices
                                .Where(f => f.IdZadania == selectedTask.IdZadania)
                                .Select(f => f.IdFaktury)
                                .ToList();

                            var requestIdsToDelete = context.Requests
                                .Where(w => w.IdZadania == selectedTask.IdZadania)
                                .Select(w => w.IdWniosku)
                                .ToList();

                            // Usuń faktury i wnioski
                            context.Invoices.RemoveRange(context.Invoices.Where(f => invoiceIdsToDelete.Contains(f.IdFaktury)));
                            context.Requests.RemoveRange(context.Requests.Where(w => requestIdsToDelete.Contains(w.IdWniosku)));

                            // Usuń zadanie
                            context.Tasks.Remove(taskToDelete);

                            // Zapisz zmiany
                            context.SaveChanges();

                            // Odśwież listę zadań
                            Tasks = dataStore.GetTasksForProject();
                            TaskListView.ItemsSource = Tasks;

                        }
                    }
                }

            }
            else { MessageBox.Show("najpierw wybierz pole z listy"); }
        }
    }
}
