using System;
using BaffleTalk.Common.Interfaces.Services.Utilities;

namespace BaffleTalk.Services.Utilities.Mock
{
    public class MockGuidService : IGuidService
    {
        private readonly Guid guid;

        public MockGuidService() : this(Guid.NewGuid())
        {
        }

        public MockGuidService(string guid) : this(new Guid(guid))
        {
        }

        public MockGuidService(Guid guid)
        {
            this.guid = guid;
        }

        #region IGuidService Members

        public Guid NewGuid()
        {
            return guid;
        }

        #endregion
    }
}