using System;
using System.Linq;
using BaffleTalk.Common.Interfaces.Services.Domain;
using BaffleTalk.Data.Context;
using BaffleTalk.Data.Entities.Membership;

namespace BaffleTalk.Services.Domain
{
    public class MembershipService : IMembershipService
    {
        private readonly BaffleTalkContext _context;

        public MembershipService(BaffleTalkContext context)
        {
            _context = context;
        }

        #region IMembershipService Members

        public bool GetUserEmailAlreadyExists(string email)
        {
            if (String.IsNullOrWhiteSpace(email)) throw new ArgumentNullException("email");

            IQueryable<User> users =
                from u in _context.Users
                where u.Email == email.Trim()
                select u;

            return users.Any();
        }

        public bool GetUserUniqueNameAlreadyExists(string uniqueName)
        {
            if (String.IsNullOrWhiteSpace(uniqueName)) throw new ArgumentNullException("uniqueName");

            IQueryable<User> users =
                from u in _context.Users
                where u.UniqueName == uniqueName.Trim()
                select u;

            return users.Any();
        }

        #endregion
    }
}