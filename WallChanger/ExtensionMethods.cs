using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WallChanger
{
    public static class ListExtensions
    {
        public static void AddDistinct(this List<string> List, string Item)
        {
            foreach (string ListItem in List)
            {
                if (ListItem == Item)
                    return;
            }

            List.Add(Item);
        }

        public static void AddDistinct(this List<string> List, List<string> Items)
        {
            foreach (string Item in Items)
            {
                List.AddDistinct(Item);
            }
        }

        public static void AddDistinct(this List<LibraryItem> List, LibraryItem Item)
        {
            foreach (LibraryItem ListItem in List)
            {
                if (ListItem.Filename == Item.Filename)
                    return;
            }

            List.Add(Item);
        }

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
        public static void AddDistinct(this Dictionary<string, System.Drawing.Size> Dict, string Key, System.Drawing.Size Value)
        {
            if (!Dict.ContainsKey(Key))
                Dict.Add(Key, Value);
        }
    }

    public static class ListViewItemExtensions
    {
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

            throw new KeyNotFoundException(string.Format("The tag \"{0}\" was not found in the ListViewItemCollection", Tag as string));
        }
    }
}