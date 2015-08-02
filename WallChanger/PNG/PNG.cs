using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallChanger.PNG
{
    public class PNG
    {
        private static uint[] _CRCTable;
        private static uint[] CRCTable
        {
            get
            {
                if (_CRCTable == null)
                {
                    _CRCTable = new uint[256];
                    for (uint i = 0; i < 256; i++)
                    {
                        var c = i;
                        for (int k = 0; k < 8; k++)
                        {
                            c = (c & 1) != 0 ? 0xedb88320 ^ (c >> 1) : c >> 1;
                        }
                        _CRCTable[i] = c;
                    }
                }
                return _CRCTable;
            }
        }

        public static uint CRC(byte[] Data)
        {
            return CRC(Data, 0xFFFFFFFF) ^ 0xFFFFFFFF;
        }

        public static uint CRC(byte[] Data, uint crc)
        {
            for (int i = 0; i < Data.Length; i++)
            {
                crc = CRCTable[(crc ^ Data[i]) & 0xFF] ^ (crc >> 8);
            }
            return crc;
        }
    }
}
