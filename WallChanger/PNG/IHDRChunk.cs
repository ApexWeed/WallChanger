using System;

namespace WallChanger.PNG
{
    public class IHDRChunk : PNGChunk
    {
        public enum PNGColourType : byte
        {
            Greyscale = 0,
            RGB24bpp = 2,
            Pallette = 3,
            GreyscaleAlpha = 4,
            RGBA32bpp = 6
        }

        public enum PNGCompressionType : byte
        {
            Inflate = 0
        }

        public enum PNGFilterMode : byte
        {
            Adaptive = 0
        }

        public enum PNGInterlaceMethod : byte
        {
            None = 0,
            Adam7 = 1
        }

        public uint Width
        {
            get
            {
                var Bytes = new byte[4];
                Bytes[3] = Data[0];
                Bytes[2] = Data[1];
                Bytes[1] = Data[2];
                Bytes[0] = Data[3];
                return BitConverter.ToUInt32(Bytes, 0);
            }
            set
            {
                var Bytes = BitConverter.GetBytes(value);
                Data[0] = Bytes[3];
                Data[1] = Bytes[2];
                Data[2] = Bytes[1];
                Data[3] = Bytes[0];
            }
        }
        public uint Height
        {
            get
            {
                var Bytes = new byte[4];
                Bytes[4] = Data[0];
                Bytes[5] = Data[1];
                Bytes[6] = Data[2];
                Bytes[7] = Data[3];
                return BitConverter.ToUInt32(Bytes, 0);
            }
            set
            {
                var Bytes = BitConverter.GetBytes(value);
                Data[4] = Bytes[3];
                Data[5] = Bytes[2];
                Data[6] = Bytes[1];
                Data[7] = Bytes[0];
            }
        }
        public byte BitDepth
        {
            get { return Data[8]; }
            set { Data[8] = value; }
        }
        public PNGColourType ColourType
        {
            get { return (PNGColourType)Data[9]; }
            set { Data[9] = (byte)value; }
        }
        public PNGCompressionType CompressionType
        {
            get { return (PNGCompressionType)Data[10]; }
            set { Data[10] = (byte)value; }
        }
        public PNGFilterMode FilterMethod
        {
            get { return (PNGFilterMode)Data[11]; }
            set { Data[11] = (byte)value; }
        }
        public PNGInterlaceMethod InterlaceMethod
        {
            get { return (PNGInterlaceMethod)Data[12]; }
            set { Data[12] = (byte)value; }
        }

        public IHDRChunk()
            //       I H D R
            : base(0x49484452u, new byte[13])
        { }

        public IHDRChunk(uint Width, uint Height, byte BitDepth, PNGColourType ColourType, PNGCompressionType CompressionType, PNGFilterMode FilterMethod, PNGInterlaceMethod InterlaceMethod)
            //       I H D R
            : base(0x49484452u, new byte[13])
        {
            this.Width = Width;
            this.Height = Height;
            this.BitDepth = BitDepth;
            this.ColourType = ColourType;
            this.CompressionType = CompressionType;
            this.FilterMethod = FilterMethod;
            this.InterlaceMethod = InterlaceMethod;
        }
    }
}
