using System;
using BaffleTalk.Common.Interfaces.Services.Domain;
using BaffleTalk.Common.Interfaces.Services.Utilities;
using Moq;
using NUnit.Framework;

namespace BaffleTalk.Services.Domain.Tests.AuthenticationServiceTests
{
    [TestFixture]
    public abstract class _FixtureBase : Tests._FixtureBase
    {
        protected IAuthenticationService AuthenticationService;

        [SetUp]
        public override void TestFixtureSetUp()
        {
            var mockPasswordHash = new Mock<IPasswordHashService>();
            mockPasswordHash
                .Setup(m => m.VerifyPassword(It.IsAny<string>(), new Guid("{FB86C4E1-DFCA-460D-96F2-485A9CDCC318}"), It.IsAny<string>()))
                .Returns((string s, Guid g, string h) => "salty" + s == h);

            base.TestFixtureSetUp();
            AuthenticationService = new AuthenticationService(Context, mockPasswordHash.Object);
        }
    }
}