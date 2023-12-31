﻿using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ZarządzanieBudżetem.Models;
using ZarządzanieBudżetem.View.Admin;
using ZarządzanieBudżetem.View.User;

namespace ZarządzanieBudżetem.View
{
    /// <summary>
    /// Logika interakcji dla klasy LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private ApplicationDbContext dbContext;
        public LoginPage()
        {
            InitializeComponent();
            dbContext = new ApplicationDbContext();
        }

        public bool AuthenticateUser(string enteredPassword, string storedHashedPassword, string storedSalt)
        {
            // Weryfikuj hasło
            return PasswordHasher.VerifyPassword(enteredPassword, storedHashedPassword, storedSalt);
        }





        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string Email = EmailTextBox.Text;
            string Password = PasswordBox.Password;

            // Wyszukaj użytkownika w bazie danych
            Użytkownicy user = dbContext.Users.FirstOrDefault(u => u.Email == Email);

            if (user != null && PasswordHasher.VerifyPassword(Password, user.Hasło, user.Sól))
            {

                //Sprawdzanie czy użytkownik jest adminem czy userem
                string userRole = GetUserRole(Email);
                if (userRole == "Admin")
                {


                    NavigationService.Navigate(new AdministratorPage());

                }
                else if (userRole == "User")
                {
                    App.CurrentUserId = user.IdUżytkownika;
                    NavigationService.Navigate(new UserProjectPage());

                }









            }
            else
            {
                // Nieudane logowanie
                MessageBox.Show("Błąd logowania. Sprawdź email i hasło.");
            }
        }

        private string GetUserRole(string Email)
        {
            Użytkownicy user = dbContext.Users.FirstOrDefault(u => u.Email == Email);
            return user.Rola;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage());
        }
    }
}
