using System;

namespace BitReaderWriter.Interfaces
{
    public interface IBitReader : IDisposable
    {
        uint ReadNBits(int n);

        int ReadBit();
    }
}
