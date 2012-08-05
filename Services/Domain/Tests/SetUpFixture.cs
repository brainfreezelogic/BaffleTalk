using System;
using System.Data.Entity;
using BaffleTalk.Data.Context;
using BaffleTalk.Data.Entities.Membership;
using NUnit.Framework;

namespace BaffleTalk.Services.Domain.Tests
{
    [SetUpFixture]
    public class SetUpFixture
    {
        [SetUp]
        public void SetUp()
        {
            using (var startupContext = new BaffleTalkContext())
            {
                Database.SetInitializer(new ForceDeleteInitializer(new DropCreateDatabaseAlways<BaffleTalkContext>()));

                var user = new User
                               {
                                   Guid = new Guid("{FB86C4E1-DFCA-460D-96F2-485A9CDCC318}"),
                                   UniqueName = "jader201",
                                   DisplayName = "Jerad",
                                   Email = "jerad@jader201.com",
                                   PasswordHash = "saltyhash",
                                   BirthDate = new DateTime(1974, 10, 12),
                                   DateCreated = new DateTime(2012, 7, 5, 11, 05, 23),
                               };

                startupContext.Users.Add(user);

                var confirmedEmailConfirmation = new UserEmailConfirmation
                                                {
                                                    User = user,
                                                    Id = new Guid("{9FAB1A9D-5DA5-429E-9339-DF8C8D468ACB}"),
                                                    DateCreated = new DateTime(2012, 7, 5, 11, 05, 23),
                                                    DateConfirmed = new DateTime(2012, 7, 6, 11, 05, 23),
                                                    Email = "jerad@jader201.com"
                                                };

                startupContext.UserEmailConfirmations.Add(confirmedEmailConfirmation);

                var unconfirmedEmailConfirmation = new UserEmailConfirmation
                                                {
                                                    User = user,
                                                    Id = new Guid("{0422FB37-6F5A-4068-9EF0-D53B6709398D}"),
                                                    DateCreated = new DateTime(2012, 7, 5, 11, 05, 23),
                                                    DateConfirmed = null,
                                                    Email = "jerad@jader201.com"
                                                };

                startupContext.UserEmailConfirmations.Add(unconfirmedEmailConfirmation);
            }
        }
    }
}