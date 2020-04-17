using System;
using System.Collections.Generic;
using System.Text;

namespace VideoConverterUtils
{
    public class Routes
    {

        /// <summary>
        /// Path to where ffmpeg.exe is located
        /// </summary>
        /// <returns></returns>
        public static string FFMPEG_PATH()
        {

            return @"C:\\ffmpeg - 4.2.2\bin\";
        
        }

        /// <summary>
        /// Path where the txt with the files is located
        /// </summary>
        /// <returns></returns>
        public static string SOURCE_FILES_PATH()
        {

            return @"D:\\Pruebas VideoConverterUtils\files.txt";

        }

        /// <summary>
        /// Path where the txt with the folders is located
        /// </summary>
        /// <returns></returns>
        public static string SOURCE_FOLDERS_PATH()
        {

            return @"D:\\Pruebas VideoConverterUtils\folders.txt";

        }

        /// <summary>
        /// Sufix to add to the end of the converted file
        /// </summary>
        /// <returns></returns>
        public static string CONVERTED_FILES_SUFIX()
        {

            return " HEVC";

        }

        /// <summary>
        /// Subfolder in which to store the converted files
        /// </summary>
        /// <returns></returns>
        public static string CONVERTED_FILES_SUBFOLDER()
        {

            return "";

        }

    }
}
