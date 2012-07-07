using BaffleTalk.Common.Interfaces.Services.Domain;
using NUnit.Framework;

namespace BaffleTalk.Services.Domain.Tests.Membership
{
    [TestFixture]
    public abstract class MembershipFixtureBase : FixtureBase
    {
        protected IMembershipService MembershipService;

        [TestFixtureSetUp]
        public override void TestFixtureSetUp()
        {
            base.TestFixtureSetUp();
            MembershipService = new MembershipService(Context);
        }
    }
}