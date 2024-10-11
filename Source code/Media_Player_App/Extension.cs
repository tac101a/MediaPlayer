using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Media_Player_App
{
    public static class Extension
    {
        public static string getFileName(this string fullFileName)
        {
            return Path.GetFileNameWithoutExtension(fullFileName);
        }
    }
}
