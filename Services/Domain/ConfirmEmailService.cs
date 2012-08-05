using System;
using System.Linq;
using BaffleTalk.Common.Exceptions;
using BaffleTalk.Common.Interfaces.Services.Domain;
using BaffleTalk.Common.Interfaces.Services.Utilities;
using BaffleTalk.Data.Context;

namespace BaffleTalk.Services.Domain
{
    public class ConfirmEmailService : IConfirmEmailService
    {
        private readonly BaffleTalkContext context;
        private readonly IDateTimeService dateTimeService;

        public ConfirmEmailService(BaffleTalkContext context, IDateTimeService dateTimeService)
        {
            this.context = context;
            this.dateTimeService = dateTimeService;
        }

        #region IConfirmEmailService Members

        public void ConfirmEmail(Guid confirmationGuid)
        {
            var userEmailConfirmation = (from confirmation in context.UserEmailConfirmations where confirmation.Id == confirmationGuid select confirmation).SingleOrDefault();

            if (userEmailConfirmation == null)
            {
                throw new ValidationException("That confirmation is not valid.");
            }

            if (userEmailConfirmation.DateConfirmed != null)
            {
                throw new ValidationException("That confirmation has already been fulfilled.");
            }

            userEmailConfirmation.DateConfirmed = dateTimeService.UtcNow;
            userEmailConfirmation.User.Email = userEmailConfirmation.Email;
        }

        #endregion
    }
}