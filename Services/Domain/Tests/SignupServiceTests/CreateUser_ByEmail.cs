﻿using System;
using System.Collections.Generic;
using System.Linq;
using BaffleTalk.Data.Entities.Membership;
using NUnit.Framework;

namespace BaffleTalk.Services.Domain.Tests.SignupServiceTests
{
    [TestFixture]
    public class CreateUser_ByEmail : _FixtureBase
    {
        #region Setup/Teardown

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

        #endregion

        private User expectedUser;
        private string newPassword;
        private string newEmail;

        [Test]
        public void ShouldCreateSingleEmailConfirmationRecordWhenValid()
        {
            User actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            Assert.IsNotNull(actualUser.UserEmailConfirmations);
            Assert.AreEqual(1, actualUser.UserEmailConfirmations.Count());
        }

        [Test]
        public void ShouldCreateUserIdAfterSaveWhenValid()
        {
            User actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);
            Context.SaveChangesWithCatch();

            Assert.AreNotEqual(0, actualUser.Id);
        }

        [Test]
        public void ShouldIncrementUserCountByOneWhenValid()
        {
            int expected = Context.Users.Count() + 1;

            SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);
            Context.SaveChangesWithCatch();

            int actual = Context.Users.Count();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldMapBirthDateWhenValid()
        {
            User actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            Assert.AreEqual(expectedUser.BirthDate, actualUser.BirthDate);
        }

        [Test]
        public void ShouldMapDateCreatedToUtcNowWhenValid()
        {
            User actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            Assert.AreEqual(DateTimeService.UtcNow, actualUser.DateCreated);
        }

        [Test]
        public void ShouldMapDisplayNameWhenValid()
        {
            User actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            Assert.AreEqual(expectedUser.DisplayName, actualUser.DisplayName);
        }

        [Test]
        public void ShouldMapGuidToNewGuidWhenValid()
        {
            User actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            Assert.Contains(actualUser.Guid, new List<Guid> { Guid1, Guid2 });
        }

        [Test]
        public void ShouldMapPasswordHashToHashPasswordWhenValid()
        {
            User actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            Assert.AreEqual(expectedUser.PasswordHash, actualUser.PasswordHash);
        }

        [Test]
        public void ShouldMapTrimmedDisplayNameWhenHasWhiteSpace()
        {
            User actualUser = SignupService.CreateUser(expectedUser.UniqueName, " " + expectedUser.DisplayName + " ", expectedUser.BirthDate, newEmail, newPassword);

            Assert.AreEqual(expectedUser.DisplayName, actualUser.DisplayName);
        }

        [Test]
        public void ShouldMapTrimmedUniqueNameWhenHasWhiteSpace()
        {
            User actualUser = SignupService.CreateUser(" " + expectedUser.UniqueName + " ", expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            Assert.AreEqual(expectedUser.UniqueName, actualUser.UniqueName);
        }

        [Test]
        public void ShouldMapTrimmedUserEmailConfirmationUserEmailWhenValid()
        {
            User actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, " " + newEmail + " ", newPassword);

            if (actualUser.UserEmailConfirmations == null || actualUser.UserEmailConfirmations.Count() != 1) Assert.Inconclusive("");

            Assert.AreEqual(newEmail, actualUser.UserEmailConfirmations.Single().Email);
        }

        [Test]
        public void ShouldMapUniqueNameWhenValid()
        {
            User actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            Assert.AreEqual(expectedUser.UniqueName, actualUser.UniqueName);
        }

        [Test]
        public void ShouldMapUserConfirmationEmailUserIdToUserUserIdAfterSaveWhenValid()
        {
            User actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);
            Context.SaveChangesWithCatch();

            if (actualUser.UserEmailConfirmations == null || actualUser.UserEmailConfirmations.Count() != 1) Assert.Inconclusive("");

