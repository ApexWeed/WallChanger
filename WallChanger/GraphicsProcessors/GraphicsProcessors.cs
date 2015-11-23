using ImageProcessor;

namespace WallChanger.GraphicsProcessors
{
    public static class GraphicsProcessors
    {
        public static ImageFactory RotateChannels(this ImageFactory factory, int Count)
        {
            if (factory.ShouldProcess)
            {
                var rotateChannels = new RotateChannels { DynamicParameter = Count };
                factory.CurrentImageFormat.ApplyProcessor(rotateChannels.ProcessImage, factory);
            }

            return factory;
        }
    }
}
