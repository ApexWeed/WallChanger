using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace WallChanger
{
    public sealed class Wallpaper
    {
        Wallpaper() { }

        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessageTimeout(
        IntPtr hWnd, // handle to destination window
        uint Msg, // message
        IntPtr wParam, // first message parameter
        IntPtr lParam, // second message parameter
        uint fuFlags,
        uint uTimeout,
        out IntPtr result

        );
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, IntPtr ZeroOnly);

        public enum WallpaperStyle
        {
            Centered = 0,
            Tiled = 1,
            Stretched = 2,
            Fit = 3,
            Fill = 4,
            Span = 5,
            Max = 6
        }

        public static IActiveDesktop GetActiveDesktop()
        {
            Type typeActiveDesktop = Type.GetTypeFromCLSID(new Guid("{75048700-EF1F-11D0-9888-006097DEACF9}"));
            object returnedValue = Activator.CreateInstance(typeActiveDesktop);
            //System.Windows.Forms.MessageBox.Show(returnedValue.GetType().ToString() + " " + typeActiveDesktop.ToString());
            IActiveDesktop castedValue = null;
            try
            {
                castedValue = (IActiveDesktop)returnedValue;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return castedValue;
        }

        /// <summary>
        /// Sets the wallpaper from the specified filename.
        /// </summary>
        /// <param name="Filename">The path to the image.</param>
        /// <param name="Style">The style for the wallpaper.</param>
        public static void Set(string Filename, WallpaperStyle Style)
        {
            System.Drawing.Image img = new System.Drawing.Bitmap(1, 1);
            string tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");

            img = Imaging.FromFile(Filename);
            img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Bmp);
            img.Dispose();
            
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            if (Style == WallpaperStyle.Stretched)
            {
                key.SetValue(@"WallpaperStyle", 2.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (Style == WallpaperStyle.Centered)
            {
                key.SetValue(@"WallpaperStyle", 0.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (Style == WallpaperStyle.Tiled)
            {
                key.SetValue(@"WallpaperStyle", 2.ToString());
                key.SetValue(@"TileWallpaper", 1.ToString());
            }

            if (Style == WallpaperStyle.Fit)
            {
                key.SetValue(@"WallpaperStyle", 6.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (Style == WallpaperStyle.Fill)
            {
                key.SetValue(@"WallpaperStyle", 10.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            SystemParametersInfo(SPI_SETDESKWALLPAPER,
                0,
                tempPath,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        /// <summary>
        /// Sets the wallpaper from the specified filename asynchronously.
        /// </summary>
        /// <param name="Filename">The path to the image.</param>
        /// <param name="Style">The style for the wallpaper.</param>
        public static async void SetAsync(string Filename, WallpaperStyle Style)
        {
            System.Drawing.Image img = new System.Drawing.Bitmap(1, 1);
            string tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");

            await Task.Run(() =>
            {
                img = Imaging.FromFile(Filename);
                img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Bmp);
                img.Dispose();
            });

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            if (Style == WallpaperStyle.Stretched)
            {
                key.SetValue(@"WallpaperStyle", 2.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (Style == WallpaperStyle.Centered)
            {
                key.SetValue(@"WallpaperStyle", 0.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (Style == WallpaperStyle.Tiled)
            {
                key.SetValue(@"WallpaperStyle", 2.ToString());
                key.SetValue(@"TileWallpaper", 1.ToString());
            }

            if (Style == WallpaperStyle.Fit)
            {
                key.SetValue(@"WallpaperStyle", 6.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (Style == WallpaperStyle.Fill)
            {
                key.SetValue(@"WallpaperStyle", 10.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            SystemParametersInfo(SPI_SETDESKWALLPAPER,
                0,
                tempPath,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        /// <summary>
        /// Sets the wallpaper using active desktop to fade the image.
        /// </summary>
        /// <param name="Filename">The path to the image to set.</param>
        /// <param name="Style">The style for the wallpaper.</param>
        public static void FadeSet(string Filename, WallpaperStyle Style)
        {
            //Use IActiveDesktop to change the wallpaper
            IActiveDesktop iad = GetActiveDesktop();
            FadeSet(Filename, Style, iad);
        }

        /// <summary>
        /// Sets the wallpaper using the specified active desktop instance to fade the image.
        /// </summary>
        /// <param name="Filename">The path to the image to set.</param>
        /// <param name="Style">The style for the wallpapre.</param>
        /// <param name="iActiveDesktop">The active desktop instance to use.</param>
        public static void FadeSet(string Filename, WallpaperStyle Style, IActiveDesktop iActiveDesktop)
        {
            

            //kill Progman, so Windows launches WorkerW instead to perform the animation
            IntPtr result = IntPtr.Zero;
            SendMessageTimeout(FindWindow("Progman", IntPtr.Zero), 0x52c, IntPtr.Zero, IntPtr.Zero, 0, 500, out result);
            //Use IActiveDesktop to change the wallpaper
            iActiveDesktop.SetWallpaperOptions(new WALLPAPEROPT() { dwSize = Marshal.SizeOf(new WALLPAPEROPT()), dwStyle = (WPSTYLE)Style }, 0);
            iActiveDesktop.SetWallpaper(Filename, 0);
            iActiveDesktop.ApplyChanges(AD_APPLY.ALL | AD_APPLY.FORCE | AD_APPLY.BUFFERED_REFRESH);
        }
    }
}
