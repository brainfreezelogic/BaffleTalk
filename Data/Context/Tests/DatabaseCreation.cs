using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using BaffleTalk.Data.Context;
using BaffleTalk.Data.Entities.Membership;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DatabaseCreation
    {
        [TestFixtureSetUp]
        public void Initialize()
        {
            Database.SetInitializer<BaffleTalkContext>(new DropCreateDatabaseAlways<BaffleTalkContext>());
        }

        [Test]
        public void TestCreation()
        {
            using (var context = new BaffleTalkContext())
            {
                var user = new User
                {
                    Email = "jerad@jader201.com",
                    DateCreated = new DateTime(2012, 7, 7, 1, 0, 0),
                    DateUpdated = new DateTime(2012, 7, 7, 1, 0, 0),
                    DisplayName = "Jerad Rose",
                    PasswordHash = "hash",
                    PasswordSalt = "salt",
                    UniqueName = "jader201"
                };

                context.Users.Add(user);

                context.SaveChanges();
            }
        }
    }
}
