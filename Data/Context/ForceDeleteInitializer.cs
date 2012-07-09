using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaffleTalk.Data.Context
{
    public class ForceDeleteInitializer : IDatabaseInitializer<BaffleTalkContext>
    {
        private readonly IDatabaseInitializer<BaffleTalkContext> initializer;

        public ForceDeleteInitializer(IDatabaseInitializer<BaffleTalkContext> innerInitializer)
        {
            initializer = innerInitializer;
        }

        public void InitializeDatabase(BaffleTalkContext context)
        {
            context.Database.ExecuteSqlCommand("ALTER DATABASE BaffleTalk SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
            initializer.InitializeDatabase(context);
        }
    }
}
