using System;
using NUnit.Framework;

namespace BaffleTalk.Services.Domain.Tests.SignupServiceTests
{
    [TestFixture]
    public class GetUserUniqueNameAlreadyExists : SignupServiceTests._FixtureBase
    {
        [Test]
        public void MustReturnTrueWhenUniqueNameExists()
        {
            bool actual = SignupService.GetUserUniqueNameAlreadyExists("jader201");
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void MustReturnTrueWhenTrimmedUniqueNameExists()
        {
            bool actual = SignupService.GetUserUniqueNameAlreadyExists(" jader201 ");
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void MustReturnFalseWhenUniqueNameDoesNotExist()
        {
            bool actual = SignupService.GetUserUniqueNameAlreadyExists("nonexistentname");
            Assert.AreEqual(false, actual);
        }

        [Test]
        public void MustThrowNullArgumentExceptionWhenNull()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.GetUserUniqueNameAlreadyExists(null));
        }

        [Test]
        public void MustThrowNullArgumentExceptionWhenEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.GetUserUniqueNameAlreadyExists(String.Empty));
        }

        [Test]
        public void MustThrowNullArgumentExceptionWhenWhiteSpace()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.GetUserUniqueNameAlreadyExists(" "));
        }
    }
}