using System.Collections.Generic;
using System.Linq;
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
