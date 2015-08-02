using System;
using System.IO;

namespace WallChanger.PNG
{
    public class PNGChunk
    {
        protected uint Type;
        protected byte[] Data;

        public PNGChunk(uint Type, byte[] Data)
        {
            this.Type = Type;
            this.Data = Data;
        }

        public byte[] Serialise()
        {
            byte[] Out;
            using (var ms = new MemoryStream())
            {
                using (var w = new MiscUtil.IO.EndianBinaryWriter(MiscUtil.Conversion.EndianBitConverter.Big, ms))
                {
                    w.Write((uint)Data.Length);
                    w.Write(Type);
                    w.Write(Data, 0, Data.Length);
                    // Copy big endian type to start of data to CRC.
                    var FullData = new byte[Data.Length + 4];
                    var Bytes = BitConverter.GetBytes(Type);
                    FullData[3] = Bytes[0];
                    FullData[2] = Bytes[1];
                    FullData[1] = Bytes[2];
                    FullData[0] = Bytes[3];
                    Data.CopyTo(FullData, 4);

                    w.Write(PNG.CRC(FullData));

                    Out = new byte[ms.Length];
                    ms.Seek(0, SeekOrigin.Begin);
                    ms.Read(Out, 0, (int)ms.Length);
                }
            }

            return Out;
        }
    }
}
