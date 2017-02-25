using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mp3Encode.Encoding
{
    /// <summary>
    /// Encoding types supported by Lame
    /// </summary>
    public enum EncodingType
    {
        Quality = 0,
        AverageBitRate = 1,
        ConstantBitRate = 2,
    }
}
