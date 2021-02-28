using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitReaderWriter.Interfaces
{
    public interface IBitWriter : IDisposable
    {
        void WriteNBits(int n, uint value);
    }
}
