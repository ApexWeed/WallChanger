namespace WallChanger.PNG
{
    class IDATChunk : PNGChunk
    {
        public IDATChunk()
            //       I D A T
            : base(0x49444154u, new byte[] { })
        { }

        public IDATChunk(byte[] Data)
            //       I D A T
            : base(0x49444154u, Data)
        { }
    }
}
