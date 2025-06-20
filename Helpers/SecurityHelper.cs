using System.Security.Cryptography;
using System.Text;

namespace Track2GrowProject.Helpers
{
    public static class SecurityHelper
    {
        public static string Hash(string input)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(input);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
