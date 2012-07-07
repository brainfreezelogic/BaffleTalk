using System;
using NUnit.Framework;

namespace BaffleTalk.Services.Domain.Tests.Membership
{
    [TestFixture]
    public class GetUserUniqueNameAlreadyExists : MembershipFixtureBase
    {
        [Test]
        public void MustReturnTrueWhenUniqueNameExists()
        {
            bool actual = MembershipService.GetUserUniqueNameAlreadyExists("jader201");
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void MustReturnTrueWhenTrimmedUniqueNameExists()
        {
            bool actual = MembershipService.GetUserUniqueNameAlreadyExists(" jader201 ");
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void MustReturnFalseWhenUniqueNameDoesNotExist()
        {
            bool actual = MembershipService.GetUserUniqueNameAlreadyExists("nonexistentname");
            Assert.AreEqual(false, actual);
        }

        [Test]
        public void MustThrowNullArgumentExceptionWhenNull()
        {
            Assert.Throws<ArgumentNullException>(() => MembershipService.GetUserUniqueNameAlreadyExists(null));
        }

        [Test]
        public void MustThrowNullArgumentExceptionWhenEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => MembershipService.GetUserUniqueNameAlreadyExists(String.Empty));
        }

        [Test]
        public void MustThrowNullArgumentExceptionWhenWhiteSpace()
        {
            Assert.Throws<ArgumentNullException>(() => MembershipService.GetUserUniqueNameAlreadyExists(" "));
        }
    }
}