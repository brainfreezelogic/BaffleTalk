using System;
using System.Data.Entity;
using BaffleTalk.Data.Entities.Membership;
using NUnit.Framework;

namespace BaffleTalk.Data.Context.Tests
{
    [TestFixture]
    public class DatabaseCreation
    {
        [TestFixtureSetUp]
        public void Initialize()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<BaffleTalkContext>());
        }

        [Test]
        public void TestCreation()
        {
            using (var context = new BaffleTalkContext())
            {
                Database.SetInitializer(new ForceDeleteInitializer(new DropCreateDatabaseAlways<BaffleTalkContext>()));

                var user = new User
                               {
                                   Guid = new Guid("{CC89AB81-00BF-40D1-ABCC-8DE9A1EFDF93}"),
                                   Email = "jerad@jader201.com",
                                   BirthDate = new DateTime(1974, 10, 12),
                                   DateCreated = new DateTime(2012, 7, 7, 1, 0, 0),
                                   DisplayName = "Jerad Rose",
                                   PasswordHash = "hash",
                                   UniqueName = "jader201"
                               };

                context.Users.Add(user);

                try
                {
                    context.SaveChanges();
                }
                catch(Exception ex)
                {
                    Assert.Fail(ex.Message);
                }
            }
        }
    }
}