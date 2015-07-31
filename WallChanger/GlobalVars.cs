using System.Collections.Generic;

namespace WallChanger
{
    public static class GlobalVars
    {
        // The folder that the executable resides in.
        public static string ApplicationPath
        {
            get;
            set;
        }

        // List that stores all the information of the library.
        public static List<LibraryItem> LibraryItems
        {
            get;
            set;
        }

        // Cache for image sizes.
        public static Dictionary<string, System.Drawing.Size> ImageSizeCache
        {
            get;
            set;
        }

        // Cache for 16x16 greyscale downscaled images.
        public static Dictionary<string, byte[,]> ImageCache
        {
            get;
            set;
        }

        // Only allow one instance of the library at once.
        public static LibraryForm LibraryForm
        {
            get;
            set;
        }

        // Only allow on instance of the duplicate viewer at once.
        public static DuplicateForm DuplicateForm
        {
            get;
            set;
        }

        // Only allow one instance of the language manager.
        private static LanguageManager languageManager;
        public static LanguageManager LanguageManager
            {
                get
                {
                if (languageManager == null)
                {
                    try
                    {
                        languageManager = new LanguageManager();
                    }
                    catch (System.IO.FileNotFoundException ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                        languageManager = new LanguageManager(true);
                    }
                }
                return languageManager;
                }
            }

    }
}
