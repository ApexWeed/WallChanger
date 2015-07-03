using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace WallChanger
{
    public static class Library
    {
        private static Mutex FileMutex = new Mutex();
        private static ArrayComparer<byte> byteComparer = new ArrayComparer<byte>();
        
        public static void Save()
        {
            if (FileMutex.WaitOne(1))
            {
                using (FileStream fs = File.Open(Path.Combine(GlobalVars.ApplicationPath, "library.dat"), FileMode.Create))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (StreamWriter w = new StreamWriter(ms))
                        {
                            w.Write(Newtonsoft.Json.JsonConvert.SerializeObject(GlobalVars.LibraryItems));
                            w.Flush();

                            SevenZip.SevenZipCompressor compresser = new SevenZip.SevenZipCompressor();
                            compresser.CompressionMethod = SevenZip.CompressionMethod.Lzma2;
                            compresser.CompressionLevel = Properties.Settings.Default.CompressionLevel;
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

                            SevenZip.SevenZipCompressor compresser = new SevenZip.SevenZipCompressor();
                            compresser.CompressionMethod = SevenZip.CompressionMethod.Lzma2;
                            compresser.CompressionLevel = Properties.Settings.Default.CompressionLevel;
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

                            SevenZip.SevenZipCompressor compresser = new SevenZip.SevenZipCompressor();
                            compresser.CompressionMethod = SevenZip.CompressionMethod.Lzma2;
                            compresser.CompressionLevel = Properties.Settings.Default.CompressionLevel;
                            compresser.CompressStream(ms, fs);
                        }
                    }
                }
                FileMutex.ReleaseMutex();
            }
        }

        private static string ArrayToString(byte[,] Input)
        {
            int Columns = Input.GetLength(0);
            int Rows = Input.GetLength(1);

            string[] Bits = new string[Columns];
            for (int x = 0; x < Columns; x++)
            {
                byte[] SingleDimension = new byte[Rows];
                for (int y = 0; y < Rows; y++)
                {
                    SingleDimension[y] = Input[x, y];
                }
                Bits[x] = ArrayToString(SingleDimension);
            }

            return string.Format("{{{0}}}", string.Join(" ", Bits));
        }

        private static string ArrayToString(byte[] Input)
        {
            return string.Format("{{{0}}}", string.Join(" ", Input));
        }

        private static byte[] Flatten(byte[,] Input)
        {
            int Columns = Input.GetLength(0);
            int Rows = Input.GetLength(1);

            byte[] Out = new byte[Input.Length];

            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    Out[x * Rows + y] = Input[x, y];
                }
            }

            return Out;
        }

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
                            byte[] buffer = new byte[2];
                            fs.Read(buffer, 0, 2);
                            fs.Seek(0, SeekOrigin.Begin);
                            if (byteComparer.Compare(buffer, new byte[] { 0x37, 0x7A }) == 0)
                            {
                                SevenZip.SevenZipExtractor extractor = new SevenZip.SevenZipExtractor(fs);
                                extractor.ExtractFile(0, ms);
                                ms.Seek(0, SeekOrigin.Begin);
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
                            byte[] buffer = new byte[2];
                            fs.Read(buffer, 0, 2);
                            fs.Seek(0, SeekOrigin.Begin);
                            if (byteComparer.Compare(buffer, new byte[] { 0x37, 0x7A }) == 0)
                            {
                                SevenZip.SevenZipExtractor extractor = new SevenZip.SevenZipExtractor(fs);
                                extractor.ExtractFile(0, ms);
                                ms.Seek(0, SeekOrigin.Begin);
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
                            byte[] buffer = new byte[2];
                            fs.Read(buffer, 0, 2);
                            fs.Seek(0, SeekOrigin.Begin);
                            if (byteComparer.Compare(buffer, new byte[] { 0x37, 0x7A }) == 0)
                            {
                                SevenZip.SevenZipExtractor extractor = new SevenZip.SevenZipExtractor(fs);
                                extractor.ExtractFile(0, ms);
                                ms.Seek(0, SeekOrigin.Begin);
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
                            byte[] buffer = new byte[2];
                            fs.Read(buffer, 0, 2);
                            fs.Seek(0, SeekOrigin.Begin);
                            if (byteComparer.Compare(buffer, new byte[] { 0x37, 0x7A }) == 0)
                            {
                                SevenZip.SevenZipExtractor extractor = new SevenZip.SevenZipExtractor(fs);
                                extractor.ExtractFile(0, ms);
                                ms.Seek(0, SeekOrigin.Begin);
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
                            byte[] buffer = new byte[2];
                            fs.Read(buffer, 0, 2);
                            fs.Seek(0, SeekOrigin.Begin);
                            if (byteComparer.Compare(buffer, new byte[] { 0x37, 0x7A }) == 0)
                            {
                                SevenZip.SevenZipExtractor extractor = new SevenZip.SevenZipExtractor(fs);
                                extractor.ExtractFile(0, ms);
                                ms.Seek(0, SeekOrigin.Begin);
                            }
                            else
                            {
                                fs.CopyTo(ms);
                                ms.Seek(0, SeekOrigin.Begin);
                            }

                            using (BinaryReader read = new BinaryReader(ms))
                            {
                                int ImageCount = read.ReadInt32();
                                for (int i = 0; i < ImageCount; i++)
                                {
                                    string ImagePath = read.ReadString();
                                    byte[] Image = read.ReadBytes(256);
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

        private static byte[,] Expand(byte[] Input, int Columns)
        {
            byte[,] Out = new byte[Columns, Input.Length / Columns];

            for (int i = 0; i < Input.Length; i++)
            {
                Out[i / (Columns), i % (Input.Length / Columns)] = Input[i];
            }

            return Out;
        }
    }
}
