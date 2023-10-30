using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFwiz.Helper
{
    internal static class RandomHelper
    {
        internal static string GenerateUniqueKey(int size)
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var result = new StringBuilder(size);
            var guid = Guid.NewGuid().ToString().Replace("-", "");
            for (int i = 0; i < size; i++)
            {
                var index = (int)(guid[i] % chars.Length);
                result.Append(chars[index]);
            }
            return result.ToString();
        }

        internal static string GenerateRandomString(int size)
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new char[size];
            for (int i = 0; i < size; i++)
            {
                var index = random.Next(chars.Length);
                result[i] = chars[index];
            }
            return new string(result);
        }
    }
}
