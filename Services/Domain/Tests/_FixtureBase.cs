using System.Transactions;
using BaffleTalk.Data.Context;
using NUnit.Framework;

namespace BaffleTalk.Services.Domain.Tests
{
    [TestFixture]
    public abstract class _FixtureBase
    {
        protected BaffleTalkContext Context;
        private TransactionScope transaction;

        [TestFixtureSetUp]
        public virtual void TestFixtureSetUp()
        {
            transaction = new TransactionScope();
            Context = new BaffleTalkContext(true);
        }

        [TestFixtureTearDown]
        public virtual void TestFixtureTearDown()
        {
            Context.Dispose();
            transaction.Dispose();
        }
    }
}