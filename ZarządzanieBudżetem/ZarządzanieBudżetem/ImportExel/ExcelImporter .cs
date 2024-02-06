using OfficeOpenXml;
using System;
using System.IO;
using System.Windows;
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

                    for (int row = 2; row <= rowCount; row++)
                    {
                        // Odczytaj dane z poszczególnych kolumn

                        int lp;
                        decimal wartoscOgolna, wydatkiKwalifikowane, dofinansowanie;

                        if (!int.TryParse(worksheet.Cells[row, App.LpColumn].Value?.ToString(), out lp))
                        {
                            lp = 0; // Domyślna wartość dla typu int
                        }

                        if (!decimal.TryParse(worksheet.Cells[row, App.WartoscOgolnaColumn].Value?.ToString(), out wartoscOgolna))
                        {
                            wartoscOgolna = 0m; // Domyślna wartość dla typu decimal
                        }
                        if (!decimal.TryParse(worksheet.Cells[row, App.WydatkiKwalifikowaneColumn].Value?.ToString(), out wydatkiKwalifikowane))
                        {
                            wydatkiKwalifikowane = 0m; // Domyślna wartość dla typu decimal
                        }
                        if (!decimal.TryParse(worksheet.Cells[row, App.DofinansowanieColumn].Value?.ToString(), out dofinansowanie))
                        {
                            dofinansowanie = 0m; // Domyślna wartość dla typu decimal
                        }

                        string nazwaKosztu = worksheet.Cells[row, App.NazwaKosztuColumn].Value?.ToString();
                        string kategoriaKosztow = worksheet.Cells[row, App.KategoriaKosztowColumn].Value?.ToString();

                        // Stwórz obiekt Zadania
                        var zadanie = new Zadania
                        {
                            Lp = lp,
                            Nazwa_Kosztu = nazwaKosztu,
                            Wartość_Ogółem = wartoscOgolna,
                            Wydatki_Kwalifikowane = wydatkiKwalifikowane,
                            Dofinansowanie = dofinansowanie,
                            Kategoria_Kosztów = kategoriaKosztow,
                            Ilość_Personelu = null,
                            Zakończone = false,
                            Pozostałe_Środki = dofinansowanie,
                            IdProjektu = App.CurrentProjectId

                        };


                        SaveDataToDatabase(zadanie);

                    }
                }


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
