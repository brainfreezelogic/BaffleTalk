using System;
using BaffleTalk.Common.Interfaces.Services.Utilities;

namespace BaffleTalk.Services.Utilities
{
    public class GuidService : IGuidService
    {
        #region IGuidService Members

        public Guid NewGuid()
        {
            return Guid.NewGuid();
        }

        #endregion
    }
}