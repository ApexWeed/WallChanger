using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace WallChanger
{
    public static class Imaging
    {
        public enum ImageFormat
        {
            bmp,
            jpeg,
            gif,
            tiff,
            png,
            unknown
        }

        public static ImageFormat GetImageFormat(Stream stream)
        {
            // see http://www.mikekunz.com/image_file_header.html
            var bmp = Encoding.ASCII.GetBytes("BM");       // BMP
            var gif = Encoding.ASCII.GetBytes("GIF");      // GIF
            var png = new byte[] { 137, 80, 78, 71 };      // PNG
            var tiff = new byte[] { 73, 73, 42 };          // TIFF
            var tiff2 = new byte[] { 77, 77, 42 };         // TIFF
            var jpeg = new byte[] { 255, 216, 255, 224 };  // jpeg
            var jpeg2 = new byte[] { 255, 216, 255, 225 }; // jpeg canon
            var jpeg3 = new byte[] { 255, 216, 255, 219 }; // jpeg again

            var buffer = new byte[4];
            stream.Read(buffer, 0, buffer.Length);

            if (bmp.SequenceEqual(buffer.Take(bmp.Length)))
                return ImageFormat.bmp;

            if (gif.SequenceEqual(buffer.Take(gif.Length)))
                return ImageFormat.gif;

            if (png.SequenceEqual(buffer.Take(png.Length)))
                return ImageFormat.png;

            if (tiff.SequenceEqual(buffer.Take(tiff.Length)))
                return ImageFormat.tiff;

            if (tiff2.SequenceEqual(buffer.Take(tiff2.Length)))
                return ImageFormat.tiff;

            if (jpeg.SequenceEqual(buffer.Take(jpeg.Length)))
                return ImageFormat.jpeg;

            if (jpeg2.SequenceEqual(buffer.Take(jpeg2.Length)))
                return ImageFormat.jpeg;

            if (jpeg3.SequenceEqual(buffer.Take(jpeg3.Length)))
                return ImageFormat.jpeg;

            return ImageFormat.unknown;
        }

        public static int CalculateImageHeight(Image Image, PictureBox PictureBox, int ContainerHeight, int MinimumDataHeight)
        {
            if (Image == null)
                return 202;

            int MaxImageHeight = ContainerHeight - MinimumDataHeight;
            float Ratio = (float)Image.Width / (float)Image.Height;
            int ImageHeight = (int)(PictureBox.Width / Ratio);
            return ImageHeight <= MaxImageHeight ? ImageHeight : MaxImageHeight;
        }

        public static Image FromFile(string path)
        {
            var bytes = File.ReadAllBytes(path);
            var ms = new MemoryStream(bytes);
            var img = Image.FromStream(ms);
            return img;
        }
    }
}
