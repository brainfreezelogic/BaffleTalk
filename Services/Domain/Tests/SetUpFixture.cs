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
            }
        }
    }
}