﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        /// <summary>
        /// Gets the format of an image from a stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <returns>The image format of the image.</returns>
        public static ImageFormat GetImageFormat(Stream stream)
        {
            // see http://www.mikekunz.com/image_file_header.html
            var bmp = Encoding.ASCII.GetBytes("BM");       // BMP
            var gif = Encoding.ASCII.GetBytes("GIF");      // GIF
            var png = new byte[]   { 137, 080, 078, 071 }; // PNG
            var tiff = new byte[]  { 073, 073, 042 };      // TIFF
            var tiff2 = new byte[] { 077, 077, 042 };      // TIFF
            var jpeg = new byte[]  { 255, 216, 255, 224 }; // jpeg
            var jpeg2 = new byte[] { 255, 216, 255, 225 }; // jpeg canon
            var jpeg3 = new byte[] { 255, 216, 255, 226 }; // jpeg again
            var jpeg4 = new byte[] { 255, 216, 255, 219 }; // jpeg yet again
            var jpeg5 = new byte[] { 255, 216, 255, 192 }; // more jpeg
            var jpeg6 = new byte[] { 255, 216, 255, 238 }; // even more jpeg
            var jpeg7 = new byte[] { 255, 216, 255, 236 }; // i herd u like jpegs

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

            if (jpeg4.SequenceEqual(buffer.Take(jpeg4.Length)))
                return ImageFormat.jpeg;

            if (jpeg5.SequenceEqual(buffer.Take(jpeg5.Length)))
                return ImageFormat.jpeg;

            if (jpeg6.SequenceEqual(buffer.Take(jpeg6.Length)))
                return ImageFormat.jpeg;

            if (jpeg7.SequenceEqual(buffer.Take(jpeg7.Length)))
                return ImageFormat.jpeg;

            return ImageFormat.unknown;
        }

        /// <summary>
        /// Calculates the correct height for an image.
        /// </summary>
        /// <param name="Image">The image to size.</param>
        /// <param name="PictureBox">The picture box.</param>
        /// <param name="ContainerHeight">The height of the container.</param>
        /// <param name="MinimumDataHeight">The minimum height to leave for data.</param>
        /// <returns>The height for the image.</returns>
        public static int CalculateImageHeight(Image Image, PictureBox PictureBox, int ContainerHeight, int MinimumDataHeight)
        {
            if (Image == null)
                return 202;

            int MaxImageHeight = ContainerHeight - MinimumDataHeight;
            float Ratio = (float)Image.Width / Image.Height;
            int ImageHeight = (int)(PictureBox.Width / Ratio);
            return ImageHeight <= MaxImageHeight ? ImageHeight : MaxImageHeight;
        }

        /// <summary>
        /// Creates an image that does not keep the source file locked.
        /// </summary>
        /// <param name="path">Image path to load.</param>
        /// <returns>The image.</returns>
        public static Image FromFile(string path)
        {
            var bytes = File.ReadAllBytes(path);
            var ms = new MemoryStream(bytes);
            var img = Image.FromStream(ms);
            return img;
        }

        const string errorMessage = "Could not recognise image format.";

        private static Dictionary<byte[], Func<BinaryReader, Size>> imageFormatDecoders = new Dictionary<byte[], Func<BinaryReader, Size>>()
        {
            { new byte[]{ 0x42, 0x4D }, DecodeBitmap},
            { new byte[]{ 0x47, 0x49, 0x46, 0x38, 0x37, 0x61 }, DecodeGif },
            { new byte[]{ 0x47, 0x49, 0x46, 0x38, 0x39, 0x61 }, DecodeGif },
            { new byte[]{ 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, DecodePng },
            { new byte[]{ 0xff, 0xd8 }, DecodeJfif },
        };

        /// <summary>
        /// Gets the dimensions of an image.
        /// </summary>
        /// <param name="path">The path of the image to get the dimensions of.</param>
        /// <returns>The dimensions of the specified image.</returns>
        /// <exception cref="ArgumentException">The image was of an unrecognised format.</exception>
        public static Size GetDimensions(string path)
        {
            using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(path)))
            {
                //try
                //{
                    return GetDimensions(binaryReader);
                /*}
                catch (ArgumentException e)
                {
                    if (e.Message.StartsWith(errorMessage))
                    {
                        throw new ArgumentException(errorMessage, "path", e);
                    }
                    else
                    {
                        throw e;
                    }
                }*/
            }
        }

        /// <summary>
        /// Gets the dimensions of an image.
        /// </summary>
        /// <param name="path">The path of the image to get the dimensions of.</param>
        /// <returns>The dimensions of the specified image.</returns>
        /// <exception cref="ArgumentException">The image was of an unrecognised format.</exception>    
        public static Size GetDimensions(BinaryReader binaryReader)
        {
            int maxMagicBytesLength = imageFormatDecoders.Keys.OrderByDescending(x => x.Length).First().Length;

            byte[] magicBytes = new byte[maxMagicBytesLength];

            for (int i = 0; i < maxMagicBytesLength; i += 1)
            {
                magicBytes[i] = binaryReader.ReadByte();

                foreach (var kvPair in imageFormatDecoders)
                {
                    if (magicBytes.StartsWith(kvPair.Key))
                    {
                        return kvPair.Value(binaryReader);
                    }
                }
            }

            throw new ArgumentException(errorMessage, "binaryReader");
        }

        /// <summary>
        /// Checks if a byte array starts with another byte array.
        /// </summary>
        /// <param name="thisBytes">The array to check.</param>
        /// <param name="thatBytes">The start to check.</param>
        /// <returns>True if thisBytes starts with thatBytes, false if not.</returns>
        private static bool StartsWith(this byte[] thisBytes, byte[] thatBytes)
        {
            for (int i = 0; i < thatBytes.Length; i += 1)
            {
                if (thisBytes[i] != thatBytes[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Reads a little endian 16 bit integer from the stream.
        /// </summary>
        /// <param name="binaryReader">The binary reader to use.</param>
        /// <returns>The short.</returns>
        private static short ReadLittleEndianInt16(this BinaryReader binaryReader)
        {
            byte[] bytes = new byte[sizeof(short)];
            for (int i = 0; i < sizeof(short); i += 1)
            {
                bytes[sizeof(short) - 1 - i] = binaryReader.ReadByte();
            }
            return BitConverter.ToInt16(bytes, 0);
        }

        /// <summary>
        /// Reads a little endian 32 bit integer from the stream.
        /// </summary>
        /// <param name="binaryReader">The binary reader to use.</param>
        /// <returns>The int.</returns>
        private static int ReadLittleEndianInt32(this BinaryReader binaryReader)
        {
            byte[] bytes = new byte[sizeof(int)];
            for (int i = 0; i < sizeof(int); i += 1)
            {
                bytes[sizeof(int) - 1 - i] = binaryReader.ReadByte();
            }
            return BitConverter.ToInt32(bytes, 0);
        }

        /// <summary>
        /// Decodes the width and height of a bitmap.
        /// </summary>
        /// <param name="binaryReader">The binary reader to use.</param>
        /// <returns>The size of the bitmap.</returns>
        private static Size DecodeBitmap(BinaryReader binaryReader)
        {
            binaryReader.ReadBytes(16);
            int width = binaryReader.ReadInt32();
            int height = binaryReader.ReadInt32();
            return new Size(width, height);
        }
        /// <summary>
        /// Decodes the width and height of a gif.
        /// </summary>
        /// <param name="binaryReader">The binary reader to use.</param>
        /// <returns>The size of the gif.</returns>
        private static Size DecodeGif(BinaryReader binaryReader)
        {
            int width = binaryReader.ReadInt16();
            int height = binaryReader.ReadInt16();
            return new Size(width, height);
        }

        /// <summary>
        /// Decodes the width and height of a png.
        /// </summary>
        /// <param name="binaryReader">The binary reader to use.</param>
        /// <returns>The size of the png.</returns>
        private static Size DecodePng(BinaryReader binaryReader)
        {
            binaryReader.ReadBytes(8);
            int width = binaryReader.ReadLittleEndianInt32();
            int height = binaryReader.ReadLittleEndianInt32();
            return new Size(width, height);
        }

        /// <summary>
        /// Decodes the width and height of a jfif.
        /// </summary>
        /// <param name="binaryReader">The binary reader to use.</param>
        /// <returns>The size of the jfif.</returns>
        private static Size DecodeJfif(BinaryReader binaryReader)
        {
            while (binaryReader.ReadByte() == 0xff)
            {
                byte marker = binaryReader.ReadByte();
                short chunkLength = binaryReader.ReadLittleEndianInt16();

                if (marker == 0xc0 || marker == 0xc1 || marker == 0xc2)
                {
                    binaryReader.ReadByte();

                    int height = binaryReader.ReadLittleEndianInt16();
                    int width = binaryReader.ReadLittleEndianInt16();
                    return new Size(width, height);
                }

                binaryReader.ReadBytes(chunkLength - 2);
            }

            throw new ArgumentException(errorMessage);
        }
    }
}
