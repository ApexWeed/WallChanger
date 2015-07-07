using System;
using System.Collections.Generic;

namespace WallChanger
{
    public static class Timing
    {
        private static Dictionary<char, int> timeMapping;
        private static Dictionary<char, int> TimeMapping
        {
            get
            {
                if (timeMapping == null)
                {
                    timeMapping = new Dictionary<char, int>();
                    timeMapping.Add('f', 1);
                    timeMapping.Add('F', 1);
                    timeMapping.Add('s', 1000);
                    timeMapping.Add('S', 1000);
                    timeMapping.Add('m', 60000);
                    timeMapping.Add('M', 60000);
                    timeMapping.Add('h', 3600000);
                    timeMapping.Add('H', 3600000);
                }
                return timeMapping;
            }
        }

        public static string ToString(int MilliSeconds)
        {
            return new DateTime().AddYears(10).AddSeconds(MilliSeconds / 1000).ToString(@"H \h m \m s \s");
        }

        /// <summary>
        /// Parses the config file times to seconds.
        /// </summary>
        /// <param name="Time">Time in "x h y m z s" format.</param>
        /// <returns>Number of seconds.</returns>
        public static int ParseTime(string Time)
        {
            string[] parts = Time.Split(' ');
            int interval = 0;
            if (parts.Length % 2 == 0)
            {
                for (int i = 0; i < parts.Length / 2; i++)
                {
                    interval += int.Parse(parts[i * 2]) * TimeMapping[parts[i * 2 + 1][0]];
                }
            }
            else
            {
                interval = 10;
            }

            return interval;
        }
    }
}
