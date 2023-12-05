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
        public static int SellectedUserId { get; set; }

        public static int LpColumn { get; set; }
        public static int NazwaKosztuColumn { get; set; }
        public static int WartoscOgolnaColumn { get; set; }
        public static int WydatkiKwalifikowaneColumn { get; set; }
        public static int DofinansowanieColumn { get; set; }
        public static int KategoriaKosztowColumn { get; set; }
    }
}
