using System;

namespace BitReaderWriter.Interfaces
{
    public interface IBitWriter : IDisposable
    {
        void WriteNBits(int n, uint value);
    }
}
