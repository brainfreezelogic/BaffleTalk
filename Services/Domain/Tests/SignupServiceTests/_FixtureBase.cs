using System;
using BaffleTalk.Common.Interfaces.Services.Domain;
using BaffleTalk.Common.Interfaces.Services.Utilities;
using BaffleTalk.Services.Utilities.Mock;
using Moq;
using NUnit.Framework;

namespace BaffleTalk.Services.Domain.Tests.SignupServiceTests
{
    [TestFixture]
    public abstract class _FixtureBase : BaffleTalk.Services.Domain.Tests._FixtureBase
    {
        protected ISignupService SignupService;
        protected IDateTimeService DateTimeService;
        protected IGuidService GuidService;
        protected static Guid UserGuid = new Guid("{DF31C602-6FCD-42D4-9388-615899707839}");

        [TestFixtureSetUp]
        public override void TestFixtureSetUp()
        {
            var mockPasswordHash = new Mock<IPasswordHashService>();
            mockPasswordHash.Setup(m => m.HashPassword(It.IsAny<string>(), UserGuid)).Returns(
                    (string s, Guid g) => "salty" + s);

            base.TestFixtureSetUp();
            DateTimeService = new MockStaticDateTimeService(new DateTime(2012, 7, 8, 14, 23, 29));
            GuidService = new MockGuidService(UserGuid);
            SignupService = new SignupService(Context, DateTimeService, GuidService, mockPasswordHash.Object);
        }
    }
}