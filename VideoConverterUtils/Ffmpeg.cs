using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace VideoConverterUtils
{
    public class Ffmpeg
    {

        static string strCmdText = "";

        public static void Run()
        {
/*            string _changePath = "cd" + Routes.FFMPEG_PATH(); 
            System.Diagnostics.Process.Start("CMD.exe", _changePath); // change cmd path to where ffmeg.exe is located*/

            List<string> filesTODO = FileManager.ReadAllFilesFromFile(Routes.SOURCE_FILES_PATH().ToString());
            List<string> foldersTODO = FileManager.ReadAllFoldersFromFile(Routes.SOURCE_FOLDERS_PATH().ToString());

            if (filesTODO.Count > 0)
            {
                foreach (var item in filesTODO)
                {
                    RunFfmpeg(item);
                }               
            }

            if (foldersTODO.Count > 0)
            {
                foreach (var item in foldersTODO)
                {
                    RunFfmpeg(item);
                }
            }

        }

        private static void RunFfmpeg(string file)
        {

            string strCmdText2 = "-i " + "\"" + file + "\"" + " -vcodec hevc_nvenc -pix_fmt yuv420p10 -preset hq -2pass 1 -vb 8000k -acodec copy " +
                "\"" + file + "_HEVC" +
                ".mp4" + "\"";

            FFMPEGArg(strCmdText2);

        }

        private static void FFMPEGArg(string args)
        {

            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = @"C:\ffmpeg-4.2.2\bin\ffmpeg.exe";
            startInfo.Arguments = args;
            startInfo.RedirectStandardOutput = true;
            //startInfo.RedirectStandardError = true;

            Console.WriteLine(string.Format(
                "Executing \"{0}\" with arguments \"{1}\".\r\n",
                startInfo.FileName,
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
