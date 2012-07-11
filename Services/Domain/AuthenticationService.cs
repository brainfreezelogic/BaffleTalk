using System;
using System.Linq;
using BaffleTalk.Common.Interfaces.Services.Domain;
using BaffleTalk.Common.Interfaces.Services.Utilities;
using BaffleTalk.Data.Context;

namespace BaffleTalk.Services.Domain
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly BaffleTalkContext context;
        private readonly IPasswordHashService passwordHashService;

        public AuthenticationService(BaffleTalkContext context, IPasswordHashService passwordHashService)
        {
            this.context = context;
            this.passwordHashService = passwordHashService;
        }

        #region IAuthenticationService Members

        public bool AuthenticateUser(string uniqueName, string password)
        {
            if (String.IsNullOrWhiteSpace(uniqueName)) throw new ArgumentNullException("uniqueName");
            if (String.IsNullOrWhiteSpace(password)) throw new ArgumentNullException("password");

            var users = from u in context.Users where u.UniqueName == uniqueName.Trim() select u;

            if (users.Count() != 1) return false;

            var user = users.Single();

            return passwordHashService.VerifyPassword(password, user.Guid, user.PasswordHash);
        }

        #endregion
    }
}