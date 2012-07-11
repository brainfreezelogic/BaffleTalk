using System;
using NUnit.Framework;

namespace BaffleTalk.Services.Domain.Tests.AuthenticationServiceTests
{
    public class AuthenticateUser : _FixtureBase
    {
        [Test]
        public void ShouldThrowNullArgumentExceptionWhenPasswordIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => AuthenticationService.AuthenticateUser("jader201", String.Empty));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenPasswordIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => AuthenticationService.AuthenticateUser("jader201", null));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenPasswordIsWhiteSpace()
        {
            Assert.Throws<ArgumentNullException>(() => AuthenticationService.AuthenticateUser("jader201", " "));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenUniqueNameIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => AuthenticationService.AuthenticateUser(String.Empty, "hash"));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenUniqueNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => AuthenticationService.AuthenticateUser(null, "hash"));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenUniqueNameIsWhiteSpace()
        {
            Assert.Throws<ArgumentNullException>(() => AuthenticationService.AuthenticateUser(" ", "hash"));
        }

        [Test]
        public void ShouldReturnTrueWhenValidUniqueNameAndPassword()
        {
            Assert.IsTrue(AuthenticationService.AuthenticateUser("jader201", "hash"));
        }

        [Test]
        public void ShouldReturnTrueWhenValidTrimmedUniqueNameAndPassword()
        {
            Assert.IsTrue(AuthenticationService.AuthenticateUser(" jader201 ", "hash"));
        }

        [Test]
        public void ShouldReturnFalseWhenInvalidUniqueNameAndValidPassword()
        {
            Assert.IsFalse(AuthenticationService.AuthenticateUser("jader201b", "hash"));
        }

        [Test]
        public void ShouldReturnFalseWhenValidUniqueNameAndInvalidPassword()
        {
            Assert.IsFalse(AuthenticationService.AuthenticateUser("jader201", "hash1"));
        }
    }
}