using WallChanger.Translation;

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
            return LM.GetString("ENUM.LABEL.WALLPAPER_STYLE." + WallpaperStyle.ToString().ToUpper());
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
            return LM.GetString("ENUM.LABEL.COMPRESSION_LEVEL." + CompressionLevel.ToString().ToUpper());
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
            return LM.GetString("ENUM.LABEL.HIGHLIGHT_MODE." + HighlightMode.ToString().ToUpper());
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
            return LM.GetString("ENUM.LABEL.EDGE_DETECTION." + EdgeDetectionFilter.ToString().ToUpper());
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
            return LM.GetString("ENUM.LABEL.FILTER_MATRIX." + ImageFilterMatrix.ToString().ToUpper());
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
            return LM.GetString("ENUM.LABEL.CHANNEL_ROTATION." + ChannelRotation.ToString().ToUpper());
        }
    }
}
