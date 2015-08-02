using System;

namespace WallChanger.PNG
{
    class PLTEChunk : PNGChunk
    {
        public PLTEChunk()
            //       P L T E
            : base(0x504C5445u, new byte[] { })
        {
            throw new NotImplementedException();
        }
    }
}
