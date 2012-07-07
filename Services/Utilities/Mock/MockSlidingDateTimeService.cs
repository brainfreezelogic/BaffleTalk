using System;
using BaffleTalk.Common.Interfaces.Services.Utilities;

namespace BaffleTalk.Services.Utilities.Mock
{
    public class MockSlidingDateTimeService : IDateTimeService
    {
        private DateTime _referenceDateTime;
        private readonly DateTime _referenceNow;

        public MockSlidingDateTimeService(DateTime referenceDateTime)
        {
            _referenceDateTime = referenceDateTime;
            _referenceNow = DateTime.Now;
        }

        public DateTime Now { get { return _referenceDateTime.Add(DateTime.Now.Subtract(_referenceNow)); } }
        public DateTime Today { get { return this.Now.Date; } }
        public DateTime UtcNow { get { return this.Now.ToUniversalTime(); } }

    }
}
