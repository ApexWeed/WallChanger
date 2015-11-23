using System;
using System.Collections.Generic;
using System.Drawing;
using ImageProcessor;
using ImageProcessor.Common.Exceptions;
using ImageProcessor.Processors;

namespace WallChanger.GraphicsProcessors
{
    public class RotateChannels : IGraphicsProcessor
    {
        public RotateChannels()
        {
            this.Settings = new Dictionary<string, string>();
        }

        public dynamic DynamicParameter
        { get; set; }

        public Dictionary<string, string> Settings
        { get; set; }

        public Image ProcessImage(ImageFactory factory)
        {
            Bitmap newImage = null;
            var image = factory.Image;

            try
            {
                int rotationCount = this.DynamicParameter % 3;
                if (rotationCount <= 0)
                    return image;

                newImage = new Bitmap(image);

                var rect = new Rectangle(0, 0, image.Width, image.Height);
                var bmpData = newImage.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                var ptr = bmpData.Scan0;

                // 32 bit image mode.
                var byteCount = Math.Abs(bmpData.Stride) * image.Height;
                var imageBytes = new byte[byteCount];

                System.Runtime.InteropServices.Marshal.Copy(ptr, imageBytes, 0, byteCount);

                for (int i = 0; i < byteCount / 4; i++)
                {
                    switch (rotationCount)
                    {
                        case 1:
                            {
                                // 0 = 2
                                // 1 = 0
                                // 2 = 1
                                var temp = imageBytes[i * 4 + 0];
                                imageBytes[i * 4 + 0] = imageBytes[i * 4 + 2];
                                imageBytes[i * 4 + 2] = imageBytes[i * 4 + 1];
                                imageBytes[i * 4 + 1] = temp;
                                break;
                            }
                        case 2:
                            {
                                // 0 = 1
                                // 1 = 2
                                // 2 = 0
                                var temp = imageBytes[i * 4 + 0];
                                imageBytes[i * 4 + 0] = imageBytes[i * 4 + 1];
                                imageBytes[i * 4 + 1] = imageBytes[i * 4 + 2];
                                imageBytes[i * 4 + 2] = temp;
                                break;
                            }
                    }
                }

                System.Runtime.InteropServices.Marshal.Copy(imageBytes, 0, ptr, byteCount);

                newImage.UnlockBits(bmpData);

                image.Dispose();
                image = newImage;
            }
            catch (Exception ex)
            {
                if (newImage != null)
                    newImage.Dispose();

                throw new ImageProcessingException($"Error processing image with {this.GetType().Name}", ex);
            }

            return image;
        }
    }
}
