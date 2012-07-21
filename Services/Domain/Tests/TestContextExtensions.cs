using System.Data.Entity.Validation;
using System.Linq;
using BaffleTalk.Data.Context;
using NUnit.Framework;

namespace BaffleTalk.Services.Domain.Tests
{
    public static class TestContextExtensions
    {
        public static void SaveChangesWithCatch(this BaffleTalkContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                Assert.Fail(string.Join("\n", ex.EntityValidationErrors.SelectMany(e => e.ValidationErrors.Select(ve => ve.PropertyName + " - " + ve.ErrorMessage))));
            }
        }
    }
}