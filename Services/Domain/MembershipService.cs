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
            IQueryable<User> users =
                from u in _context.Users
                where u.Email == email
                select u;

            return users.Any();
        }

        public bool GetUserUniqueNameAlreadyExists(string uniqueName)
        {
            IQueryable<User> users =
                from u in _context.Users
                where u.UniqueName == uniqueName
                select u;

            return users.Any();
        }

        #endregion
    }
}