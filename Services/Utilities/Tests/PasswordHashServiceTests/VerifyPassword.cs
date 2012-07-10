using System;
using NUnit.Framework;

namespace BaffleTalk.Services.Utilities.Tests.PasswordHashServiceTests
{
    [TestFixture]
    public class VerifyPassword : _FixtureBase
    {
        [Test]
        public void ShouldThrowNullArgumentExceptionWhenEmptyGuid()
        {
            Assert.Throws<ArgumentNullException>(() => MockPasswordHashService.VerifyPassword(Password, Guid.Empty, ExpectedMockHash));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenNullPassword()
        {
            Assert.Throws<ArgumentNullException>(() => MockPasswordHashService.VerifyPassword(null, UserGuid, ExpectedMockHash));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenNullHash()
        {
            Assert.Throws<ArgumentNullException>(() => MockPasswordHashService.VerifyPassword(Password, UserGuid, null));
        }

        [Test]
        public void ShouldReturnTrueWhenValidPassword()
        {
            bool actual = MockPasswordHashService.VerifyPassword(Password, UserGuid, Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(ExpectedMockHash)));

            Assert.IsTrue(actual);
        }

        [Test]
        public void ShouldReturnFalseWhenInvalidPassword()
        {
            bool actual = MockPasswordHashService.VerifyPassword("some made up password", UserGuid, ExpectedMockHash);

            Assert.IsFalse(actual);
        }

        [Test]
        public void ShouldReturnFalseWhenInvalidGuid()
        {
            bool actual = MockPasswordHashService.VerifyPassword(Password, Guid.Parse("{43830F82-E3A3-4D31-AD40-941CF0324D5C}"), ExpectedMockHash);

            Assert.IsFalse(actual);
        }

        [Test]
        public void ShouldReturnFalseWhenInvalidHash()
        {
            bool actual = MockPasswordHashService.VerifyPassword(Password, UserGuid, "some made up hash");

            Assert.IsFalse(actual);
        }
    }
}