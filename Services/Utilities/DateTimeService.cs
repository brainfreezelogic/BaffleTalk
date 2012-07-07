using System;
using BaffleTalk.Common.Interfaces.Services.Utilities;

namespace BaffleTalk.Services.Utilities
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
        
        public DateTime Today
        {
            get { return DateTime.Today; }
        }
        
        public DateTime UtcNow
        {
            get { return DateTime.UtcNow; }
        }
    }
}
