using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WallChanger
{
    public static class ListExtensions
    {
        /// <summary>
        /// Adds a string to the list if it doesn't exist already.
        /// </summary>
        /// <param name="List">The list to add to.</param>
        /// <param name="Item">The item to add to the list.</param>
        public static void AddDistinct(this List<string> List, string Item)
        {
            foreach (string ListItem in List)
            {
                if (ListItem == Item)
                    return;
            }

            List.Add(Item);
        }

        /// <summary>
        /// Adds a list of strings to a list if they don't exist already.
        /// </summary>
        /// <param name="List">The list to add items to.</param>
        /// <param name="Items">The items to add.</param>
        public static void AddDistinct(this List<string> List, List<string> Items)
        {
            foreach (string Item in Items)
            {
                List.AddDistinct(Item);
            }
        }

        /// <summary>
        /// Adds a library item to the list if it does not already exist.
        /// </summary>
        /// <param name="List">The list to add to.</param>
        /// <param name="Item">The item to add to the list.</param>
        public static void AddDistinct(this List<LibraryItem> List, LibraryItem Item)
        {
            foreach (LibraryItem ListItem in List)
            {
                if (ListItem.Filename == Item.Filename)
                    return;
            }

            List.Add(Item);
        }

        /// <summary>
        /// Adds a list of library items to a list if they do not already exist.
        /// </summary>
        /// <param name="List">The list to add ot.</param>
        /// <param name="Items">The list of library items to add.</param>
        public static void AddDistinct(this List<LibraryItem> List, List<LibraryItem> Items)
        {
            foreach (LibraryItem Item in Items)
            {
                List.AddDistinct(Item);
            }
        }
    }

    public static class DictionaryExtensions
    {
        /// <summary>
        /// Adds an entry to a dictionary if it does not already exist.
        /// </summary>
        /// <param name="Dict">The dictionary to add the item to.</param>
        /// <param name="Key">The key of the item to add.</param>
        /// <param name="Value">The value of the item to add.</param>
        public static void AddDistinct<TKey, TValue>(this Dictionary<TKey, TValue> Dict, TKey Key, TValue Value)
        {
            if (!Dict.ContainsKey(Key))
                Dict.Add(Key, Value);
        }
    }

    public static class ListViewItemExtensions
    {
        /// <summary>
        /// Finds an item in a listview from its tag.
        /// </summary>
        /// <param name="List">The list to search.</param>
        /// <param name="Tag">The tag to check for.</param>
        /// <returns></returns>
        public static ListViewItem FindByTag(this ListView.ListViewItemCollection List, string Tag)
        {
            try
            {
                foreach (ListViewItem item in List)
                {
                    if (item.Tag as string == Tag)
                        return item;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            throw new KeyNotFoundException($"The tag \"{Tag as string}\" was not found in the ListViewItemCollection");
        }
    }

    public static class ComboBoxObjectCollectionExtensions
    {
        /// <summary>
        /// Searches a ComboBoxObjectCollection using the specified predicate.
        /// </summary>
        /// <param name="Collection">The collection to search.</param>
        /// <param name="Pred">The predicate to apply.</param>
        /// <returns>Either the found object or null</returns>
        public static object Find(this System.Windows.Forms.ComboBox.ObjectCollection Collection, Predicate<object> Pred)
        {
            foreach (var Item in Collection)
                if ((bool)Pred?.Invoke(Item))
                    return Item;

            return null;
        }
    }

    public static class StringExtensions
    {
        /// <summary>
        /// Parses a string into an enum.
        /// </summary>
        /// <param name="Value">The string to convert.</param>
        /// <param name="IgnoreCase">Whether to ignore case.</param>
        /// <returns></returns>
        public static T ToEnum<T>(this string Value, bool IgnoreCase = false)
        {
            return (T)Enum.Parse(typeof(T), Value, IgnoreCase);
        }

        public static T ToEnum<T>(this string Value, T DefaultValue, bool IgnoreCase = false) where T : struct
        {
            T parsedValue;
            return Enum.TryParse(Value, IgnoreCase, out parsedValue) ? parsedValue : DefaultValue;
        }
    }

    public static class IntExtentions
    {
        public static int Clamp(this int Value, int Min, int Max)
        {
            if (Value < Min)
                return Min;
            if (Value > Max)
                return Max;
            return Value;
        }
    }

    public static class ImageExtensions
    {
        public static int GetHue(this Image image)
        {
            var hueCounts = new int[360];

            using (var bitmap = new Bitmap(image))
            {
                var bitmapData = bitmap.LockBits(new Rectangle(0, 0, image.Width, image.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                var byteCount = bitmapData.Stride * image.Height;
                var bytes = new byte[byteCount];
                var pixels = image.Width * image.Height;

                System.Runtime.InteropServices.Marshal.Copy(bitmapData.Scan0, bytes, 0, byteCount);

                for (int i = 0; i < pixels; i++)
                {
                    float h, s, v;
                    Utilities.ColourToHSV(Color.FromArgb(bytes[i * 3 + 2], bytes[i * 3 + 1], bytes[i * 3 + 0]), out h, out s, out v);
                    if (s > 0.1 && v > 0.1)
                    {
                        hueCounts[(int)h]++;
                    }
                }

                //System.Threading.Tasks.Parallel.For(0, pixels, (i) =>
                //{
                //    float h, s, v;
                //    Utilities.ColourToHSV(Color.FromArgb(bytes[i * 3 + 2], bytes[i * 3 + 1], bytes[i * 3 + 0]), out h, out s, out v);
                //    if (s > 0.1 && v > 0.1)
                //    {
                //        hueCounts[(int)h]++;
                //    }
                //});

                bitmap.UnlockBits(bitmapData);
            }

            //var total = 0;
            //var totalCount = 0;
            //for (int i = 0; i < 360; i++)
            //{
            //    total += (i + 1) * hueCounts[i];
            //    totalCount += hueCounts[i];
            //}
            //return total / totalCount;

            //var maxIndex = 0;
            //using (var fs = System.IO.File.Open("buttes.txt", System.IO.FileMode.Create))
            //{
            //    using (var w = new System.IO.StreamWriter(fs))
            //    {
            //        for (int i = 0; i < 360; i++)
            //        {
            //            if (hueCounts[i] > hueCounts[maxIndex])
            //                maxIndex = i;
            //        }
            //
            //        System.Diagnostics.Debug.WriteLine(maxIndex);
            //        //return maxIndex;
            //
            //        maxIndex = 0;
            //        var smoothed2 = Smooth2(hueCounts);
            //        for (int i = 0; i < 360; i++)
            //        {
            //            if (smoothed2[i] > smoothed2[maxIndex])
            //                maxIndex = i;
            //        }
            //
            //        System.Diagnostics.Debug.WriteLine(maxIndex);
            //
            //        //maxIndex = 0;
            //        //var smoothed3 = Smooth3(hueCounts);
            //        //for (int i = 0; i < 360; i++)
            //        //{
            //        //    if (smoothed3[i] > smoothed3[maxIndex])
            //        //        maxIndex = i;
            //        //}
            //        //
            //        //System.Diagnostics.Debug.WriteLine(maxIndex);
            //    }
            //}
            //return maxIndex;

            var hue = KMeans.Mean(Smooth2I(hueCounts), 10);

            System.Diagnostics.Debug.WriteLine(hue);
            return hue;
        }

        private static int[] Smooth3(int[] RawData)
        {
            var Smoothed = new int[RawData.Length];
            Smoothed[0] = (RawData[0] + RawData[1]) / 2;
            Smoothed[1] = (RawData[0] + RawData[1] + RawData[2]) / 3;
            Smoothed[RawData.Length - 1] = (RawData[RawData.Length - 2] + RawData[RawData.Length - 1]) / 2;
            Smoothed[RawData.Length - 2] = (RawData[RawData.Length - 3] + RawData[RawData.Length - 2] + RawData[RawData.Length - 1]) / 3;

            for (int i = 2; i < RawData.Length - 2; i++)
            {
                Smoothed[i] = (RawData[i - 2] + RawData[i - 1] + RawData[i] + RawData[i + 1] + RawData[i + 2]) / 5;
            }

            return Smoothed;
        }

        private static int[] Smooth2(int[] RawData)
        {
            var Smoothed = new int[RawData.Length];
            Smoothed[0] = (RawData[0] + RawData[1]) / 2;
            Smoothed[RawData.Length - 1] = (RawData[RawData.Length - 2] + RawData[RawData.Length - 1]) / 2;

            for (int i = 1; i < RawData.Length - 1; i++)
            {
                Smoothed[i] = (RawData[i - 1] + RawData[i] + RawData[i + 1]) / 3;
            }

            return Smoothed;
        }

        private static int[] Smooth2I(int[] RawData)
        {
            var Smoothed = new int[RawData.Length];
            Array.Copy(RawData, Smoothed, RawData.Length);

            for (int i = 1; i < RawData.Length - 1; i++)
            {
                Smoothed[i] = (RawData[i - 1] + RawData[i] + RawData[i + 1]) / 3;
            }

            return Smoothed;
        }
    }
}