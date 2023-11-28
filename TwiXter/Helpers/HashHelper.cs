using System.Security.Cryptography;
using System.Text;

namespace TwiXter.Helpers
{
    public class HashHelper
    {
        public static string ToHash(string password)
        {
            MD5 md5 = MD5.Create();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] passwordHash = md5.ComputeHash(passwordBytes);
            
            return Convert.ToHexString(passwordHash);
        }
    }
}
