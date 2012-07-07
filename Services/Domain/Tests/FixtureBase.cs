using BaffleTalk.Data.Context;
using NUnit.Framework;

namespace BaffleTalk.Services.Domain.Tests
{
    [TestFixture]
    public abstract class FixtureBase
    {
        protected BaffleTalkContext Context;

        public virtual void TestFixtureSetUp()
        {
            Context = new BaffleTalkContext();
        }
    }
}