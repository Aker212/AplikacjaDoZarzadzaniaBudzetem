using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZarządzanieBudżetem.Models;

namespace ZarządzanieBudżetem.View.User
{
    /// <summary>
    /// Logika interakcji dla klasy GenereteWordPage.xaml
    /// </summary>
    public partial class GenereteWordPage : Page
    {
        private Faktury selectedInv;
        public GenereteWordPage(Faktury inv)
        {

            InitializeComponent();

            selectedInv = inv;

            // Ustaw kontekst danych dla strony
            DataContext = selectedInv;
        }

        private void FindAndReplace(WordprocessingDocument doc, string search, string replace)
        {
            var body = doc.MainDocumentPart.Document.Body;

            foreach (var text in body.Descendants<Text>().Where(t => t.Text.Contains(search)))
            {
                text.Text = text.Text.Replace(search, replace);
            }
        }
        private void GenereteWord_Click(object sender, RoutedEventArgs e)
        {
            // Tworzenie obiektu SaveFileDialog
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();

            // Ustawienia początkowe dla SaveFileDialog
            saveFileDialog.Filter = "Pliki Worda (*.docx)|*.docx|Wszystkie pliki (*.*)|*.*";
            saveFileDialog.DefaultExt = ".docx";
            saveFileDialog.AddExtension = true;

            // Wyświetlenie okna dialogowego i sprawdzenie, czy użytkownik wybrał plik
            bool? result = saveFileDialog.ShowDialog();

            if (result == true)
            { 
                // Pobranie ścieżki do wybranego pliku
                string destinationFilePath = saveFileDialog.FileName;
                string filePath = "Szablon.docx";
                //string destinationFilePath = "Raport.docx";
                
            using (WordprocessingDocument destinationDoc = WordprocessingDocument.Create(destinationFilePath, WordprocessingDocumentType.Document))
            {
                foreach (var part in WordprocessingDocument.Open(filePath, false).Parts)
                {
                    destinationDoc.AddPart(part.OpenXmlPart, part.RelationshipId);
                }

                FindAndReplace(destinationDoc, "<nr faktury>", NrFakturyTextBox.Text);
                FindAndReplace(destinationDoc, "<Opis>", OpisTextBox.Text);
                FindAndReplace(destinationDoc, "<Zadanie X>", PozycjiTextBox.Text);
                FindAndReplace(destinationDoc, "<Zadanie X2>", PozTextBox.Text);
                FindAndReplace(destinationDoc, "<Kwota>", KwotaTextBox.Text);
                FindAndReplace(destinationDoc, "<Gotowka>", GotowkaTextBox.Text);
                FindAndReplace(destinationDoc, "<Dotyczy>", ZwrotTextBox.Text);
                FindAndReplace(destinationDoc, "<przed>", PrzedTextBox.Text);
                FindAndReplace(destinationDoc, "<nr procedury>", NrProceduryTextBox.Text);
            }

            MessageBox.Show("Gotowe, przenieś swój raport");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TaskDetailsPage());
        }
    }
}
