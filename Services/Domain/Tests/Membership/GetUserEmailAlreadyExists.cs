using NUnit.Framework;

namespace BaffleTalk.Services.Domain.Tests.Membership
{
    [TestFixture]
    public class GetUserEmailAlreadyExists : MembershipFixtureBase
    {
        [Test]
        public void MustReturnFalseWhenEmailDoesNotExist()
        {
            bool actual = MembershipService.GetUserEmailAlreadyExists("nonexistent@email.com");
            Assert.AreEqual(false, actual);
        }

        [Test]
        public void MustReturnTrueWhenEmailExists()
        {
            bool actual = MembershipService.GetUserEmailAlreadyExists("jerad@jader201.com");
            Assert.AreEqual(true, actual);
        }
    }
}