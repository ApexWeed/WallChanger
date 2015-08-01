using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace WallChanger
{
    public static class Library
    {
        private static readonly ArrayComparer<byte> byteComparer = new ArrayComparer<byte>();
        // Cannot dispose a static class.
#pragma warning disable CC0033 // Dispose Fields Properly
        private static readonly Mutex FileMutex = new Mutex();
#pragma warning restore CC0033 // Dispose Fields Properly

        /// <summary>
        /// Loads the library data from disk.
        /// </summary>
        public static void Load()
        {
            if (FileMutex.WaitOne(1))
            {
                GlobalVars.LibraryItems = new List<LibraryItem>();

                if (File.Exists(Path.Combine(GlobalVars.ApplicationPath, "library.dat")))
                {
                    using (FileStream fs = File.Open(Path.Combine(GlobalVars.ApplicationPath, "library.dat"), FileMode.Open))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            // Look for 7zip signature
                            var buffer = new byte[2];
                            fs.Read(buffer, 0, 2);
                            fs.Seek(0, SeekOrigin.Begin);
                            if (byteComparer.Compare(buffer, new byte[] { 0x37, 0x7A }) == 0)
                            {
                                using (var extractor = new SevenZip.SevenZipExtractor(fs))
                                {
                                    extractor.ExtractFile(0, ms);
                                    ms.Seek(0, SeekOrigin.Begin);
                                }
                            }
                            else
                            {
                                fs.CopyTo(ms);
                                ms.Seek(0, SeekOrigin.Begin);
                            }

                            using (StreamReader read = new StreamReader(ms))
                            {
                                GlobalVars.LibraryItems = Newtonsoft.Json.JsonConvert.DeserializeObject<List<LibraryItem>>(read.ReadLine());
                            }
                        }
                    }
                }
                // Legacy file path.
                else if (File.Exists(Path.Combine(GlobalVars.ApplicationPath, "library.cfg")))
                {
                    using (FileStream fs = File.Open(Path.Combine(GlobalVars.ApplicationPath, "library.cfg"), FileMode.Open))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            // Look for 7zip signature
                            var buffer = new byte[2];
                            fs.Read(buffer, 0, 2);
                            fs.Seek(0, SeekOrigin.Begin);
                            if (byteComparer.Compare(buffer, new byte[] { 0x37, 0x7A }) == 0)
                            {
                                using (var extractor = new SevenZip.SevenZipExtractor(fs))
                                {
                                    extractor.ExtractFile(0, ms);
                                    ms.Seek(0, SeekOrigin.Begin);
                                }
                            }
                            else
                            {
                                fs.CopyTo(ms);
                                ms.Seek(0, SeekOrigin.Begin);
                            }

                            using (StreamReader read = new StreamReader(ms))
                            {
                                GlobalVars.LibraryItems = Newtonsoft.Json.JsonConvert.DeserializeObject<List<LibraryItem>>(read.ReadLine());
                            }
                        }
                    }
                    // Remove old file.
                    File.Delete(Path.Combine(GlobalVars.ApplicationPath, "library.cfg"));
                }

                GlobalVars.ImageSizeCache = new Dictionary<string, System.Drawing.Size>();

                if (File.Exists(Path.Combine(GlobalVars.ApplicationPath, "sizecache.dat")))
                {
                    using (FileStream fs = File.Open(Path.Combine(GlobalVars.ApplicationPath, "sizecache.dat"), FileMode.Open))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            // Look for 7zip signature
                            var buffer = new byte[2];
                            fs.Read(buffer, 0, 2);
                            fs.Seek(0, SeekOrigin.Begin);
                            if (byteComparer.Compare(buffer, new byte[] { 0x37, 0x7A }) == 0)
                            {
                                using (var extractor = new SevenZip.SevenZipExtractor(fs))
                                {
                                    extractor.ExtractFile(0, ms);
                                    ms.Seek(0, SeekOrigin.Begin);
                                }
                            }
                            else
                            {
                                fs.CopyTo(ms);
                                ms.Seek(0, SeekOrigin.Begin);
                            }

                            using (StreamReader read = new StreamReader(ms))
                            {
                                GlobalVars.ImageSizeCache = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, System.Drawing.Size>>(read.ReadLine());
                            }
                        }
                    }
                }
                // Legacy file path.
                else if (File.Exists(Path.Combine(GlobalVars.ApplicationPath, "sizecache.cfg")))
                {
                    using (FileStream fs = File.Open(Path.Combine(GlobalVars.ApplicationPath, "sizecache.cfg"), FileMode.Open))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            // Look for 7zip signature
                            var buffer = new byte[2];
                            fs.Read(buffer, 0, 2);
                            fs.Seek(0, SeekOrigin.Begin);
                            if (byteComparer.Compare(buffer, new byte[] { 0x37, 0x7A }) == 0)
                            {
                                using (var extractor = new SevenZip.SevenZipExtractor(fs))
                                {
                                    extractor.ExtractFile(0, ms);
                                    ms.Seek(0, SeekOrigin.Begin);
                                }
                            }
                            else
                            {
                                fs.CopyTo(ms);
                                ms.Seek(0, SeekOrigin.Begin);
                            }

                            using (StreamReader read = new StreamReader(ms))
                            {
                                GlobalVars.ImageSizeCache = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, System.Drawing.Size>>(read.ReadLine());
                            }
                        }
                    }
                    // Remove old file.
                    File.Delete(Path.Combine(GlobalVars.ApplicationPath, "sizecache.cfg"));
                }

                GlobalVars.ImageCache = new Dictionary<string, byte[,]>();

                if (File.Exists(Path.Combine(GlobalVars.ApplicationPath, "imagecache.dat")))
                {
                    using (FileStream fs = File.Open(Path.Combine(GlobalVars.ApplicationPath, "imagecache.dat"), FileMode.Open))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            // Look for 7zip signature
                            var buffer = new byte[2];
                            fs.Read(buffer, 0, 2);
                            fs.Seek(0, SeekOrigin.Begin);
                            if (byteComparer.Compare(buffer, new byte[] { 0x37, 0x7A }) == 0)
                            {
                                using (var extractor = new SevenZip.SevenZipExtractor(fs))
                                {
                                    extractor.ExtractFile(0, ms);
                                    ms.Seek(0, SeekOrigin.Begin);
                                }
                            }
                            else
                            {
                                fs.CopyTo(ms);
                                ms.Seek(0, SeekOrigin.Begin);
                            }

                            using (BinaryReader read = new BinaryReader(ms))
                            {
                                var ImageCount = read.ReadInt32();
                                for (int i = 0; i < ImageCount; i++)
                                {
                                    var ImagePath = read.ReadString();
                                    var Image = read.ReadBytes(256);
                                    GlobalVars.ImageCache.Add(ImagePath, Expand(Image, 16));
                                }
                            }
                        }
                    }
                }

                if (GlobalVars.LibraryForm != null)
                {
                    GlobalVars.LibraryForm.UpdateList();
                }
                FileMutex.ReleaseMutex();
            }
        }

        /// <summary>
        /// Saves the library content to disk.
        /// </summary>
        public static void Save()
        {
            if (FileMutex.WaitOne(1))
            {
                if (Properties.Settings.Default.CompressionLevel == SevenZip.CompressionLevel.None)
                {
                    using (FileStream fs = File.Open(Path.Combine(GlobalVars.ApplicationPath, "library.dat"), FileMode.Create))
                    {
                        using (StreamWriter w = new StreamWriter(fs))
                        {
                            w.Write(Newtonsoft.Json.JsonConvert.SerializeObject(GlobalVars.LibraryItems));
                            w.Flush();
                        }
                    }

                    using (FileStream fs = File.Open(Path.Combine(GlobalVars.ApplicationPath, "sizecache.dat"), FileMode.Create))
                    {
                        using (StreamWriter w = new StreamWriter(fs))
                        {
                            w.Write(Newtonsoft.Json.JsonConvert.SerializeObject(GlobalVars.ImageSizeCache));
                            w.Flush();
                        }
                    }

                    using (FileStream fs = File.Open(Path.Combine(GlobalVars.ApplicationPath, "imagecache.dat"), FileMode.Create))
                    {
                        using (BinaryWriter w = new BinaryWriter(fs))
                        {
                            w.Write(GlobalVars.ImageCache.Count);
                            foreach (var Item in GlobalVars.ImageCache)
                            {
                                w.Write(Item.Key);
                                w.Write(Flatten(Item.Value));
                            }
                            w.Flush();
                        }
                    }
                }
                else
                {
                    using (FileStream fs = File.Open(Path.Combine(GlobalVars.ApplicationPath, "library.dat"), FileMode.Create))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (StreamWriter w = new StreamWriter(ms))
                            {
                                w.Write(Newtonsoft.Json.JsonConvert.SerializeObject(GlobalVars.LibraryItems));
                                w.Flush();

                                var compresser = new SevenZip.SevenZipCompressor
                                {
                                    CompressionMethod = SevenZip.CompressionMethod.Lzma2,
                                    CompressionLevel = Properties.Settings.Default.CompressionLevel
                                };
                                compresser.CompressStream(ms, fs);
                            }
                        }
                    }

                    using (FileStream fs = File.Open(Path.Combine(GlobalVars.ApplicationPath, "sizecache.dat"), FileMode.Create))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (StreamWriter w = new StreamWriter(ms))
                            {
                                w.Write(Newtonsoft.Json.JsonConvert.SerializeObject(GlobalVars.ImageSizeCache));
                                w.Flush();

                                var compresser = new SevenZip.SevenZipCompressor
                                {
                                    CompressionMethod = SevenZip.CompressionMethod.Lzma2,
                                    CompressionLevel = Properties.Settings.Default.CompressionLevel
                                };
                                compresser.CompressStream(ms, fs);
                            }
                        }
                    }

                    using (FileStream fs = File.Open(Path.Combine(GlobalVars.ApplicationPath, "imagecache.dat"), FileMode.Create))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (BinaryWriter w = new BinaryWriter(ms))
                            {
                                w.Write(GlobalVars.ImageCache.Count);
                                foreach (var Item in GlobalVars.ImageCache)
                                {
                                    w.Write(Item.Key);
                                    w.Write(Flatten(Item.Value));
                                }
                                w.Flush();

                                var compresser = new SevenZip.SevenZipCompressor
                                {
                                    CompressionMethod = SevenZip.CompressionMethod.Lzma2,
                                    CompressionLevel = Properties.Settings.Default.CompressionLevel
                                };
                                compresser.CompressStream(ms, fs);
                            }
                        }
                    }
                }
                FileMutex.ReleaseMutex();
            }
        }

        /// <summary>
        /// Converts a two dimensional array to a string.
        /// </summary>
        /// <param name="Input">The array to stringify.</param>
        /// <returns>The string representation.</returns>
        private static string ArrayToString<T>(T[,] Input)
        {
            var Columns = Input.GetLength(0);
            var Rows = Input.GetLength(1);

            var Bits = new string[Columns];
            for (int x = 0; x < Columns; x++)
            {
                var SingleDimension = new T[Rows];
                for (int y = 0; y < Rows; y++)
                {
                    SingleDimension[y] = Input[x, y];
                }
                Bits[x] = ArrayToString(SingleDimension);
            }

            return $"{{{string.Join(" ", Bits)}}}";
        }

        /// <summary>
        /// Converts a one dimensional array to a string.
        /// </summary>
        /// <param name="Input">The array to stringify.</param>
        /// <returns>The string representation.</returns>
        private static string ArrayToString<T>(T[] Input)
        {
            return $"{{{string.Join(" ", Input)}}}";
        }

        /// <summary>
        /// Expands a one dimensional array to two dimensions.
        /// </summary>
        /// <param name="Input">The one dimensional array.</param>
        /// <param name="Columns">The number of columns in the new array.</param>
        /// <returns>The two dimensional array.</returns>
        private static T[,] Expand<T>(T[] Input, int Columns)
        {
            var Out = new T[Columns, Input.Length / Columns];

            for (int i = 0; i < Input.Length; i++)
            {
                Out[i / (Columns), i % (Input.Length / Columns)] = Input[i];
            }

            return Out;
        }

        /// <summary>
        /// Converts a two dimensional array to one dimension.
        /// </summary>
        /// <param name="Input">The two dimensional array to convert</param>
        /// <returns></returns>
        private static T[] Flatten<T>(T[,] Input)
        {
            var Columns = Input.GetLength(0);
            var Rows = Input.GetLength(1);

            var Out = new T[Input.Length];

            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    Out[x * Rows + y] = Input[x, y];
                }
            }

            return Out;
        }
    }
}
