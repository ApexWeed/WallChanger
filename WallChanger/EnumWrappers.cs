namespace WallChanger
{
    public enum EdgeDetectionFilter
    {
        KayyaliEdgeFilter,
        KirschEdgeFilter,
        Laplacian3X3EdgeFilter,
        Laplacian5X5EdgeFilter,
        LaplacianOfGaussianEdgeFilter,
        PrewittEdgeFilter,
        RobertsEdgeFilter,
        SharrEdgeFilter,
        SobelEdgeFilter
    }

    public enum ImageFilterMatrix
    {
        BlackWhite,
        Comic,
        Gotham,
        GreyScale,
        HiSatch,
        Invert,
        Lomograph,
        LoSatch,
        Polaroid,
        Sepia
    }

    public enum ChannelRotation
    {
        RotateOnce = 1,
        RotateTwice = 2
    }

    public class WallpaperStyleWrapper
    {

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

        public readonly Wallpaper.WallpaperStyle WallpaperStyle;
        private readonly LanguageManager LM;

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
        /// Converts the enumeration value to the translated version.
        /// </summary>
        /// <returns>The translated name.</returns>
        public override string ToString()
        {
            switch (WallpaperStyle)
            {
                case Wallpaper.WallpaperStyle.Fill:
                    return LM.GetString("ENUM.LABEL.WALLPAPER_STYLE.FILL");
                case Wallpaper.WallpaperStyle.Fit:
                    return LM.GetString("ENUM.LABEL.WALLPAPER_STYLE.FIT");
                case Wallpaper.WallpaperStyle.Stretched:
                    return LM.GetString("ENUM.LABEL.WALLPAPER_STYLE.STRETCHED");
                case Wallpaper.WallpaperStyle.Tiled:
                    return LM.GetString("ENUM.LABEL.WALLPAPER_STYLE.TILED");
                case Wallpaper.WallpaperStyle.Centered:
                    return LM.GetString("ENUM.LABEL.WALLPAPER_STYLE.CENTERED");
                case Wallpaper.WallpaperStyle.Span:
                    return LM.GetString("ENUM.LABEL.WALLPAPER_STYLE.SPAN");
                default:
                    return LM.GetString("ENUM.LABEL.WALLPAPER_STYLE.UNKNOWN");
            }
        }
    }

    public class CompressionLevelWrapper
    {

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

        public readonly SevenZip.CompressionLevel CompressionLevel;
        private readonly LanguageManager LM;

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
        /// Converts the compression level to the translated version.
        /// </summary>
        /// <returns>The translated version.</returns>
        public override string ToString()
        {
            switch (CompressionLevel)
            {
                case SevenZip.CompressionLevel.None:
                    return LM.GetString("ENUM.LABEL.COMPRESSION_LEVEL.NONE");
                case SevenZip.CompressionLevel.Fast:
                    return LM.GetString("ENUM.LABEL.COMPRESSION_LEVEL.FAST");
                case SevenZip.CompressionLevel.Low:
                    return LM.GetString("ENUM.LABEL.COMPRESSION_LEVEL.LOW");
                case SevenZip.CompressionLevel.Normal:
                    return LM.GetString("ENUM.LABEL.COMPRESSION_LEVEL.NORMAL");
                case SevenZip.CompressionLevel.High:
                    return LM.GetString("ENUM.LABEL.COMPRESSION_LEVEL.HIGH");
                case SevenZip.CompressionLevel.Ultra:
                    return LM.GetString("ENUM.LABEL.COMPRESSION_LEVEL.ULTRA");
                default:
                    return LM.GetString("ENUM.LABEL.COMPRESSION_LEVEL.UNKNOWN");
            }
        }
    }

    public class HighlightModeWrapper
    {

        /// <summary>
        /// Automatic conversion from wrapper to base highlight mode object.
        /// </summary>
        /// <param name="Wrapper">The wrapper to un wrap.</param>
        public static implicit operator HighlightListBox.HighlightMode(HighlightModeWrapper Wrapper)
        {
            return Wrapper.HighlightMode;
        }

        /// <summary>
        /// Automatic conversion from base highlight mode to wrapper object.
        /// </summary>
        /// <param name="Mode">The highlight mode to wrap.</param>
        public static implicit operator HighlightModeWrapper(HighlightListBox.HighlightMode Mode)
        {
            return new HighlightModeWrapper(Mode);
        }

        public readonly HighlightListBox.HighlightMode HighlightMode;
        private readonly LanguageManager LM;

        /// <summary>
        /// Create a new wrapper from a highlight mode object.
        /// </summary>
        /// <param name="Mode">The highlight mode to wrap.</param>
        public HighlightModeWrapper(HighlightListBox.HighlightMode Mode)
        {
            HighlightMode = Mode;
            LM = GlobalVars.LanguageManager;
        }

        /// <summary>
        /// Converts the highlight mode to the translated version.
        /// </summary>
        /// <returns>The translated version.</returns>
        public override string ToString()
        {
            switch (HighlightMode)
            {
                case HighlightListBox.HighlightMode.Bold:
                    return LM.GetString("ENUM.LABEL.HIGHLIGHT_MODE.BOLD");
                case HighlightListBox.HighlightMode.Italic:
                    return LM.GetString("ENUM.LABEL.HIGHLIGHT_MODE.ITALIC");
                case HighlightListBox.HighlightMode.Foreground:
                    return LM.GetString("ENUM.LABEL.HIGHLIGHT_MODE.FOREGROUND");
                case HighlightListBox.HighlightMode.Background:
                    return LM.GetString("ENUM.LABEL.HIGHLIGHT_MODE.BACKGROUND");
                case HighlightListBox.HighlightMode.None:
                    return LM.GetString("ENUM.LABEL.HIGHLIGHT_MODE.NONE");
                default:
                    return LM.GetString("ENUM.LABEL.HIGHLIGHT_MODE.UNKNOWN");
            }
        }
    }

    public class EdgeDetectionFilterWrapper
    {

        /// <summary>
        /// Automatic conversion from wrapper to base edge detection filter object.
        /// </summary>
        /// <param name="Wrapper">The wrapper to unwrap.</param>
        public static implicit operator EdgeDetectionFilter(EdgeDetectionFilterWrapper Wrapper)
        {
            return Wrapper.EdgeDetectionFilter;
        }

        /// <summary>
        /// Automatic conversion from base edge detection filter to wrapper.
        /// </summary>
        /// <param name="Filter">The edge detection filter to wrap.</param>
        public static implicit operator EdgeDetectionFilterWrapper(EdgeDetectionFilter Filter)
        {
            return new EdgeDetectionFilterWrapper(Filter);
        }

        public readonly EdgeDetectionFilter EdgeDetectionFilter;
        private readonly LanguageManager LM;

        /// <summary>
        /// Create a new wrapper from a edge detection filter.
        /// </summary>
        /// <param name="Filter">The edge detection filter to wrap.</param>
        public EdgeDetectionFilterWrapper(EdgeDetectionFilter Filter)
        {
            EdgeDetectionFilter = Filter;
            LM = GlobalVars.LanguageManager;
        }

        /// <summary>
        /// Converts the edge detection filter to the translated version.
        /// </summary>
        /// <returns>The translated version.</returns>
        public override string ToString()
        {
            switch (EdgeDetectionFilter)
            {
                case EdgeDetectionFilter.KayyaliEdgeFilter:
                    return LM.GetString("ENUM.LABEL.EDGE_DETECTION.KAYYALI");
                case EdgeDetectionFilter.KirschEdgeFilter:
                    return LM.GetString("ENUM.LABEL.EDGE_DETECTION.KIRSCH");
                case EdgeDetectionFilter.Laplacian3X3EdgeFilter:
                    return LM.GetString("ENUM.LABEL.EDGE_DETECTION.LAP3X3");
                case EdgeDetectionFilter.Laplacian5X5EdgeFilter:
                    return LM.GetString("ENUM.LABEL.EDGE_DETECTION.LAP5X5");
                case EdgeDetectionFilter.LaplacianOfGaussianEdgeFilter:
                    return LM.GetString("ENUM.LABEL.EDGE_DETECTION.LAPGAU");
                case EdgeDetectionFilter.PrewittEdgeFilter:
                    return LM.GetString("ENUM.LABEL.EDGE_DETECTION.PREWITT");
                case EdgeDetectionFilter.RobertsEdgeFilter:
                    return LM.GetString("ENUM.LABEL.EDGE_DETECTION.ROBERTS");
                case EdgeDetectionFilter.SharrEdgeFilter:
                    return LM.GetString("ENUM.LABEL.EDGE_DETECTION.SHARR");
                case EdgeDetectionFilter.SobelEdgeFilter:
                    return LM.GetString("ENUM.LABEL.EDGE_DETECTION.SOBEL");
                default:
                    return LM.GetString("ENUM.LABEL.EDGE_DETECTION.UNKNOWN");
            }
        }
    }

    public class ImageFilterMatrixWrapper
    {

        /// <summary>
        /// Automatic conversion wrapper to base image filter matrix.
        /// </summary>
        /// <param name="Wrapper">The wrapper to unwrap.</param>
        public static implicit operator ImageFilterMatrix(ImageFilterMatrixWrapper Wrapper)
        {
            return Wrapper.ImageFilterMatrix;
        }

        /// <summary>
        /// Automatic conversion from base image filter matrix to wrapper.
        /// </summary>
        /// <param name="Matrix">The image filter matrix to wrap.</param>
        public static implicit operator ImageFilterMatrixWrapper(ImageFilterMatrix Matrix)
        {
            return new ImageFilterMatrixWrapper(Matrix);
        }

        public readonly ImageFilterMatrix ImageFilterMatrix;
        private readonly LanguageManager LM;

        /// <summary>
        /// Creates a new wrapper from an image filter matrix.
        /// </summary>
        /// <param name="Matrix">The image filter matrix to wrap.</param>
        public ImageFilterMatrixWrapper(ImageFilterMatrix Matrix)
        {
            LM = GlobalVars.LanguageManager;
            ImageFilterMatrix = Matrix;
        }

        /// <summary>
        /// Converts the image filter matrix to the translated version.
        /// </summary>
        /// <returns>The translated version.</returns>
        public override string ToString()
        {
            switch (ImageFilterMatrix)
            {
                case ImageFilterMatrix.BlackWhite:
                    return LM.GetString("ENUM.LABEL.FILTER_MATRIX.BLACKWHITE");
                case ImageFilterMatrix.Comic:
                    return LM.GetString("ENUM.LABEL.FILTER_MATRIX.COMIC");
                case ImageFilterMatrix.Gotham:
                    return LM.GetString("ENUM.LABEL.FILTER_MATRIX.GOTHAM");
                case ImageFilterMatrix.GreyScale:
                    return LM.GetString("ENUM.LABEL.FILTER_MATRIX.GREYSCALE");
                case ImageFilterMatrix.HiSatch:
                    return LM.GetString("ENUM.LABEL.FILTER_MATRIX.HISATCH");
                case ImageFilterMatrix.Invert:
                    return LM.GetString("ENUM.LABEL.FILTER_MATRIX.INVERT");
                case ImageFilterMatrix.Lomograph:
                    return LM.GetString("ENUM.LABEL.FILTER_MATRIX.LOMOGRAPH");
                case ImageFilterMatrix.LoSatch:
                    return LM.GetString("ENUM.LABEL.FILTER_MATRIX.LOSATCH");
                case ImageFilterMatrix.Polaroid:
                    return LM.GetString("ENUM.LABEL.FILTER_MATRIX.POLAROID");
                case ImageFilterMatrix.Sepia:
                    return LM.GetString("ENUM.LABEL.FILTER_MATRIX.SEPIA");
                default:
                    return LM.GetString("ENUM.LABEL.FILTER_MATRIX.UNKNOWN");
            }
        }
    }

    public class ChannelRotationWrapper
    {

        /// <summary>
        /// Automatic converstion from wrapper to base channel rotation object.
        /// </summary>
        /// <param name="wrapper">The wrapper to unwrap.</param>
        public static implicit operator ChannelRotation(ChannelRotationWrapper wrapper)
        {
            return wrapper.ChannelRotation;
        }

        /// <summary>
        /// Auomatic conversion from base channel rotation object to wrapper.
        /// </summary>
        /// <param name="rotation">The channel rotation object to wrap.</param>
        public static implicit operator ChannelRotationWrapper(ChannelRotation rotation)
        {
            return new ChannelRotationWrapper(rotation);
        }
        public readonly ChannelRotation ChannelRotation;
        private readonly LanguageManager LM;

        /// <summary>
        /// Creates a new wrapper from a channel rotation object.
        /// </summary>
        /// <param name="rotation">The channel rotation object to wrap.</param>
        public ChannelRotationWrapper(ChannelRotation rotation)
        {
            this.ChannelRotation = rotation;
            LM = GlobalVars.LanguageManager;
        }

        /// <summary>
        /// Converts the channel rotation to the translated version.
        /// </summary>
        /// <returns>The translated version.</returns>
        public override string ToString()
        {
            switch (ChannelRotation)
            {
                case ChannelRotation.RotateOnce:
                    return LM.GetString("ENUM.LABEL.CHANNEL_ROTATION.ONCE");
                case ChannelRotation.RotateTwice:
                    return LM.GetString("ENUM.LABEL.CHANNEL_ROTATION.TWICE");
                default:
                    return LM.GetString("ENUM.LABEL.CHANNEL_ROTATION.UNKNOWN");
            }
        }
    }
}
