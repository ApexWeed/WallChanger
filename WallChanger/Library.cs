using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace WallChanger
{
    public static class Library
    {
        private static Mutex FileMutex = new Mutex();

        public static void Save()
        {
            if (FileMutex.WaitOne(1))
            {
                //byte[,] Test = new byte[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
                //byte[,] Test2 = Expand(Flatten(Test), 4);
                //MessageBox.Show(string.Format("{0}\n{1}", ArrayToString(Test), ArrayToString(Test2)));

                using (FileStream stream = File.Open(GlobalVars.ApplicationPath + "\\library.cfg", FileMode.Create))
                {
                    using (StreamWriter write = new StreamWriter(stream))
                    {
                        write.Write(Newtonsoft.Json.JsonConvert.SerializeObject(GlobalVars.LibraryItems));
                    }
                }

                using (FileStream stream = File.Open(GlobalVars.ApplicationPath + "\\sizecache.cfg", FileMode.Create))
                {
                    using (StreamWriter write = new StreamWriter(stream))
                    {
                        write.Write(Newtonsoft.Json.JsonConvert.SerializeObject(GlobalVars.ImageSizeCache));
                    }
                }

                using (FileStream stream = File.Open(GlobalVars.ApplicationPath + "\\imagecache.dat", FileMode.Create))
                {
                    using (BinaryWriter write = new BinaryWriter(stream))
                    {
                        write.Write(GlobalVars.ImageCache.Count);
                        foreach (var Item in GlobalVars.ImageCache)
                        {
                            write.Write(Item.Key);
                            write.Write(Flatten(Item.Value));
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

                if (File.Exists(GlobalVars.ApplicationPath + "\\library.cfg"))
                {
                    using (StreamReader read = new StreamReader(GlobalVars.ApplicationPath + "\\library.cfg"))
                    {
                        GlobalVars.LibraryItems = Newtonsoft.Json.JsonConvert.DeserializeObject<List<LibraryItem>>(read.ReadLine());
                    }
                }

                GlobalVars.ImageSizeCache = new Dictionary<string, System.Drawing.Size>();

                if (File.Exists(GlobalVars.ApplicationPath + "\\sizecache.cfg"))
                {
                    using (StreamReader read = new StreamReader(GlobalVars.ApplicationPath + "\\sizecache.cfg"))
                    {
                        GlobalVars.ImageSizeCache = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, System.Drawing.Size>>(read.ReadLine());
                    }
                }

                GlobalVars.ImageCache = new Dictionary<string, byte[,]>();

                if (File.Exists(GlobalVars.ApplicationPath + "\\imagecache.dat"))
                {
                    using (FileStream stream = File.Open(GlobalVars.ApplicationPath + "\\imagecache.dat", FileMode.Open))
                    {
                        using (BinaryReader read = new BinaryReader(stream))
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
