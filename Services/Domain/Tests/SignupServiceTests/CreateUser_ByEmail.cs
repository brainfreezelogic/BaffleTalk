using System;
using System.Collections.Generic;
using System.Linq;
using BaffleTalk.Common.Interfaces.Services.Utilities;
using BaffleTalk.Data.Entities.Membership;
using Moq;
using NUnit.Framework;

namespace BaffleTalk.Services.Domain.Tests.SignupServiceTests
{
    [TestFixture]
    public class CreateUser_ByEmail : SignupServiceTests._FixtureBase
    {
        private User expectedUser;
        private string newPassword;
        private string newEmail;

        [SetUp]
        public void TestFixtureSetup()
        {
            expectedUser = new User
                               {
                                   Guid = Guid1,
                                   UniqueName = "uniqueGuy",
                                   DisplayName = "Unique Guy",
                                   BirthDate = new DateTime(1990, 1, 20),
                                   DateCreated = DateTimeService.UtcNow,
                                   PasswordHash = "saltysomepassword",
                               };

            newEmail = "uniqueguy@gmail.com";
            newPassword = "somepassword";
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenNullUniqueName()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser(null, "displayName", new DateTime(2012, 1, 1), "email", "password"));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenEmptyUniqueName()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser(String.Empty, "displayName", new DateTime(2012, 1, 1), "email", "password"));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenWhiteSpaceUniqueName()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser(" ", "displayName", new DateTime(2012, 1, 1), "email", "password"));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenNullDisplayName()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser("uniqueName", null, new DateTime(2012, 1, 1), "email", "password"));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenEmptyDisplayName()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser("uniqueName", String.Empty, new DateTime(2012, 1, 1), "email", "password"));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenWhiteSpaceDisplayName()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser("uniqueName", " ", new DateTime(2012, 1, 1), "email", "password"));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenMinValueBirthdate()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser("uniqueName", "displayName", new DateTime(), "email", "password"));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenNullEmail()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser("uniqueName", "displayName", new DateTime(2012, 1, 1), null, "password"));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenEmptyEmail()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser("uniqueName", "displayName", new DateTime(2012, 1, 1), String.Empty, "password"));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenWhiteSpaceEmail()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser("uniqueName", "displayName", new DateTime(2012, 1, 1), " ", "password"));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenNullPassword()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser("uniqueName", "displayName", new DateTime(2012, 1, 1), "email", null));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenEmptyPassword()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser("uniqueName", "displayName", new DateTime(2012, 1, 1), "email", String.Empty));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenWhiteSpacePassword()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser("uniqueName", "displayName", new DateTime(2012, 1, 1), "email", " "));
        }

        [Test]
        public void ShouldMapUniqueNameWhenValid()
        {
            var actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            Assert.AreEqual(expectedUser.UniqueName, actualUser.UniqueName);
        }

        [Test]
        public void ShouldMapTrimmedUniqueNameWhenHasWhiteSpace()
        {
            var actualUser = SignupService.CreateUser(" " + expectedUser.UniqueName + " ", expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            Assert.AreEqual(expectedUser.UniqueName, actualUser.UniqueName);
        }

        [Test]
        public void ShouldMapDisplayNameWhenValid()
        {
            var actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            Assert.AreEqual(expectedUser.DisplayName, actualUser.DisplayName);
        }

        [Test]
        public void ShouldMapTrimmedDisplayNameWhenHasWhiteSpace()
        {
            var actualUser = SignupService.CreateUser(expectedUser.UniqueName, " " + expectedUser.DisplayName + " ", expectedUser.BirthDate, newEmail, newPassword);

            Assert.AreEqual(expectedUser.DisplayName, actualUser.DisplayName);
        }

        [Test]
        public void ShouldMapBirthDateWhenValid()
        {
            var actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            Assert.AreEqual(expectedUser.BirthDate, actualUser.BirthDate);
        }

        [Test]
        public void ShouldReturnNullEmailWhenValid()
        {
            var actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            Assert.AreEqual(null, actualUser.Email);
        }

        [Test]
        public void ShouldMapDateCreatedToUtcNowWhenValid()
        {
            var actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            Assert.AreEqual(DateTimeService.UtcNow, actualUser.DateCreated);
        }

        [Test]
        public void ShouldMapGuidToNewGuidWhenValid()
        {
            var actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            Assert.Contains(actualUser.Guid, new List<Guid>{ Guid1, Guid2 });
        }

        [Test]
        public void ShouldMapPasswordHashToHashPasswordWhenValid()
        {
            var actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            Assert.AreEqual(expectedUser.PasswordHash, actualUser.PasswordHash);
        }

        [Test]
        public void ShouldSaveWithoutExceptionWhenValid()
        {
            var actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            try
            {
                Context.SaveChangesWithCatch();
            }
            catch(Exception ex)
            {

            }
        }

        [Test]
        public void ShouldCreateUserIdAfterSaveWhenValid()
        {
            var actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);
            Context.SaveChangesWithCatch();

            Assert.AreNotEqual(0, actualUser.Id);
        }

        [Test]
        public void ShouldIncrementUserCountByOneWhenValid()
        {
            var expected = Context.Users.Count() + 1;

            SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);
            Context.SaveChangesWithCatch();

            var actual = Context.Users.Count();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldCreateSingleEmailConfirmationRecordWhenValid()
        {
            var actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            Assert.IsNotNull(actualUser.UserEmailConfirmations);
            Assert.AreEqual(1, actualUser.UserEmailConfirmations.Count());
        }

        [Test]
        public void ShouldMapUserEmailConfirmationGuidWhenValid()
        {
            var actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            if (actualUser.UserEmailConfirmations == null || actualUser.UserEmailConfirmations.Count() != 1) Assert.Inconclusive("");

            Assert.Contains(actualUser.UserEmailConfirmations.Single().Id, new List<Guid> { Guid1, Guid2 });
        }

        [Test]
        public void ShouldMapUserEmailConfirmationUserWhenValid()
        {
            var actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            if (actualUser.UserEmailConfirmations == null || actualUser.UserEmailConfirmations.Count() != 1) Assert.Inconclusive("");

            Assert.AreEqual(actualUser, actualUser.UserEmailConfirmations.Single().User);
        }

        [Test]
        public void ShouldMapUserEmailConfirmationUserEmailWhenValid()
        {
            var actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            if (actualUser.UserEmailConfirmations == null || actualUser.UserEmailConfirmations.Count() != 1) Assert.Inconclusive("");

            Assert.AreEqual(newEmail, actualUser.UserEmailConfirmations.Single().Email);
        }

        [Test]
        public void ShouldMapTrimmedUserEmailConfirmationUserEmailWhenValid()
        {
            var actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, " " + newEmail + " ", newPassword);

            if (actualUser.UserEmailConfirmations == null || actualUser.UserEmailConfirmations.Count() != 1) Assert.Inconclusive("");

            Assert.AreEqual(newEmail, actualUser.UserEmailConfirmations.Single().Email);
        }

        [Test]
        public void ShouldMapUserEmailConfirmationDateCreatedToDateTimeUtcNowWhenValid()
        {
            var actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            if (actualUser.UserEmailConfirmations == null || actualUser.UserEmailConfirmations.Count() != 1) Assert.Inconclusive("");

            Assert.AreEqual(DateTimeService.UtcNow, actualUser.UserEmailConfirmations.Single().DateCreated);
        }

        [Test]
        public void ShouldReturnNullUserEmailConfirmationDateConfirmedWhenValid()
        {
            var actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            if (actualUser.UserEmailConfirmations == null || actualUser.UserEmailConfirmations.Count() != 1) Assert.Inconclusive("");

            Assert.IsNull(actualUser.UserEmailConfirmations.Single().DateConfirmed);
        }

        [Test]
        public void ShouldMapUserConfirmationEmailUserIdToUserUserIdAfterSaveWhenValid()
        {
            var actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);
            Context.SaveChangesWithCatch();

            if (actualUser.UserEmailConfirmations == null || actualUser.UserEmailConfirmations.Count() != 1) Assert.Inconclusive("");

            Assert.AreEqual(actualUser.Id, actualUser.UserEmailConfirmations.Single().UserId);
        }

    }
}
