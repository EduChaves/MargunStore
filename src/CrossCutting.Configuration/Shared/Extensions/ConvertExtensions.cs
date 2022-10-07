using System;
using System.Text;

namespace MargunStore.CrossCutting.Configuration.Shared.Extensions
{
    public static class ConvertExtensions
    {
        public static string DecodeToBase64(string value) => Encoding.UTF8.GetString(Convert.FromBase64String(value));

        public static string EncodeToBase64(string value) => Convert.ToBase64String(Encoding.ASCII.GetBytes(value));
    }
}
