using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaffleTalk.Common.Interfaces.Services.Utilities;

namespace BaffleTalk.Services.Utilities
{
    public class GuidService : IGuidService
    {
        public Guid NewGuid()
        {
            return Guid.NewGuid();
        }
    }
}
