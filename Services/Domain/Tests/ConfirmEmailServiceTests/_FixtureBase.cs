using BaffleTalk.Common.Interfaces.Services.Domain;
using NUnit.Framework;

namespace BaffleTalk.Services.Domain.Tests.ConfirmEmailServiceTests
{
    [TestFixture]
    public class _FixtureBase : Tests._FixtureBase
    {
        #region Setup/Teardown

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            ConfirmEmailService = new ConfirmEmailService(Context, DateTimeService);
        }

        #endregion

        protected IConfirmEmailService ConfirmEmailService;
    }
}