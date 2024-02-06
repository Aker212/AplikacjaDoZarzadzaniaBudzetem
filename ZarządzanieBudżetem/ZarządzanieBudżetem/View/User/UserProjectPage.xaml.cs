using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using ZarządzanieBudżetem.Models;


namespace ZarządzanieBudżetem.View.User
{
    /// <summary>
    /// Logika interakcji dla klasy UserProjectPage.xaml
    /// </summary>
    public partial class UserProjectPage : Page
    {
        public List<Projekty> Projects { get; set; }

        private DataStore dataStore;

        public UserProjectPage()
        {

            InitializeComponent();
            dataStore = new DataStore();
            Projects = dataStore.GetProjects();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserAddProjectPage());
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ProjectList.SelectedItem != null)
            {
                Projekty selectedProject = (Projekty)ProjectList.SelectedItem;

                using (var context = new ApplicationDbContext())
                {
                    var projectToUpdate = context.Projects.Find(selectedProject.IdProjektu);

                    if (projectToUpdate != null)
                    {
                        // Aktualizuj pole Ostatnie_Użycie na obecną datę i czas
                        projectToUpdate.Ostatnie_Użycie = DateTime.Now;

                        // Zapisz zmiany w bazie danych
                        context.SaveChanges();
                    }
                }

                App.CurrentProjectId = selectedProject.IdProjektu;
                App.LpColumn = selectedProject.LpColumn;
                App.NazwaKosztuColumn = selectedProject.NazwaKosztuColumn;
                App.DofinansowanieColumn = selectedProject.DofinansowanieColumn;
                App.WartoscOgolnaColumn = selectedProject.WartoscOgolnaColumn;
                App.WydatkiKwalifikowaneColumn = selectedProject.WydatkiKwalifikowaneColumn;
                App.KategoriaKosztowColumn = selectedProject.KategoriaKosztowColumn;
                NavigationService.Navigate(new TaskPage());




            }
        }

        private void ProjectListView_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {


            var scrollViewer = VisualTreeHelper.GetChild(ProjectList, 0) as ScrollViewer;

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

        private void DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectList.SelectedItem != null)
            {
                Projekty selectedProject = (Projekty)ProjectList.SelectedItem;

                MessageBoxResult result = MessageBox.Show($"Czy na pewno chcesz usunąć projekt {selectedProject.Nazwa}?", "Potwierdzenie usunięcia", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Usuń z bazy danych
                    using (var context = new ApplicationDbContext())
                    {

                        var projectToDelete = context.Projects
                     .Where(p => p.IdProjektu == selectedProject.IdProjektu)
                     .FirstOrDefault();



                        if (projectToDelete != null)
                        {
                            // Pobierz wszystkie związane z projektem zadania, faktury i wnioski
                            var taskIdsToDelete = context.Tasks
                                .Where(z => z.IdProjektu == selectedProject.IdProjektu)
                                .Select(z => z.IdZadania)
                                .ToList();

                            var invoiceIdsToDelete = context.Invoices
                                .Where(f => taskIdsToDelete.Contains(f.IdZadania ?? 0))
                                .Select(f => f.IdFaktury)
                                .ToList();

                            var requestIdsToDelete = context.Requests
                                .Where(w => taskIdsToDelete.Contains(w.IdZadania ?? 0))
                                .Select(w => w.IdWniosku)
                                .ToList();

                            // Usuń faktury i wnioski
                            context.Invoices.RemoveRange(context.Invoices.Where(f => invoiceIdsToDelete.Contains(f.IdFaktury)));
                            context.Requests.RemoveRange(context.Requests.Where(w => requestIdsToDelete.Contains(w.IdWniosku)));

                            // Usuń zadania
                            context.Tasks.RemoveRange(context.Tasks.Where(z => taskIdsToDelete.Contains(z.IdZadania)));

                            // Usuń projekt
                            context.Projects.Remove(projectToDelete);

                            // Zapisz zmiany
                            context.SaveChanges();

                            // Odśwież listę projektów
                            Projects = dataStore.GetProjects();
                            ProjectList.ItemsSource = Projects;
                        }

                    }
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectList.SelectedItem != null)
            {
                // Pobierz wybrany projekt
                Projekty selectedProject = (Projekty)ProjectList.SelectedItem;

                App.CurrentProjectId = selectedProject.IdProjektu;
                // Przejdź do strony edycji projektu, przekazując wybrany projekt jako parametr
                NavigationService.Navigate(new EditProjectPage(selectedProject));
            }
            else
            {
                MessageBox.Show("Najpierw wybierz projekt z listy.");
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentUserId = 0;
            App.CurrentProjectId = 0;
            App.CurrentTaskId = 0;
            App.SellectedUserId = 0;
            App.InvoiceId = 0;
            App.LpColumn = 0;
            App.NazwaKosztuColumn = 0;
            App.WartoscOgolnaColumn = 0;
            App.WydatkiKwalifikowaneColumn = 0;
            App.DofinansowanieColumn = 0;
            App.KategoriaKosztowColumn = 0;
            NavigationService.Navigate(new LoginPage());
        }
    }
}
