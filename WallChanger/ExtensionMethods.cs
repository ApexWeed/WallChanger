using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallChanger
{
    public static class LibraryItemListExstensions
    {
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

    public static class StringListExtensions
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
    }
}