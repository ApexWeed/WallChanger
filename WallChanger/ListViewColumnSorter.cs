using System.Collections;
using System.Windows.Forms;

namespace WallChanger
{
    /// <summary>
    /// This class is an implementation of the 'IComparer' interface.
    /// </summary>
    public class ListViewColumnSorter : IComparer
    {
        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private readonly CaseInsensitiveComparer ObjectCompare;

        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            SortColumn = 0;

            // Initialize the sort order to 'none'
            Order = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public SortOrder Order
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn
        {
            get;
            set;
        }

        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            compareResult = SortColumn == 1 || SortColumn == 2 ? Compare(int.Parse(listviewX.SubItems[SortColumn].Text), int.Parse(listviewY.SubItems[SortColumn].Text)) : ObjectCompare.Compare(listviewX.SubItems[SortColumn].Text, listviewY.SubItems[SortColumn].Text);

            // Calculate correct return value based on object comparison
            return Order == SortOrder.Ascending ? compareResult : Order == SortOrder.Descending ? (-compareResult) : 0;
        }

        private static int Compare(int x, int y)
        {
            if (x < y)
                return -1;
            if (x > y)
                return 1;
            return 0;
        }

    }
}