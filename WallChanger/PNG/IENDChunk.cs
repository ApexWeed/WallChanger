namespace WallChanger.PNG
{
    class IENDChunk : PNGChunk
    {
        public IENDChunk()
            //       I E N D
            : base(0x49454E44u, new byte[] { })
        { }
    }
}
