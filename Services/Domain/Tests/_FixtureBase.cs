using System;
using System.Transactions;
using BaffleTalk.Common.Interfaces.Services.Utilities;
using BaffleTalk.Data.Context;
using BaffleTalk.Services.Utilities.Mock;
using NUnit.Framework;

namespace BaffleTalk.Services.Domain.Tests
{
    [TestFixture]
    public abstract class _FixtureBase
    {
        protected BaffleTalkContext Context;
        protected IDateTimeService DateTimeService;
        private TransactionScope transaction;

        [SetUp]
        public virtual void SetUp()
        {
            transaction = new TransactionScope();
            Context = new BaffleTalkContext(true);

            DateTimeService = new MockStaticDateTimeService(new DateTime(2012, 7, 8, 14, 23, 29));
        }

        [TearDown]
        public virtual void TestFixtureTearDown()
        {
            Context.Dispose();
            transaction.Dispose();
        }
    }
}