using System;
using BaffleTalk.Common.Interfaces.Services.Utilities;

namespace BaffleTalk.Services.Utilities
{
    public class PasswordHashService : IPasswordHashService
    {
        private readonly IDeriveKey deriveKey;

        public PasswordHashService(IDeriveKey deriveKey)
        {
            this.deriveKey = deriveKey;
        }

        #region IPasswordHashService Members

        public string HashPassword(string password, Guid userGuid)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (userGuid == Guid.Empty) throw new ArgumentNullException("userGuid");

            return Convert.ToBase64String(deriveKey.GetBytes(password, System.Text.Encoding.UTF8.GetBytes(userGuid + "Me likey some peppah!111one!1"), 10000, 128));
        }

        public bool VerifyPassword(string password, Guid userGuid, string passwordHash)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (userGuid == Guid.Empty) throw new ArgumentNullException("userGuid");
            if (passwordHash == null) throw new ArgumentNullException("passwordHash");

            return HashPassword(password, userGuid) == passwordHash;
        }

        #endregion
    }
}