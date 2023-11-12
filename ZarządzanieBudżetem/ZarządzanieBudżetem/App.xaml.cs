using System.Windows;

namespace ZarządzanieBudżetem
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static int CurrentUserId { get; set; }
        public static int CurrentProjectId { get; set; }
        public static int CurrentTaskId { get; set; }
    }
}
