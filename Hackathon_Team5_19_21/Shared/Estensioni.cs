using System.Security.Cryptography;
using System.Text;

namespace Hackathon_Team5_19_21.Shared
{
    public static class Estensioni
    {
        public static string Sha256(this string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++) builder.Append(bytes[i].ToString("x2"));
                return builder.ToString();
            }
        }

    }
}
