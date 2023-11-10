using System.Data.Entity;
using ZarządzanieBudżetem.Models;

namespace ZarządzanieBudżetem
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("BudżetEntities")
        {
            // ...
        }
        public DbSet<Użytkownicy> Users { get; set; }
        public DbSet<Projekty> Projects { get; set; }
        public DbSet<Zadania> Tasks { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Użytkownicy>().HasKey(u => u.IdUżytkownika);
            modelBuilder.Entity<Projekty>().HasKey(p => p.IdProjektu);
            modelBuilder.Entity<Zadania>().HasKey(z => z.IdZadania);
            modelBuilder.Entity<Faktury>().HasKey(f => f.IdFaktury);
            modelBuilder.Entity<Wnioski>().HasKey(w => w.IdWniosku);
            // Dodaj konfiguracje innych kluczy głównych

            base.OnModelCreating(modelBuilder);
        }
    }


}
