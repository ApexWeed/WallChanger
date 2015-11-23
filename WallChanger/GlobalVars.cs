using System.Collections.Generic;
using System.IO;
using WallChanger.Translation;

namespace WallChanger
{
    public static class GlobalVars
    {

        // Only allow one instance of the language manager.
        private static LanguageManager languageManager;
        // The folder that the executable resides in.
        public static string ApplicationPath
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

        // Cache for 16x16 greyscale downscaled images.
        public static Dictionary<string, byte[,]> ImageCache
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
        public static LanguageManager LanguageManager
        {
            get
            {
                if (languageManager == null)
                {
                    try
                    {
                        languageManager = new LanguageManager(Path.Combine(ApplicationPath, "lang"))
                        {
                            MainLanguage = Properties.Settings.Default.Language,
                            FallbackLanguage = Properties.Settings.Default.FallbackLanguage
                        };
                    }
                    catch (FileNotFoundException ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                        languageManager = new LanguageManager(Path.Combine(ApplicationPath, "lang"), true)
                        {
                            MainLanguage = Properties.Settings.Default.Language,
                            FallbackLanguage = Properties.Settings.Default.FallbackLanguage
                        };
                    }
                }
                return languageManager;
            }
        }

        // Only allow one instance of the library at once.
        public static LibraryForm LibraryForm
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

    }
}
