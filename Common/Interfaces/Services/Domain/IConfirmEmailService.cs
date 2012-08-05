using System;

namespace BaffleTalk.Common.Interfaces.Services.Domain
{
    public interface IConfirmEmailService
    {
        void ConfirmEmail(Guid confirmationGuid);
    }
}