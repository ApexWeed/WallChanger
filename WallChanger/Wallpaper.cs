using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Threading.Tasks;

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

        public enum Style : int
        {
            Tiled,
            Centered,
            Stretched,
            Fit,
            Fill
        }

        public static  void Set(string url, Style style)
        {
            System.Drawing.Image img = new System.Drawing.Bitmap(1, 1);
            string tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");

            img = Imaging.FromFile(url);
            img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Bmp);
            img.Dispose();
            
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            if (style == Style.Stretched)
            {
                key.SetValue(@"WallpaperStyle", 2.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (style == Style.Centered)
            {
                key.SetValue(@"WallpaperStyle", 0.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (style == Style.Tiled)
            {
                key.SetValue(@"WallpaperStyle", 2.ToString());
                key.SetValue(@"TileWallpaper", 1.ToString());
            }

            if (style == Style.Fit)
            {
                key.SetValue(@"WallpaperStyle", 6.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (style == Style.Fill)
            {
                key.SetValue(@"WallpaperStyle", 10.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            SystemParametersInfo(SPI_SETDESKWALLPAPER,
                0,
                tempPath,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        public static void FadeSet(Uri uri, Style style)
        {
            //Use IActiveDesktop to change the wallpaper
            IActiveDesktop iad = GetActiveDesktop();
            FadeSet(uri, style, iad);
        }

        public static void FadeSet(Uri uri, Style style, IActiveDesktop iActiveDesktop)
        {
            //System.IO.Stream s = new System.Net.WebClient().OpenRead(uri.ToString());

            //System.Drawing.Image img = System.Drawing.Image.FromStream(s);
            //string tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");
            //img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Bmp);

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            if (style == Style.Stretched)
            {
                key.SetValue(@"WallpaperStyle", 2.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (style == Style.Centered)
            {
                key.SetValue(@"WallpaperStyle", 1.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (style == Style.Tiled)
            {
                key.SetValue(@"WallpaperStyle", 1.ToString());
                key.SetValue(@"TileWallpaper", 1.ToString());
            }

            //kill Progman, so Windows launches WorkerW instead to perform the animation
            IntPtr result = IntPtr.Zero;
            SendMessageTimeout(FindWindow("Progman", IntPtr.Zero), 0x52c, IntPtr.Zero, IntPtr.Zero, 0, 500, out result);
            //Use IActiveDesktop to change the wallpaper
            iActiveDesktop.SetWallpaper(uri.ToString(), 0);
            iActiveDesktop.ApplyChanges(AD_APPLY.ALL | AD_APPLY.FORCE | AD_APPLY.BUFFERED_REFRESH);
        }
    }
}
