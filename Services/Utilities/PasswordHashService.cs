using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaffleTalk.Common.Interfaces.Services.Utilities;

namespace BaffleTalk.Services.Utilities
{
    public class PasswordHashService : IPasswordHashService
    {
        public string HashPassword(string password, Guid userGuid)
        {
            throw new NotImplementedException();
        }

        public bool VerifyPassword(string password, Guid userGuid, string passwordHash)
        {
            throw new NotImplementedException();
        }
    }
}
