namespace WallChanger
{
    public class WallpaperStyleWrapper
    {
        private readonly LanguageManager LM;

        public readonly Wallpaper.WallpaperStyle WallpaperStyle;

        /// <summary>
        /// Create a new wrapper from a wallpaper style.
        /// </summary>
        /// <param name="Style">The style to wrap.</param>
        public WallpaperStyleWrapper(Wallpaper.WallpaperStyle Style)
        {
            this.WallpaperStyle = Style;
            LM = GlobalVars.LanguageManager;
        }

        /// <summary>
        /// Automatic conversion from wrapper to base style object.
        /// </summary>
        /// <param name="Wrapper">The wrapper to unwrap.</param>
        public static implicit operator Wallpaper.WallpaperStyle(WallpaperStyleWrapper Wrapper)
        {
            return Wrapper.WallpaperStyle;
        }

        /// <summary>
        /// Automatica converstion from base style to wrapper object.
        /// </summary>
        /// <param name="Style">The style to wrap.</param>
        public static implicit operator WallpaperStyleWrapper(Wallpaper.WallpaperStyle Style)
        {
            return new WallpaperStyleWrapper(Style);
        }

        /// <summary>
        /// Converts the enumeration value to the translated version.
        /// </summary>
        /// <returns>The translated name.</returns>
        public override string ToString()
        {
            switch (WallpaperStyle)
            {
                case Wallpaper.WallpaperStyle.Fill:
                    return LM.GetString("ENUM_LABEL_WALLPAPER_STYLE_FILL");
                case Wallpaper.WallpaperStyle.Fit:
                    return LM.GetString("ENUM_LABEL_WALLPAPER_STYLE_FIT");
                case Wallpaper.WallpaperStyle.Stretched:
                    return LM.GetString("ENUM_LABEL_WALLPAPER_STYLE_STRETCHED");
                case Wallpaper.WallpaperStyle.Tiled:
                    return LM.GetString("ENUM_LABEL_WALLPAPER_STYLE_TILED");
                case Wallpaper.WallpaperStyle.Centered:
                    return LM.GetString("ENUM_LABEL_WALLPAPER_STYLE_CENTERED");
                case Wallpaper.WallpaperStyle.Span:
                    return LM.GetString("ENUM_LABEL_WALLPAPER_STYLE_SPAN");
                default:
                    return "Unknown wallpaper type.";
            }
        }
    }

    public class CompressionLevelWrapper
    {
        private readonly LanguageManager LM;

        public readonly SevenZip.CompressionLevel CompressionLevel;

        /// <summary>
        /// Create a new wrapper from a compression level object.
        /// </summary>
        /// <param name="Level">The compression level to wrap.</param>
        public CompressionLevelWrapper(SevenZip.CompressionLevel Level)
        {
            this.CompressionLevel = Level;
            LM = GlobalVars.LanguageManager;
        }

        /// <summary>
        /// Automatic conversion from wrapper to base compression level object.
        /// </summary>
        /// <param name="Wrapper">The wrapper to un wrap.</param>
        public static implicit operator SevenZip.CompressionLevel(CompressionLevelWrapper Wrapper)
        {
            return Wrapper.CompressionLevel;
        }

        /// <summary>
        /// Automatic conversion from base compression level to wrapper object.
        /// </summary>
        /// <param name="Level">The compression level to wrap.</param>
        public static implicit operator CompressionLevelWrapper(SevenZip.CompressionLevel Level)
        {
            return new CompressionLevelWrapper(Level);
        }

        /// <summary>
        /// Converts the compression level to the translated version.
        /// </summary>
        /// <returns>The translated version.</returns>
        public override string ToString()
        {
            switch (CompressionLevel)
            {
                case SevenZip.CompressionLevel.None:
                    return LM.GetString("ENUM_LABEL_COMPRESSION_LEVEL_NONE");
                case SevenZip.CompressionLevel.Fast:
                    return LM.GetString("ENUM_LABEL_COMPRESSION_LEVEL_FAST");
                case SevenZip.CompressionLevel.Low:
                    return LM.GetString("ENUM_LABEL_COMPRESSION_LEVEL_LOW");
                case SevenZip.CompressionLevel.Normal:
                    return LM.GetString("ENUM_LABEL_COMPRESSION_LEVEL_NORMAL");
                case SevenZip.CompressionLevel.High:
                    return LM.GetString("ENUM_LABEL_COMPRESSION_LEVEL_HIGH");
                case SevenZip.CompressionLevel.Ultra:
                    return LM.GetString("ENUM_LABEL_COMPRESSION_LEVEL_ULTRA");
                default:
                    return "Unknown compression level.";
            }
        }
    }

    public class HighlightModeWrapper
    {
        private readonly LanguageManager LM;

        public readonly HighlightListBox.HighlightMode_ HighlightMode;

        /// <summary>
        /// Create a new wrapper from a highlight mode object.
        /// </summary>
        /// <param name="Mode">The highlight mode to wrap.</param>
        public HighlightModeWrapper(HighlightListBox.HighlightMode_ Mode)
        {
            HighlightMode = Mode;
            LM = GlobalVars.LanguageManager;
        }

        /// <summary>
        /// Automatic conversion from wrapper to base highlight mode object.
        /// </summary>
        /// <param name="Wrapper">The wrapper to un wrap.</param>
        public static implicit operator HighlightListBox.HighlightMode_(HighlightModeWrapper Wrapper)
        {
            return Wrapper.HighlightMode;
        }

        /// <summary>
        /// Automatic conversion from base highlight mode to wrapper object.
        /// </summary>
        /// <param name="Mode">The highlight mode to wrap.</param>
        public static implicit operator HighlightModeWrapper(HighlightListBox.HighlightMode_ Mode)
        {
            return new HighlightModeWrapper(Mode);
        }

        /// <summary>
        /// Converts the highlight mode to the translated version.
        /// </summary>
        /// <returns>The translated version.</returns>
        public override string ToString()
        {
            switch (HighlightMode)
            {
                case HighlightListBox.HighlightMode_.Bold:
                    return LM.GetString("ENUM_LABEL_HIGHLIGHT_MODE_BOLD");
                case HighlightListBox.HighlightMode_.Italic:
                    return LM.GetString("ENUM_LABEL_HIGHLIGHT_MODE_ITALIC");
                case HighlightListBox.HighlightMode_.Foreground:
                    return LM.GetString("ENUM_LABEL_HIGHLIGHT_MODE_FOREGROUND");
                case HighlightListBox.HighlightMode_.Background:
                    return LM.GetString("ENUM_LABEL_HIGHLIGHT_MODE_BACKGROUND");
                case HighlightListBox.HighlightMode_.None:
                    return LM.GetString("ENUM_LABEL_HIGHLIGHT_MODE_NONE");
                default:
                    return "Unknown highlight mode.";
            }
        }
    }
}
