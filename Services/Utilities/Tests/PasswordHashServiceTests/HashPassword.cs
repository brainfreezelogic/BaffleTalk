using System;
using NUnit.Framework;

namespace BaffleTalk.Services.Utilities.Tests.PasswordHashServiceTests
{
    [TestFixture]
    public class HashPassword : _FixtureBase
    {
        [Test]
        public void ShouldThrowNullArgumentExceptionWhenEmptyGuid()
        {
            Assert.Throws<ArgumentNullException>(() => MockPasswordHashService.HashPassword(null, Guid.Empty));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenNullPassword()
        {
            Assert.Throws<ArgumentNullException>(() => MockPasswordHashService.HashPassword(null, UserGuid));
        }

        [Test]
        public void ShouldReturnCorrectMockHashWhenValidParameters()
        {
            string actual = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(MockPasswordHashService.HashPassword(Password, UserGuid)));

            Assert.AreEqual(ExpectedMockHash, actual);
        }

        [Test]
        public void ShouldReturnCorrectRfc2898HashWhenValidParameters()
        {
            string actual = Rfc2898PasswordHashService.HashPassword(Password, UserGuid);

            Assert.AreEqual(ExpectedRfc2898Hash, actual);
        }
    }
}