using BitReaderWriter.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitReaderWriter
{
    public class BitWriter : IBitWriter
    {
        private byte buffer;
        private int numberOfBitsInBuffer;
        private readonly Stream outputStream;

        public BitWriter(Stream outputStream)
        {
            this.outputStream = outputStream;
            numberOfBitsInBuffer = 0;
        }

        public void WriteNBits(int n, uint value)
        {
            if (n > 32)
            {
                throw new ArgumentException("Number of write bits cannot be greater than 32");
            }

            value <<= (32 - n);
            for (int i = 0; i < n; i++)
            {
                uint bit = (value >> 31) & 1;
                value <<= 1;
                WriteBit((int)bit);
            }
        }

        public void Dispose()
        {
            Flush();
            outputStream.Dispose();
        }

        private void WriteBit(int value)
        {
            buffer = (byte)((buffer << 1) + (value & 1));
            numberOfBitsInBuffer++;

            if (IsBufferFull())
            {
                outputStream.WriteByte(buffer);
                numberOfBitsInBuffer = 0;
            }
        }

        private bool IsBufferFull()
        {
            return numberOfBitsInBuffer == 8;
        }

        private void Flush()
        {
            if (numberOfBitsInBuffer == 0)
                return;

            buffer = (byte)(buffer << (8 - numberOfBitsInBuffer));
            outputStream.WriteByte(buffer);
            numberOfBitsInBuffer = 0;
        }
    }
}
