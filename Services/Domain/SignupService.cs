using System;
using System.Collections.Generic;
using System.Linq;
using BaffleTalk.Common.Interfaces.Services.Domain;
using BaffleTalk.Common.Interfaces.Services.Utilities;
using BaffleTalk.Data.Context;
using BaffleTalk.Data.Entities.Membership;

namespace BaffleTalk.Services.Domain
{
    public class SignupService : ISignupService
    {
        private readonly BaffleTalkContext context;
        private readonly IDateTimeService dateTimeService;
        private readonly IGuidService guidService;
        private readonly IPasswordHashService passwordHashService;

        public SignupService(BaffleTalkContext context, IDateTimeService dateTimeService, IGuidService guidService, IPasswordHashService passwordHashService)
        {
            this.context = context;
            this.dateTimeService = dateTimeService;
            this.guidService = guidService;
            this.passwordHashService = passwordHashService;
        }

        #region IMembershipService Members

        public bool GetUserEmailAlreadyExists(string email)
        {
            if (String.IsNullOrWhiteSpace(email)) throw new ArgumentNullException("email");

            IQueryable<User> users =
                from u in context.Users
                where u.Email == email.Trim()
                select u;

            return users.Any();
        }

        public bool GetUserUniqueNameAlreadyExists(string uniqueName)
        {
            if (String.IsNullOrWhiteSpace(uniqueName)) throw new ArgumentNullException("uniqueName");

            IQueryable<User> users =
                from u in context.Users
                where u.UniqueName == uniqueName.Trim()
                select u;

            return users.Any();
        }

        public User CreateUser(string uniqueName, string displayName, DateTime birthDate, string email, string password)
        {
            if (String.IsNullOrWhiteSpace(uniqueName)) throw new ArgumentNullException("uniqueName");
            if (String.IsNullOrWhiteSpace(displayName)) throw new ArgumentNullException("displayName");
            if (birthDate == DateTime.MinValue) throw new ArgumentNullException("birthDate");
            if (String.IsNullOrWhiteSpace(email)) throw new ArgumentNullException("email");
            if (String.IsNullOrWhiteSpace(password)) throw new ArgumentNullException("password");

            Guid userGuid = guidService.NewGuid();

            var user = new User
                           {
                               Guid = userGuid,
                               UniqueName = uniqueName.Trim(),
                               DisplayName = displayName.Trim(),
                               Email = null,
                               BirthDate = birthDate,
                               DateCreated = dateTimeService.UtcNow,
                               PasswordHash = passwordHashService.HashPassword(password, userGuid)
                           };

            var emailConfirmation = new UserEmailConfirmation
                                        {
                                            Id = guidService.NewGuid(),
                                            User = user,
                                            Email = email.Trim(),
                                            DateCreated = dateTimeService.UtcNow
                                        };

            user.UserEmailConfirmations = new List<UserEmailConfirmation> {emailConfirmation};

            context.Users.Add(user);

            return user;
        }

        #endregion
    }
}