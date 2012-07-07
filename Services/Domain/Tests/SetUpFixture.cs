using System;
using System.Data.Entity;
using BaffleTalk.Data.Context;
using BaffleTalk.Data.Entities.Membership;
using BaffleTalk.Services.Utilities.Mock;
using NUnit.Framework;

namespace BaffleTalk.Services.Domain.Tests
{
    [SetUpFixture]
    public class SetUpFixture
    {
        private BaffleTalkContext _context;

        [SetUp]
        public void TestFixtureSetUp()
        {
            _context = new BaffleTalkContext();

            //var dateTimeService = _builder.Container.Resolve<IDateTimeService>(new NamedParameter("referenceDateTime", new DateTime(2012, 7, 5, 11, 05, 23)));
            var dateTimeService = new MockStaticDateTimeService(new DateTime(2012, 7, 5, 11, 05, 23));

            Database.SetInitializer(new DropCreateDatabaseAlways<BaffleTalkContext>());

            var user = new User
                           {
                               Email = "jerad@jader201.com",
                               PasswordHash = "hash",
                               PasswordSalt = "salt",
                               DisplayName = "Jerad",
                               UniqueName = "jader201",
                               DateCreated = dateTimeService.Now,
                           };

            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}