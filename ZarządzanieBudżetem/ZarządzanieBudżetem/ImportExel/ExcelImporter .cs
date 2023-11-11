using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using OfficeOpenXml;
using ZarządzanieBudżetem.Models;

namespace ZarządzanieBudżetem.ImportExel
{
    public class ExcelImporter : IExcelImporter
    {
        public void ImportData(string filePath)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(filePath);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Zakładamy, że dane znajdują się na pierwszym arkuszu

                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++) // Zakładam, że dane zaczynają się od drugiego wiersza
                    {
                        // Odczytaj dane z poszczególnych kolumn

                        int lp = int.Parse(worksheet.Cells[row, 1].Value?.ToString());
                        string nazwaKosztu = worksheet.Cells[row, 2].Value?.ToString();
                        decimal wartoscOgolna = decimal.Parse(worksheet.Cells[row, 6].Value?.ToString());
                        decimal wydatkiKwalifikowane = decimal.Parse(worksheet.Cells[row, 7].Value?.ToString());
                        decimal dofinansowanie = decimal.Parse(worksheet.Cells[row, 8].Value?.ToString());
                        string kategoriaKosztow = worksheet.Cells[row, 9].Value?.ToString();

                        // Stwórz obiekt Zadania
                        var zadanie = new Zadania
                        {
                            Lp = lp,
                            Nazwa_Kosztu = nazwaKosztu,
                            Wartość_Ogółem = wartoscOgolna,
                            Wydatki_Kwalifikowane = wydatkiKwalifikowane,
                            Dofinansowanie = dofinansowanie,
                            Kategoria_Kosztów = kategoriaKosztow,
                            Ilość_Personelu = 0,
                            Zakończone = false,
                            IdProjektu = App.CurrentProjectId
                        };

                        // Wywołaj funkcję SaveDataToDatabase, aby zapisać dane do bazy danych
                        SaveDataToDatabase(zadanie);
                    }
                }

                // Dodaj kod obsługujący, co ma się stać po zaimportowaniu danych
                 MessageBox.Show("Dane zostały zaimportowane pomyślnie.");
            }
            catch (Exception ex)
            {
                // Dodaj kod obsługujący błędy (np. wyświetlenie komunikatu z błędem)
                 MessageBox.Show($"Wystąpił błąd podczas importu danych: {ex.Message}");
            }
        }

        // Funkcja do zapisu danych do bazy danych
        private static void SaveDataToDatabase(Zadania zadanie)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Tasks.Add(zadanie);
                context.SaveChanges();
            }
        }
    }
}
