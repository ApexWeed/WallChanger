using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace XnaFan.ImageComparison
{
    public static class ExtensionMethods
    {


#pragma warning disable CC0033 // Dispose Fields Properly
                              //the font to use for the DifferenceImages
        private static readonly Font DefaultFont = new Font("Arial", 8);
#pragma warning restore CC0033 // Dispose Fields Properly

        //the brushes to use for the DifferenceImages
        private static readonly Brush[] brushes = new Brush[256];

        //Create the brushes in varying intensities
        static ExtensionMethods()
        {
            for (int i = 0; i < 256; i++)
            {
                brushes[i] = new SolidBrush(Color.FromArgb(255, i, i / 3, i / 2));
            }
        }


        //the colormatrix needed to grayscale an image
        //http://www.switchonthecode.com/tutorials/csharp-tutorial-convert-a-color-image-to-grayscale
        static readonly ColorMatrix ColorMatrix = new ColorMatrix(new float[][]
        {
            new float[] {.3f, .3f, .3f, 0, 0},
            new float[] {.59f, .59f, .59f, 0, 0},
            new float[] {.11f, .11f, .11f, 0, 0},
            new float[] {0, 0, 0, 1, 0},
            new float[] {0, 0, 0, 0, 1}
        });

        /// <summary>
        /// Gets the difference between two images as a percentage
        /// </summary>
        /// <param name="img1">The first image</param>
        /// <param name="img2">The image to compare to</param>
        /// <param name="threshold">How big a difference (out of 255) will be ignored - the default is 3.</param>
        /// <returns>The difference between the two images as a percentage</returns>
        public static float PercentageDifference(this Image img1, Image img2, byte threshold = 3)
        {
            var differences = img1.GetDifferences(img2);

            var diffPixels = 0;

            foreach (byte b in differences)
            {
                if (b > threshold) { diffPixels++; }
            }

            return diffPixels / 256f;
        }

        public static byte[,] Difference(this byte[,] array1, byte[,] array2)
        {
            var differences = new byte[16, 16];
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    differences[x, y] = (byte)Math.Abs(array1[x, y] - array2[x, y]);
                }
            }
            return differences;
        }

        public static int Compare(this Tuple<string, byte[,]> a, Tuple<string, byte[,]> b, int Tolerance)
        {
            var Difference = a.Item2.Difference(b.Item2);
            var Different = 0;
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    if (Difference[x, y] > Tolerance)
                        Different++;
                }
            }
            return Different;
        }

        /// <summary>
        /// The Bhattacharyya difference (the difference between normalized versions of the histograms of both images)
        /// This tells something about the differences in the brightness of the images as a whole, not so much about where they differ.
        /// </summary>
        /// <param name="img1">The first image to compare</param>
        /// <param name="img2">The second image to compare</param>
        /// <returns>The difference between the images' normalized histograms</returns>
        public static float BhattacharyyaDifference(this Image img1, Image img2)
        {
            var img1GrayscaleValues = img1.GetGrayScaleValues();
            var img2GrayscaleValues = img2.GetGrayScaleValues();

            var normalizedHistogram1 = new double[16, 16];
            var normalizedHistogram2 = new double[16, 16];

            var histSum1 = 0.0;
            var histSum2 = 0.0;

            foreach (var value in img1GrayscaleValues) { histSum1 += value; }
            foreach (var value in img2GrayscaleValues) { histSum2 += value; }


            for (int x = 0; x < img1GrayscaleValues.GetLength(0); x++)
            {
                for (int y = 0; y < img1GrayscaleValues.GetLength(1); y++)
                {
                    normalizedHistogram1[x, y] = (double)img1GrayscaleValues[x, y] / histSum1;
                }
            }
            for (int x = 0; x < img2GrayscaleValues.GetLength(0); x++)
            {
                for (int y = 0; y < img2GrayscaleValues.GetLength(1); y++)
                {
                    normalizedHistogram2[x, y] = (double)img2GrayscaleValues[x, y] / histSum2;
                }
            }

            var bCoefficient = 0.0;
            for (int x = 0; x < img2GrayscaleValues.GetLength(0); x++)
            {
                for (int y = 0; y < img2GrayscaleValues.GetLength(1); y++)
                {
                    var histSquared = normalizedHistogram1[x, y] * normalizedHistogram2[x, y];
                    bCoefficient += Math.Sqrt(histSquared);
                }
            }

            var dist1 = 1.0 - bCoefficient;
            dist1 = Math.Round(dist1, 8);
            var distance = Math.Sqrt(dist1);
            distance = Math.Round(distance, 8);
            return (float)distance;

        }


        /// <summary>
        /// Gets an image which displays the differences between two images
        /// </summary>
        /// <param name="img1">The first image</param>
        /// <param name="img2">The image to compare with</param>
        /// <param name="adjustColorSchemeToMaxDifferenceFound">Whether to adjust the color indicating maximum difference (usually 255) to the maximum difference found in this case.
        /// E.g. if the maximum difference found is 12, then a true value in adjustColorSchemeToMaxDifferenceFound would result in 0 being black, 6 being dark pink, and 12 being bright pink.
        /// A false value would still have differences of 255 as bright pink resulting in the 12 difference still being very dark.</param>
        /// <param name="absoluteText">todo: describe absoluteText parameter on GetDifferenceImage</param>
        /// <returns>an image which displays the differences between two images</returns>
        public static Bitmap GetDifferenceImage(this Image img1, Image img2, bool adjustColorSchemeToMaxDifferenceFound = false, bool absoluteText = false)
        {
            //create a 16x16 tiles image with information about how much the two images differ
            const int cellsize = 16;  //each tile is 16 pixels wide and high
            var bmp = new Bitmap(16 * cellsize + 1, 16 * cellsize + 1); //16 blocks * 16 pixels + a borderpixel at left/bottom

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.FillRectangle(Brushes.Black, 0, 0, bmp.Width, bmp.Height);
                var differences = img1.GetDifferences(img2);
                byte maxDifference = 255;

                //if wanted - adjust the color scheme, by finding the new maximum difference
                if (adjustColorSchemeToMaxDifferenceFound)
                {
                    maxDifference = 0;
                    foreach (byte b in differences)
                    {
                        if (b > maxDifference)
                        {
                            maxDifference = b;
                        }
                    }

                    if (maxDifference == 0)
                    {
                        maxDifference = 1;
                    }
                }

                DrawDifferencesToBitmap(absoluteText, cellsize, g, differences, maxDifference);
            }
            return bmp;
        }

        private static void DrawDifferencesToBitmap(bool absoluteText, int cellsize, Graphics g, byte[,] differences, byte maxDifference)
        {
            for (int y = 0; y < differences.GetLength(1); y++)
            {
                for (int x = 0; x < differences.GetLength(0); x++)
                {
                    var cellValue = differences[x, y];
                    string cellText = null;

                    cellText = absoluteText ? cellValue.ToString() : $"{(int)cellValue}%";

                    var percentageDifference = (float)differences[x, y] / maxDifference;
                    var colorIndex = (int)(255 * percentageDifference);

                    g.FillRectangle(brushes[colorIndex], x * cellsize, y * cellsize, cellsize, cellsize);
                    g.DrawRectangle(Pens.Blue, x * cellsize, y * cellsize, cellsize, cellsize);
                    var size = g.MeasureString(cellText, DefaultFont);
                    g.DrawString(cellText, DefaultFont, Brushes.Black, x * cellsize + cellsize / 2 - size.Width / 2 + 1, y * cellsize + cellsize / 2 - size.Height / 2 + 1);
                    g.DrawString(cellText, DefaultFont, Brushes.White, x * cellsize + cellsize / 2 - size.Width / 2, y * cellsize + cellsize / 2 - size.Height / 2);
                }
            }
        }


        /// <summary>
        /// Finds the differences between two images and returns them in a doublearray
        /// </summary>
        /// <param name="img1">The first image</param>
        /// <param name="img2">The image to compare with</param>
        /// <returns>the differences between the two images as a doublearray</returns>
        public static byte[,] GetDifferences(this Image img1, Image img2)
        {
            var thisOne = (Bitmap)img1.Resize(16, 16).GetGrayScaleVersion();
            var theOtherOne = (Bitmap)img2.Resize(16, 16).GetGrayScaleVersion();
            var differences = new byte[16, 16];
            var firstGray = thisOne.GetGrayScaleValues();
            var secondGray = theOtherOne.GetGrayScaleValues();

            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    differences[x, y] = (byte)Math.Abs(firstGray[x, y] - secondGray[x, y]);
                }
            }
            thisOne.Dispose();
            theOtherOne.Dispose();
            return differences;
        }

        /// <summary>
        /// Gets the lightness of the image in 256 sections (16x16)
        /// </summary>
        /// <param name="img">The image to get the lightness for</param>
        /// <returns>A doublearray (16x16) containing the lightness of the 256 sections</returns>
        public static byte[,] GetGrayScaleValues(this Image img)
        {
            using (Bitmap thisOne = (Bitmap)img.Resize(16, 16).GetGrayScaleVersion())
            {
                var grayScale = new byte[16, 16];

                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        grayScale[x, y] = (byte)Math.Abs(thisOne.GetPixel(x, y).R);
                    }
                }
                return grayScale;
            }
        }


        /// <summary>
        /// Converts an image to grayscale
        /// </summary>
        /// <param name="original">The image to grayscale</param>
        /// <returns>A grayscale version of the image</returns>
        public static Image GetGrayScaleVersion(this Image original)
        {
#pragma warning disable CC0022 // Should dispose object
                              //http://www.switchonthecode.com/tutorials/csharp-tutorial-convert-a-color-image-to-grayscale
                              //create a blank bitmap the same size as original
            var newBitmap = new Bitmap(original.Width, original.Height);
#pragma warning restore CC0022 // Should dispose object

            //get a graphics object from the new image
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                //create some image attributes
                var attributes = new ImageAttributes();

                //set the color matrix attribute
                attributes.SetColorMatrix(ColorMatrix);

                //draw the original image on the new image
                //using the grayscale color matrix
                g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                   0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
                attributes.Dispose();
            }
            return newBitmap;

        }

        /// <summary>
        /// Resizes an image
        /// </summary>
        /// <param name="originalImage">The image to resize</param>
        /// <param name="newWidth">The new width in pixels</param>
        /// <param name="newHeight">The new height in pixels</param>
        /// <returns>A resized version of the original image</returns>
        public static Image Resize(this Image originalImage, int newWidth, int newHeight)
        {
            Image smallVersion = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(smallVersion))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }

            return smallVersion;
        }

        /// <summary>
        /// Helpermethod to print a doublearray of
        /// </summary>
        /// <typeparam name="T">The type of doublearray</typeparam>
        /// <param name="doubleArray">The doublearray to print</param>
        public static void ToConsole<T>(this T[,] doubleArray)
        {
            for (int y = 0; y < doubleArray.GetLength(0); y++)
            {
                Console.Write("[");
                for (int x = 0; x < doubleArray.GetLength(1); x++)
                {
                    Console.Write($"{doubleArray[x, y],3},");
                }
                Console.WriteLine("]");
            }
        }

        /// <summary>
        /// Gets a bitmap with the RGB histograms of a bitmap
        /// </summary>
        /// <param name="bmp">The bitmap to get the histogram for</param>
        /// <returns>A bitmap with the histogram for R, G and B values</returns>
        public static Bitmap GetRgbHistogramBitmap(this Bitmap bmp)
        {
            return new Histogram(bmp).Visualize();
        }

        /// <summary>
        /// Get a histogram for a bitmap
        /// </summary>
        /// <param name="bmp">The bitmap to get the histogram for</param>
        /// <returns>A histogram for the bitmap</returns>
        public static Histogram GetRgbHistogram(this Bitmap bmp)
        {
            return new Histogram(bmp);
        }

    }
}