            Assert.AreEqual(actualUser.Id, actualUser.UserEmailConfirmations.Single().UserId);
        }

        [Test]
        public void ShouldMapUserEmailConfirmationDateCreatedToDateTimeUtcNowWhenValid()
        {
            User actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            if (actualUser.UserEmailConfirmations == null || actualUser.UserEmailConfirmations.Count() != 1) Assert.Inconclusive("");

            Assert.AreEqual(DateTimeService.UtcNow, actualUser.UserEmailConfirmations.Single().DateCreated);
        }

        [Test]
        public void ShouldMapUserEmailConfirmationGuidWhenValid()
        {
            User actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            if (actualUser.UserEmailConfirmations == null || actualUser.UserEmailConfirmations.Count() != 1) Assert.Inconclusive("");

            Assert.Contains(actualUser.UserEmailConfirmations.Single().Id, new List<Guid> { Guid1, Guid2 });
        }

        [Test]
        public void ShouldMapUserEmailConfirmationUserEmailWhenValid()
        {
            User actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            if (actualUser.UserEmailConfirmations == null || actualUser.UserEmailConfirmations.Count() != 1) Assert.Inconclusive("");

            Assert.AreEqual(newEmail, actualUser.UserEmailConfirmations.Single().Email);
        }

        [Test]
        public void ShouldMapUserEmailConfirmationUserWhenValid()
        {
            User actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            if (actualUser.UserEmailConfirmations == null || actualUser.UserEmailConfirmations.Count() != 1) Assert.Inconclusive("");

            Assert.AreEqual(actualUser, actualUser.UserEmailConfirmations.Single().User);
        }

        [Test]
        public void ShouldReturnNullEmailWhenValid()
        {
            User actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            Assert.AreEqual(null, actualUser.Email);
        }

        [Test]
        public void ShouldReturnNullUserEmailConfirmationDateConfirmedWhenValid()
        {
            User actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            if (actualUser.UserEmailConfirmations == null || actualUser.UserEmailConfirmations.Count() != 1) Assert.Inconclusive("");

            Assert.IsNull(actualUser.UserEmailConfirmations.Single().DateConfirmed);
        }

        [Test]
        public void ShouldSaveWithoutExceptionWhenValid()
        {
            SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, newEmail, newPassword);

            try
            {
                Context.SaveChangesWithCatch();
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenEmptyDisplayName()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser("uniqueName", String.Empty, new DateTime(2012, 1, 1), "email", "password"));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenEmptyEmail()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser("uniqueName", "displayName", new DateTime(2012, 1, 1), String.Empty, "password"));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenEmptyPassword()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser("uniqueName", "displayName", new DateTime(2012, 1, 1), "email", String.Empty));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenEmptyUniqueName()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser(String.Empty, "displayName", new DateTime(2012, 1, 1), "email", "password"));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenMinValueBirthdate()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser("uniqueName", "displayName", new DateTime(), "email", "password"));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenNullDisplayName()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser("uniqueName", null, new DateTime(2012, 1, 1), "email", "password"));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenNullEmail()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser("uniqueName", "displayName", new DateTime(2012, 1, 1), null, "password"));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenNullPassword()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser("uniqueName", "displayName", new DateTime(2012, 1, 1), "email", null));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenNullUniqueName()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser(null, "displayName", new DateTime(2012, 1, 1), "email", "password"));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenWhiteSpaceDisplayName()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser("uniqueName", " ", new DateTime(2012, 1, 1), "email", "password"));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenWhiteSpaceEmail()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser("uniqueName", "displayName", new DateTime(2012, 1, 1), " ", "password"));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenWhiteSpacePassword()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser("uniqueName", "displayName", new DateTime(2012, 1, 1), "email", " "));
        }

        [Test]
        public void ShouldThrowNullArgumentExceptionWhenWhiteSpaceUniqueName()
        {
            Assert.Throws<ArgumentNullException>(() => SignupService.CreateUser(" ", "displayName", new DateTime(2012, 1, 1), "email", "password"));
        }
    }
}