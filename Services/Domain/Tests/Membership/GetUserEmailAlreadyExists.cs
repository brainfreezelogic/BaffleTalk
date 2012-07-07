using System;
using NUnit.Framework;

namespace BaffleTalk.Services.Domain.Tests.Membership
{
    [TestFixture]
    public class GetUserEmailAlreadyExists : MembershipFixtureBase
    {
        [Test]
        public void MustReturnTrueWhenEmailExists()
        {
            bool actual = MembershipService.GetUserEmailAlreadyExists("jerad@jader201.com");
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void MustReturnTrueWhenTrimmedEmailExists()
        {
            bool actual = MembershipService.GetUserEmailAlreadyExists(" jerad@jader201.com ");
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void MustReturnFalseWhenEmailDoesNotExist()
        {
            bool actual = MembershipService.GetUserEmailAlreadyExists("nonexistent@email.com");
            Assert.AreEqual(false, actual);
        }

        [Test]
        public void MustThrowNullArgumentExceptionWhenNull()
        {
            Assert.Throws<ArgumentNullException>(() => MembershipService.GetUserEmailAlreadyExists(null));
        }

        [Test]
        public void MustThrowNullArgumentExceptionWhenEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => MembershipService.GetUserEmailAlreadyExists(String.Empty));
        }

        [Test]
        public void MustThrowNullArgumentExceptionWhenWhiteSpace()
        {
            Assert.Throws<ArgumentNullException>(() => MembershipService.GetUserEmailAlreadyExists(" "));
        }
    }
}