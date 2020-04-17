using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VideoConverterUtils
{
    public class Ffmpeg
    {

        static string strCmdText = "";

        public static void Run()
        {
            string _changePath = "cd" + Routes.FFMPEG_PATH(); 
            System.Diagnostics.Process.Start("CMD.exe", _changePath); // change cmd path to where ffmeg.exe is located

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

            strCmdText = "ffmpef - i " + file + " - c: hevc_nvenc - crf 28 - c:a aac 128k " +
                Routes.CONVERTED_FILES_SUBFOLDER().ToString() + Path.GetFileName(file) +
                Routes.CONVERTED_FILES_SUFIX().ToString() + ".mp4" + "\n";

            System.Diagnostics.Process.Start("CMD.exe", strCmdText);

        }

    }
}
