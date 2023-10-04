using System.Globalization;

namespace Licenta.SDK
{
    public class Formaters
    {
        public static string GetBytesReadable(long bytes)
        {
            var absoluteValue = Math.Abs(bytes);

            string suffix;
            double readable;
            if (absoluteValue >= 0x1000000000000000) // Exabyte
            {
                suffix = "EB";
                readable = bytes >> 50;
            }
            else if (absoluteValue >= 0x4000000000000) // Petabyte
            {
                suffix = "PB";
                readable = bytes >> 40;
            }
            else if (absoluteValue >= 0x10000000000) // Terabyte
            {
                suffix = "TB";
                readable = bytes >> 30;
            }
            else if (absoluteValue >= 0x40000000) // Gigabyte
            {
                suffix = "GB";
                readable = bytes >> 20;
            }
            else if (absoluteValue >= 0x100000) // Megabyte
            {
                suffix = "MB";
                readable = bytes >> 10;
            }
            else if (absoluteValue >= 0x400) // Kilobyte
            {
                suffix = "KB";
                readable = bytes;
            }
            else
            {
                return bytes.ToString("0 B"); // Byte
            }

            readable = readable / 1024;
            return readable.ToString("0.### ", CultureInfo.InvariantCulture) + suffix;
        }
        public static string GetDatePassedReadable(DateTime datetime)
        {
            TimeSpan timpTrecut = DateTime.Now - datetime;

            if (timpTrecut.TotalSeconds < 60)
            {
                int secunde = (int)timpTrecut.TotalSeconds;
                return $"{secunde} {(secunde == 1 ? "secundă" : "secunde")} în urmă";
            }
            else if (timpTrecut.TotalMinutes < 60)
            {
                int minute = (int)timpTrecut.TotalMinutes;
                return $"{minute} {(minute == 1 ? "minut" : "minute")} în urmă";
            }
            else if (timpTrecut.TotalHours < 24)
            {
                int ore = (int)timpTrecut.TotalHours;
                return $"{ore} {(ore == 1 ? "oră" : "ore")} în urmă";
            }
            else if (timpTrecut.TotalDays < 30)
            {
                int zile = (int)timpTrecut.TotalDays;
                return $"{zile} {(zile == 1 ? "zi" : "zile")} în urmă";
            }
            else if (timpTrecut.TotalDays < 365)
            {
                int luni = (int)(timpTrecut.TotalDays / 30);
                return $"{luni} {(luni == 1 ? "lună" : "luni")} în urmă";
            }
            else
            {
                int ani = (int)(timpTrecut.TotalDays / 365);
                return $"{ani} {(ani == 1 ? "an" : "ani")} în urmă";
            }
        }

    }
}
