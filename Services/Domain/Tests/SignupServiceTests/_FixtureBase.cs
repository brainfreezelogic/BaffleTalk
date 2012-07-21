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
        protected static Guid Guid1 = new Guid("{DF31C602-6FCD-42D4-9388-615899707839}");
        protected static Guid Guid2 = new Guid("{B0DEAE70-CDC5-41D1-B7FC-7EC81577F89B}");

        [SetUp]
        public override void TestFixtureSetUp()
        {
            var mockPasswordHash = new Mock<IPasswordHashService>();
            mockPasswordHash.Setup(m => m.HashPassword(It.IsAny<string>(), It.IsAny<Guid>())).Returns(
                    (string s, Guid g) => "salty" + s);

            base.TestFixtureSetUp();
            DateTimeService = new MockStaticDateTimeService(new DateTime(2012, 7, 8, 14, 23, 29));
            
            var guidServiceMock = new Mock<IGuidService>();
            guidServiceMock.SetupSequence(m => m.NewGuid()).Returns(Guid1).Returns(Guid2);

            SignupService = new SignupService(Context, DateTimeService, guidServiceMock.Object, mockPasswordHash.Object);
        }
    }
}