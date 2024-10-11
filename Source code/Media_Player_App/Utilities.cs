using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Media_Player_App
{
    public static class Utilities
    {
        public const string PlayListFolder = "PlayList";
        public const string RecentlyPlayed = "RecentlyPlayed";
        public const int MaxRecentlyPlayed = 50;
        public static BitmapImage ConvertStringToBitmapImage(string url)
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(url, UriKind.RelativeOrAbsolute);
            bitmap.CacheOption = BitmapCacheOption.OnLoad; 
            bitmap.EndInit();
            bitmap.Freeze(); 
            return bitmap;
        }
        public static DateTime DoubleToDateTime(double dDateTime)
        {
            return DateTime.FromOADate(dDateTime);
        }
        // take N last element of a list
        public static IEnumerable<T> TakeNLast<T>(this IEnumerable<T> list, int N)
        {
            return list.Skip(Math.Max(0, list.Count() - N));
        }
        public static string ToPath(this Uri source)
        {
            return source.ToString().Replace("file:///", "");
        }
    }
}
