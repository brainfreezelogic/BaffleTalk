using System;
using BaffleTalk.Common.Interfaces.Services.Utilities;

namespace BaffleTalk.Services.Utilities.Mock
{
    public class MockStaticDateTimeService : IDateTimeService
    {
        private DateTime _referenceDateTime;

        public MockStaticDateTimeService(DateTime referenceDateTime)
        {
            _referenceDateTime = referenceDateTime;
        }

        public DateTime Now { get { return _referenceDateTime; } }
        public DateTime Today { get { return _referenceDateTime.Date; } }
        public DateTime UtcNow { get { return _referenceDateTime.ToUniversalTime(); } }
    }
}
