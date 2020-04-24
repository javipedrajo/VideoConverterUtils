using System.Collections.Generic;
using System.IO;

namespace VideoConverterUtils
{
    public class FileManager
    {

        /// <summary>
        /// Read all files to convert in the "files" file
        /// </summary>
        /// <param name="path">File that contains all the files' path to convert</param>
        /// <returns></returns>
        public static List<string> ReadAllFilesFromFile(string path)
        {
            List<string> _tempList = new List<string>();
            string line;

            System.IO.StreamReader file =
                new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                _tempList.Add(line);

            }

            file.Close();
            return _tempList;

        }

        /// <summary>
        /// Read all files from the folders in the "folders" file
        /// </summary>
        /// <param name="path">File that contains all the folders' path to convert</param>
        /// <returns></returns>
        public static List<string> ReadAllFoldersFromFile(string path)
        {

            List<string> _tempList = new List<string>();
            string line;

            System.IO.StreamReader file =
                new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                string[] _arr = Directory.GetFileSystemEntries(line);

                foreach (var item in _arr)
                {
                    if (item.EndsWith("mp4") || item.EndsWith("mkv") || item.EndsWith("avi") || item.EndsWith("mov") || item.EndsWith("mts") || item.EndsWith("m2ts") || item.EndsWith("webm"))
                    {
                        _tempList.Add(item);
                    }
                }

            }

            file.Close();
            return _tempList;

        }


    }
}
