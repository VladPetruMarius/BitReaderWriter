using BitReaderWriter.Interfaces;
using System;
using System.IO;

namespace BitReaderWriter
{
    public class BitReader : IBitReader
    {
        private byte buffer;
        private int numberOfBitsInBuffer;
        private readonly Stream inputStream;

        public BitReader(Stream inputStream)
        {
            this.inputStream = inputStream;
            numberOfBitsInBuffer = 0;
        }

        public int ReadBit()
        {
            if (IsBufferEmpty())
            {
                buffer = (byte)inputStream.ReadByte();
                numberOfBitsInBuffer = 8;
            }

            int result = (buffer >> 7) & 1;

            buffer = (byte)(buffer << 1);
            numberOfBitsInBuffer--;

            return result;
        }

        public uint ReadNBits(int n)
        {
            if (n > 32)
            {
                throw new ArgumentException("Number of bits cannot be greater than 32");
            }

            uint result = 0;
            for (int i = 0; i < n; i++)
            {
                result = (uint)((result << 1) + ReadBit());
            }

            return result;
        }

        public void Dispose()
        {
            inputStream.Dispose();
        }

        private bool IsBufferEmpty()
        {
            return numberOfBitsInBuffer == 0;
        }
    }
}
