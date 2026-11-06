using System;
using System.Collections.Generic;
using System.Text;

namespace bguerreroS5.utils
{
    public class FileAcccesHelper
    {
        public static string GetLocalFilePath(string fileName)
        {
            return System.IO.Path.
                Combine(FileSystem.AppDataDirectory, fileName);
        }
    }
}
