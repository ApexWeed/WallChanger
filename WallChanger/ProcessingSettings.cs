using System.Drawing;

namespace WallChanger
{
    public enum ProcessingSetting
    {
        PreProcessingEnabled,
        BrightnessEnabled,
        BrightnessValue,
        SaturationEnabled,
        SaturationValue,
        ContrastEnabled,
        ContrastValue,
        HueEnabled,
        HueValue,
        GaussianBlurEnabled,
        GaussianBlurSize,
        GaussianSharpenEnabled,
        GaussianSharpenSize,
        PixelateEnabled,
        PixelateSize,
        VignetteEnabled,
        VignetteColour,
        TintEnabled,
        TintColour,
        EdgeDetectionEnabled,
        EdgeDetectionFilter,
        ImageFilterEnabled,
        ImageFilterMatrix
    }

    public class ProcessingSettings
    {
        public bool BrightnessEnabled;
        public int BrightnessValue;
        public bool ContrastEnabled;
        public int ContrastValue;
        public bool EdgeDetectionEnabled;
        public EdgeDetectionFilter EdgeDetectionFilter;
        public bool GaussianBlurEnabled;
        public int GaussianBlurSize;
        public bool GaussianSharpenEnabled;
        public int GaussianSharpenSize;
        public bool HueEnabled;
        public int HueValue;
        public bool ImageFilterEnabled;
        public ImageFilterMatrix ImageFilterMatrix;
        public bool PixelateEnabled;
        public int PixelateSize;
        public bool PreProcessingEnabled;
        public bool SaturationEnabled;
        public int SaturationValue;
        public Color TintColour;
        public bool TintEnabled;
        public Color VignetteColour;
        public bool VignetteEnabled;

        public static ProcessingSettings FromDefaults()
        {
            var Settings = new ProcessingSettings
            {
                PreProcessingEnabled = Properties.Settings.Default.DefaultPreProcessingEnabled,
                BrightnessEnabled = Properties.Settings.Default.DefaultBrightnessEnabled,
                BrightnessValue = Properties.Settings.Default.DefaultBrightnessValue,
                SaturationEnabled = Properties.Settings.Default.DefaultSaturationEnabled,
                SaturationValue = Properties.Settings.Default.DefaultSaturationValue,
                ContrastEnabled = Properties.Settings.Default.DefaultContrastEnabled,
                ContrastValue = Properties.Settings.Default.DefaultContrastValue,
                HueEnabled = Properties.Settings.Default.DefaultHueEnabled,
                HueValue = Properties.Settings.Default.DefaultHueValue,
                GaussianBlurEnabled = Properties.Settings.Default.DefaultGaussianBlurEnabled,
                GaussianBlurSize = Properties.Settings.Default.DefaultGaussianBlurSize,
                GaussianSharpenEnabled = Properties.Settings.Default.DefaultGaussianSharpenEnabled,
                GaussianSharpenSize = Properties.Settings.Default.DefaultGaussianSharpenSize,
                PixelateEnabled = Properties.Settings.Default.DefaultPixelateEnabled,
                PixelateSize = Properties.Settings.Default.DefaultPixelateSize,
                VignetteEnabled = Properties.Settings.Default.DefaultVignetteEnabled,
                VignetteColour = Properties.Settings.Default.DefaultVignetteColour,
                TintEnabled = Properties.Settings.Default.DefaultTintEnabled,
                TintColour = Properties.Settings.Default.DefaultTintColour,
                EdgeDetectionEnabled = Properties.Settings.Default.DefaultEdgeDetectionEnabled,
                EdgeDetectionFilter = Properties.Settings.Default.DefaultEdgeDetectionFilter,
                ImageFilterEnabled = Properties.Settings.Default.DefaultImageFilterEnabled,
                ImageFilterMatrix = Properties.Settings.Default.DefaultImageFilterMatrix
            };

            return Settings;
        }
    }
}
