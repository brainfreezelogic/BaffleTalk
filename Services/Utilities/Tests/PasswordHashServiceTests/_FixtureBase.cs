using System;
using BaffleTalk.Common.Interfaces.Services.Utilities;
using BaffleTalk.Services.Utilities.Mock;
using NUnit.Framework;

namespace BaffleTalk.Services.Utilities.Tests.PasswordHashServiceTests
{
    [TestFixture]
    public class _FixtureBase
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            MockPasswordHashService = new PasswordHashService(new MockDeriveKey());
            Rfc2898PasswordHashService = new PasswordHashService(new Rfc2898DeriveKey());
            UserGuid = new Guid("{59399537-C9FE-415B-8D8D-FC1636781A5D}");
        }

        #endregion

        protected const string ExpectedMockHash = "821000011!eno111!happep emos yekil eMd5a1876361cf-d8d8-b514-ef9c-73599395!Drowssa@pyM";
        protected const string ExpectedRfc2898Hash = @"vFERBOYRvj7MQguWUR0llH+VevyjdnzOeQxCIkZxXGuk7rcFcV2ZN/ZLLZvJ2/tI4Fc/GJz+M2o7UpBFEfZiaf/K3T3UAcywHu1heyAEDswr7R13tNt1aLqtkH7GwfIeJa0cg+EhbT0wDnWuT7KGcjrlf233er1Dl3CS3U2oRx8=";
        protected const string Password = "Myp@assworD!";
        protected IPasswordHashService MockPasswordHashService;
        protected IPasswordHashService Rfc2898PasswordHashService;
        protected Guid UserGuid;
    }
}