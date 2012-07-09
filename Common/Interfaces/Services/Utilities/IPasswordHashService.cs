using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaffleTalk.Common.Interfaces.Services.Utilities
{
    public interface IPasswordHashService
    {
        string HashPassword(string password, Guid userGuid);
        bool VerifyPassword(string password, Guid userGuid, string passwordHash);
    }
}
