using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaffleTalk.Common.Interfaces.Services.Utilities;

namespace BaffleTalk.Services.Utilities.Mock
{
    public class MockDeriveKey : IDeriveKey
    {
        public byte[] GetBytes(string password, byte[] salt, int iterations, int byteCount)
        {
            Func<string, string> reverseString = (s =>
            {
                char[] arr = s.ToCharArray();
                Array.Reverse(arr);
                return new string(arr);
            });

            return Encoding.Default.GetBytes(reverseString(password + Encoding.UTF8.GetString(salt) + iterations.ToString() + byteCount.ToString()));
        }
    }
}
