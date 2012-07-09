using System;
using BaffleTalk.Common.Interfaces.Services.Domain;
using BaffleTalk.Common.Interfaces.Services.Utilities;
using BaffleTalk.Services.Utilities.Mock;
using NUnit.Framework;

namespace BaffleTalk.Services.Domain.Tests.SignupServiceTests
{
    [TestFixture]
    public abstract class _FixtureBase : BaffleTalk.Services.Domain.Tests._FixtureBase
    {
        protected ISignupService SignupService;
        protected IDateTimeService DateTimeService;

        [TestFixtureSetUp]
        public override void TestFixtureSetUp()
        {
            base.TestFixtureSetUp();
            DateTimeService = new MockStaticDateTimeService(new DateTime(2012, 7, 8, 14, 23, 29));
            SignupService = new SignupService(Context, DateTimeService);
        }
    }
}