using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallChanger
{
    public static class GlobalVars
    {
        // The folder that the executable resides in.
        private static string applicationPath;
        public static string ApplicationPath
        {
            get { return applicationPath; }
            set { applicationPath = value; }
        }

        // List that stores all the information of the library.
        private static List<LibraryItem> libraryItems;
        public static List<LibraryItem> LibraryItems
        {
            get { return libraryItems; }
            set { libraryItems = value; }
        }

        // Only allow one instance of the libray at once.
        private static LibraryForm libraryForm;
        public static LibraryForm LibraryForm
        {
            get { return libraryForm; }
            set { libraryForm = value; }
        }
    }
}
