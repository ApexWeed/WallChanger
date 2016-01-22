using System;
using System.Drawing;

namespace WallChanger
{
    public static class Utilities
    {
        public static Color HSVToColour(double h, double s, double v, int a = 255)
        {
            var H = h;
            while (H < 0)
            {
                H += 360;
            };
            while (H >= 360)
            {
                H -= 360;
            };
            double R, G, B;
            if (v <= 0)
            {
                R = G = B = 0;
            }
            else if (s <= 0)
            {
                R = G = B = v;
            }
            else
            {
                var hf = H / 60.0;
                var i = (int)Math.Floor(hf);
                var f = hf - i;
                var pv = v * (1 - s);
                var qv = v * (1 - s * f);
                var tv = v * (1 - s * (1 - f));
                switch (i)
                {

                    // Red is the dominant color

                    case 0:
                        {
                            R = v;
                            G = tv;
                            B = pv;
                            break;
                        }
                    // Green is the dominant color

                    case 1:
                        {
                            R = qv;
                            G = v;
                            B = pv;
                            break;
                        }
                    case 2:
                        {
                            R = pv;
                            G = v;
                            B = tv;
                            break;
                        }
                    // Blue is the dominant color

                    case 3:
                        {
                            R = pv;
                            G = qv;
                            B = v;
                            break;
                        }
                    case 4:
                        {
                            R = tv;
                            G = pv;
                            B = v;
                            break;
                        }
                    // Red is the dominant color

                    case 5:
                        {
                            R = v;
                            G = pv;
                            B = qv;
                            break;
                        }
                    // Just in case we overshoot on our math by a little, we put these here. Since its a switch it won't slow us down at all to put these here.

                    case 6:
                        {
                            R = v;
                            G = tv;
                            B = pv;
                            break;
                        }
                    case -1:
                        {
                            R = v;
                            G = pv;
                            B = qv;
                            break;
                        }
                    // The color is not defined, we should throw an error.

                    default:
                        {
                            //LFATAL("i Value error in Pixel conversion, Value is %d", i);
                            R = G = B = v; // Just pretend its black/white
                            break;
                        }
                }
            }
            var r = ((int)(R * 255.0)).Clamp(0, 255);
            var g = ((int)(G * 255.0)).Clamp(0, 255);
            var b = ((int)(B * 255.0)).Clamp(0, 255);
            return Color.FromArgb(a, r, g, b);
        }

        public static void ColourToHSV(Color colour, out float hue, out float saturation, out float value)
        {
            int max = Math.Max(colour.R, Math.Max(colour.G, colour.B));
            int min = Math.Min(colour.R, Math.Min(colour.G, colour.B));

            hue = colour.GetHue();
            saturation = (max == 0) ? 0 : (float)(1d - (1d * min / max));
            value = (float)(max / 255d);
        }
    }
}
