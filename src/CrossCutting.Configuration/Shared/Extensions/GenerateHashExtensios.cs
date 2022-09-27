using System;
using System.Security.Cryptography;
using System.Text;

namespace MargunStore.CrossCutting.Configuration.Shared.Extensions
{
    public static class GenerateHashExtensios
    {
        public static string GenerateSHA256Hash(string value)
        {
            StringBuilder builder = new StringBuilder();

            using(var hash = SHA256.Create())
            {
                var result = hash.ComputeHash(Encoding.UTF8.GetBytes(value));

                foreach(var character in result)
                    builder.Append(character);
            }
            return builder.ToString();
        }

        public static string EncodeTo64(string value) => Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
    }
}
