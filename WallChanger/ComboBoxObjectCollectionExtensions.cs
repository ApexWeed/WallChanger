using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallChanger
{
    public static class ComboBoxObjectCollectionExtensions
    {
        public static object Find(this System.Windows.Forms.ComboBox.ObjectCollection Collection, Predicate<object> Pred)
        {
            foreach (var Item in Collection)
                if (Pred(Item))
                    return Item;

            return null;
        }
    }
}
