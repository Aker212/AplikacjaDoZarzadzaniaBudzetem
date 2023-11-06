using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ZarządzanieBudżetem
{
    public class PasswordHasher
    {
        // Generuj losową sól.
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[32];
            using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        // Funkcja do haszowania hasła z solą.
        public static string HashPassword(string password, string salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password + salt);
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hashedBytes);
            }
        }

        // Funkcja do weryfikacji hasła.
        public static bool VerifyPassword(string inputPassword, string hashedPassword, string salt)
        {
            string inputHash = HashPassword(inputPassword, salt);
            return string.Equals(inputHash, hashedPassword);
        }

    }
}
