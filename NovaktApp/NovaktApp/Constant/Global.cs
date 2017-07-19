using NovaktApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace NovaktApp.Constant
{
    public static class Global
    {
        public static Commercial commercial = new Commercial();

        public static String sha256(String value)
        {
            using (SHA256 hash = SHA256Managed.Create())
            {
                return String.Concat(hash
                  .ComputeHash(Encoding.UTF8.GetBytes(value))
                  .Select(item => item.ToString("x2"))).ToUpper();
            }
        }
    }
}
