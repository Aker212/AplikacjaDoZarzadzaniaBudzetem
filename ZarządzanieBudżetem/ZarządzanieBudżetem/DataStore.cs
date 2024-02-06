using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ZarządzanieBudżetem.Models;

namespace ZarządzanieBudżetem
{
    public class DataStore
    {
        public bool IsEmailAlreadyExists(string email)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Users.Any(u => u.Email == email);
            }
        }

        public bool IsValidEmail(string email)
        {
            // Wyrażenie regularne do sprawdzenia poprawności adresu e-mail
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Sprawdzenie zgodności adresu e-mail z wyrażeniem regularnym
            return Regex.IsMatch(email, pattern);
        }

        public List<Projekty> GetProjects()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Projects
                             .Where(p => p.IdUżytkownika == App.CurrentUserId)
                             .OrderByDescending(p => p.Ostatnie_Użycie)
                             .ToList();

            }
        }

        public List<Faktury> GetInvoices()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Invoices
                             .Where(f => f.IdZadania == App.CurrentTaskId)
                             .ToList();
            }
        }

        public List<Wnioski> GetRequests()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Requests
                             .Where(w => w.IdZadania == App.CurrentTaskId)
                             .ToList();
            }
        }

        public List<Zadania> GetTasksForProject()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Tasks
                              .Where(z => z.IdProjektu == App.CurrentProjectId)
                              .ToList();
            }
        }
        public List<Użytkownicy> GetUsers()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Users
                              .Where(u => u.Rola == "User")
                              .ToList();
            }
        }

        public List<Projekty> GetSelectedUserProjects()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Projects
                             .Where(p => p.IdUżytkownika == App.SellectedUserId)
                             .ToList();
            }
        }

    }
}
