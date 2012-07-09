﻿using System;
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
        [SetUp]
        public void SetUp()
        {
            using (var startupContext = new BaffleTalkContext())
            {
                //var dateTimeService = _builder.Container.Resolve<IDateTimeService>(new NamedParameter("referenceDateTime", new DateTime(2012, 7, 5, 11, 05, 23)));
                var dateTimeService = new MockStaticDateTimeService(new DateTime(2012, 7, 5, 11, 05, 23));

                Database.SetInitializer(new ForceDeleteInitializer(new DropCreateDatabaseAlways<BaffleTalkContext>()));

                var user = new User
                {
                    Email = "jerad@jader201.com",
                    PasswordHash = "hash",
                    PasswordSalt = "salt",
                    DisplayName = "Jerad",
                    UniqueName = "jader201",
                    BirthDate = new DateTime(1974, 10, 12),
                    DateCreated = dateTimeService.UtcNow,
                };

                startupContext.Users.Add(user);
            }
        }
    }
}