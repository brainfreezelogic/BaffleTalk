using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaffleTalk.Common.Interfaces.Services.Utilities
{
    public interface IDeriveKey
    {
        byte[] GetBytes(string password, byte[] salt, int iterations, int byteCount);
    }
}
