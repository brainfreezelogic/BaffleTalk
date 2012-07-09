using System;
using System.Linq;
using BaffleTalk.Data.Entities.Membership;
using NUnit.Framework;

namespace BaffleTalk.Services.Domain.Tests.SignupServiceTests
{
    [TestFixture]
    public class CreateUser_ByEmail : SignupServiceTests._FixtureBase
    {
        private User expectedUser;
        private string expectedPlainTextPassword;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            expectedUser = new User
                               {
                                   UniqueName = "uniqueGuy",
                                   DisplayName = "Unique Guy",
                                   BirthDate = new DateTime(1990, 1, 20),
                                   Email = "uniqueguy@gmail.com",
                                   DateCreated = DateTimeService.UtcNow,
                                   PasswordHash = "somehash",
                                   PasswordSalt = "somesalt"
                               };
            expectedPlainTextPassword = "somepassword";
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
        public void ValidParametersShouldMapUniqueNameProperly()
        {
            var actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, expectedUser.Email, expectedPlainTextPassword);

            Assert.AreEqual(expectedUser.UniqueName, actualUser.UniqueName);
        }

        [Test]
        public void ValidParametersShouldMapDisplayNameProperly()
        {
            var actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, expectedUser.Email, expectedPlainTextPassword);

            Assert.AreEqual(expectedUser.DisplayName, actualUser.DisplayName);
        }

        [Test]
        public void ValidParametersShouldMapBirthDateProperly()
        {
            var actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, expectedUser.Email, expectedPlainTextPassword);

            Assert.AreEqual(expectedUser.BirthDate, actualUser.BirthDate);
        }

        [Test]
        public void ValidParametersShouldMapEmailProperly()
        {
            var actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, expectedUser.Email, expectedPlainTextPassword);

            Assert.AreEqual(expectedUser.Email, actualUser.Email);
        }

        [Test]
        public void ValidParametersShouldMapDateCreatedToUtcNow()
        {
            var actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, expectedUser.Email, expectedPlainTextPassword);

            Assert.AreEqual(DateTimeService.UtcNow, actualUser.DateCreated);
        }

        [Test]
        public void ValidParametersShouldCreateUserIdAfterSave()
        {
            var actualUser = SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, expectedUser.Email, expectedPlainTextPassword);
            Context.SaveChanges();

            Assert.AreNotEqual(0, actualUser.Id);
        }

        [Test]
        public void ValidParametersShouldIncrementUserCountByOne()
        {
            var expected = Context.Users.Count() + 1;

            SignupService.CreateUser(expectedUser.UniqueName, expectedUser.DisplayName, expectedUser.BirthDate, expectedUser.Email, expectedPlainTextPassword);
            Context.SaveChanges();

            var actual = Context.Users.Count();

            Assert.AreEqual(expected, actual);
        }
    }
}
