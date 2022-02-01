using System;
using System.IO;

namespace HotelLinenManagerV2.Tests.Examples
{
    public class FileManager
    {
        public bool IsFileExists(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }
            return File.Exists(filePath);
        }



    }
}
