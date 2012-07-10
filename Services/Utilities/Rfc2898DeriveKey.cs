using System;
using System.Security.Cryptography;
using BaffleTalk.Common.Interfaces.Services.Utilities;

namespace BaffleTalk.Services.Utilities
{
    public class Rfc2898DeriveKey : IDeriveKey
    {
        #region IDeriveKey Members

        public byte[] GetBytes(string password, byte[] salt, int iterations, int byteCount)
        {
            var hasher = new Rfc2898DeriveBytes(password, salt, iterations);
            return hasher.GetBytes(byteCount);
        }

        #endregion
    }
}