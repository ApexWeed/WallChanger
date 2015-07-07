using System.Collections.Generic;

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

        // Cache for image sizes.
        private static Dictionary<string, System.Drawing.Size> imageSizeCache;
        public static Dictionary<string, System.Drawing.Size> ImageSizeCache
        {
            get { return imageSizeCache; }
            set { imageSizeCache = value; }
        }

        // Cache for 16x16 greyscale downscaled images.
        private static Dictionary<string, byte[,]> imageCache;
        public static Dictionary<string, byte[,]> ImageCache
        {
            get { return imageCache; }
            set { imageCache = value; }
        }

        // Only allow one instance of the library at once.
        private static LibraryForm libraryForm;
        public static LibraryForm LibraryForm
        {
            get { return libraryForm; }
            set { libraryForm = value; }
        }

        // Only allow on instance of the duplicate viewer at once.
        private static DuplicateForm duplicateForm;
        public static DuplicateForm DuplicateForm
        {
            get { return duplicateForm; }
            set { duplicateForm = value; }
        }

        // Only allow one instance of the language manager.
        private static LanguageManager languageManager = null;
        public static LanguageManager LanguageManager
            {
                get
                {
                if (languageManager == null)
                    languageManager = new LanguageManager();
                return languageManager;
                }
            }

    }
}
