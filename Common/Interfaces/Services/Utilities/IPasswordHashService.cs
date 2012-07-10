using System;

namespace BaffleTalk.Common.Interfaces.Services.Utilities
{
    public interface IPasswordHashService
    {
        string HashPassword(string password, Guid userGuid);
        bool VerifyPassword(string password, Guid userGuid, string passwordHash);
    }
}