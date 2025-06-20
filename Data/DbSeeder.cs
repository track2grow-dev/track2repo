using Microsoft.EntityFrameworkCore;
using Track2GrowProject.API.Models.Entities;
using System.Security.Cryptography;
using System.Text;

namespace Track2GrowProject.API.Data
{
    public class DbSeeder
    {
        public static async Task SeedAdminAsync(Track2GrowDbContext context)
        {
            if (!await context.Users.AnyAsync(u => u.Role == "Admin"))
            {
                var admin = new User
                {
                    Name = "AdminUser",
                    Email = "admin@track2grow.com",
                    Role = "Admin",
                    PasswordHash = Hash("admin@123") // Default password
                };

                context.Users.Add(admin);
                await context.SaveChangesAsync();
            }
        }

        private static string Hash(string input)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(input);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
