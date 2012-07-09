using System;
using BaffleTalk.Common.Interfaces.Services.Utilities;
using BaffleTalk.Services.Utilities.Mock;
using NUnit.Framework;

namespace BaffleTalk.Services.Utilities.Tests.PasswordHashServiceTests
{
    [TestFixture]
    public class HashPassword
    {
        private IPasswordHashService passwordHashService;
        private Guid userGuid;

        [SetUp]
        public void SetUp()
        {
            passwordHashService = new PasswordHashService();
            userGuid = new Guid("{59399537-C9FE-415B-8D8D-FC1636781A5D}");
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenNullPassword()
        {
            Assert.Throws<ArgumentNullException>(() => passwordHashService.HashPassword(null, userGuid));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenEmptyGuid()
        {
            Assert.Throws<ArgumentNullException>(() => passwordHashService.HashPassword(null, Guid.Empty));
        }

        [Test]
        public void ShouldReturnCorrectHashWhenValidParameters()
        {
            //var actual = 
        }
    }
}
