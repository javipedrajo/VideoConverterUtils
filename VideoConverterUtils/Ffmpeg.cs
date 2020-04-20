using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace VideoConverterUtils
{
    public class Ffmpeg
    {

        public static void Run()
        {

            ExportToMP4HEVC();
            ExportFromMKVHEVCToMP4HEVC();

        }

        private static void ExportToMP4HEVC()
        {

            List<string> filesTODO = FileManager.ReadAllFilesFromFile(Routes.SOURCE_FILES_PATH_TO_HEVC_MP4().ToString());
            List<string> foldersTODO = FileManager.ReadAllFoldersFromFile(Routes.SOURCE_FOLDERS_PATH_TO_HEVC_MP4().ToString());

            if (filesTODO.Count > 0)
            {
                foreach (var item in filesTODO)
                {
                    ConvertToMP4_HEVC(item);
                }
            }

            if (foldersTODO.Count > 0)
            {
                foreach (var item in foldersTODO)
                {
                    ConvertToMP4_HEVC(item);
                }
            }

        }

        private static void ExportFromMKVHEVCToMP4HEVC()
        {

            List<string> filesTODO = FileManager.ReadAllFilesFromFile(Routes.SOURCE_FILES_PATH_MKV_TO_MP4().ToString());
            List<string> foldersTODO = FileManager.ReadAllFoldersFromFile(Routes.SOURCE_FOLDERS_PATH_MKV_TO_MP4().ToString());

            if (filesTODO.Count > 0)
            {
                foreach (var item in filesTODO)
                {
                    ConvertFromMKVtoMP4(item);
                }
            }

            if (foldersTODO.Count > 0)
            {
                foreach (var item in foldersTODO)
                {
                    ConvertFromMKVtoMP4(item);
                }
            }

        }

        /// <summary>
        /// Encode a video with hevc_nvenc, -crf, same audio in .MP4
        /// </summary>
        /// <param name="file"></param>
        private static void ConvertToMP4_HEVC(string file)
        {

            string strCmdText = "-i " + "\"" + file + "\"" + " -c: hevc_nvenc -crf 28 -acodec copy " +
                "\"" + file +
                ".mp4" + "\"";

            RunFFMPEG(strCmdText);

        }

        /// <summary>
        /// Change a filex extension  from MKV to MP4
        /// </summary>
        /// <param name="file"></param>
        private static void ConvertFromMKVtoMP4(string file)
        {

            string strCmdText = "-i " + "\"" + file + "\"" + " -vcodec copy -acodec copy -scodec copy " +
                "\"" + file +
                ".mp4" + "\"";

            RunFFMPEG(strCmdText);

        }

        private static void RunFFMPEG(string args)
        {

            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = @"C:\ffmpeg-4.2.2\bin\ffmpeg.exe";
            startInfo.Arguments = args;
            startInfo.RedirectStandardOutput = true;
            //startInfo.RedirectStandardError = true;

            Console.WriteLine(string.Format(
                "Executing ffmpeg \"{0}\".\r\n",
                startInfo.Arguments));

            try
            {
                using (Process process = Process.Start(startInfo))
                {
                    while (!process.StandardOutput.EndOfStream)
                    {
                        string line = process.StandardOutput.ReadLine();
                        Console.WriteLine(line);
                    }

                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
