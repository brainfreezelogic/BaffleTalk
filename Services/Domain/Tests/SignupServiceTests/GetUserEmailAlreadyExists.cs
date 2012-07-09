using System;
using NUnit.Framework;

namespace BaffleTalk.Services.Domain.Tests.SignupServiceTests
{
    [TestFixture]
    public class GetUserEmailAlreadyExists : SignupServiceTests._FixtureBase
    {
        [Test]
        public void ShouldReturnTrueWhenEmailExists()
        {
            bool actual = SignupService.GetUserEmailAlreadyExists("jerad@jader201.com");
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void ShouldReturnTrueWhenTrimmedEmailExists()
        {
            bool actual = SignupService.GetUserEmailAlreadyExists(" jerad@jader201.com ");
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void ShouldReturnFalseWhenEmailDoesNotExist()
        {
            bool actual = SignupService.GetUserEmailAlreadyExists("nonexistent@email.com");
            Assert.AreEqual(false, actual);
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenNull()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.GetUserEmailAlreadyExists(null));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.GetUserEmailAlreadyExists(String.Empty));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenWhiteSpace()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.GetUserEmailAlreadyExists(" "));
        }
    }
}