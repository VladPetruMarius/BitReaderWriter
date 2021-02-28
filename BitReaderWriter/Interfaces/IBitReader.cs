﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitReaderWriter.Interfaces
{
    interface IBitReader : IDisposable
    {
        uint ReadNBits(int n);

        int ReadBit();
    }
}
