using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
                if (TaskListView.SelectedItem is Zadania selectedItem )
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

      
    }
}
