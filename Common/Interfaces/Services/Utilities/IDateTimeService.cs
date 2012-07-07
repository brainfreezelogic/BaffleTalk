using System;

namespace BaffleTalk.Common.Interfaces.Services.Utilities
{
    public interface IDateTimeService
    {
        DateTime Now { get; }
        DateTime Today { get; }
        DateTime UtcNow { get; }
    }
}
