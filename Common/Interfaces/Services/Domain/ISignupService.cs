using System;
using BaffleTalk.Data.Entities.Membership;

namespace BaffleTalk.Common.Interfaces.Services.Domain
{
    public interface ISignupService
    {
        bool GetUserEmailAlreadyExists(string email);
        bool GetUserUniqueNameAlreadyExists(string email);
        User CreateUser(string uniqueName, string displayName, DateTime birthDate, string email, string password);
        //void CreateUser(string uniqueName, string displayName, DateTime birthDate, IOauthData oauthData);
    }
}
