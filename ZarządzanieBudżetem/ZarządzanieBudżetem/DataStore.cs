using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                             .ToList();
            }
        }
    }
}
