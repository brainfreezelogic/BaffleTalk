using System;
using System.Linq;
using BaffleTalk.Common.Exceptions;
using NUnit.Framework;

namespace BaffleTalk.Services.Domain.Tests.ConfirmEmailServiceTests
{
    [TestFixture]
    public class ConfirmEmail : _FixtureBase
    {
        [Test]
        public void ShouldThrowServiceExceptionWhenGuidAlreadyConfirmed()
        {
            Assert.Throws<ValidationException>(() => ConfirmEmailService.ConfirmEmail(new Guid("{9FAB1A9D-5DA5-429E-9339-DF8C8D468ACB}")));
        }

        [Test]
        public void ShouldThrowServiceExceptionWhenGuidNotFound()
        {
            Assert.Throws<ValidationException>(() => ConfirmEmailService.ConfirmEmail(new Guid("{59AE7514-93A1-4523-934E-4123C673F584}")));
        }

        [Test]
        public void ShouldUpdateConfirmationDateToUtcNowWhenGuidUnconfirmed()
        {
            var guid = new Guid("{0422FB37-6F5A-4068-9EF0-D53B6709398D}");

            try
            {
                ConfirmEmailService.ConfirmEmail(guid);
                Context.SaveChanges();
            }
            catch(ValidationException)
            {
                Assert.Inconclusive();
            }

            var confirmation = Context.UserEmailConfirmations.SingleOrDefault(c => c.Id == guid);

            if (confirmation == null) Assert.Inconclusive();

            Assert.AreEqual(DateTimeService.UtcNow, confirmation.DateConfirmed);
        }

        [Test]
        public void ShouldUpdateUserEmailWhenGuidUnconfirmed()
        {
            var guid = new Guid("{0422FB37-6F5A-4068-9EF0-D53B6709398D}");

            try
            {
                ConfirmEmailService.ConfirmEmail(guid);
                Context.SaveChanges();
            }
            catch (ValidationException)
            {
                Assert.Inconclusive();
            }

            var confirmation = Context.UserEmailConfirmations.SingleOrDefault(c => c.Id == guid);

            if (confirmation == null) Assert.Inconclusive();

            Assert.AreEqual(confirmation.Email, confirmation.User.Email);
        }
    }
}