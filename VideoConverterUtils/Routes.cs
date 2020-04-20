namespace VideoConverterUtils
{
    public class Routes
    {

        /// <summary>
        /// MKV to MP4. Path where the txt with the files is located
        /// </summary>
        /// <returns></returns>
        public static string SOURCE_FILES_PATH_MKV_TO_MP4()
        {

            return "@/../../../../resources/mkv_mp4/files.txt";

        }

        /// <summary>
        /// MKV to MP4. Path where the txt with the folders is located
        /// </summary>
        /// <returns></returns>
        public static string SOURCE_FOLDERS_PATH_MKV_TO_MP4()
        {

            return "@/../../../../resources/mkv_mp4/folders.txt";

        }

        /// <summary>
        /// TO HEVC/MP4. Path where the txt with the files is located
        /// </summary>
        /// <returns></returns>
        public static string SOURCE_FILES_PATH_TO_HEVC_MP4()
        {

            return "@/../../../../resources/mp4_hevc/files.txt";

        }

        /// <summary>
        /// TO HEVC/MP4. Path where the txt with the folders is located
        /// </summary>
        /// <returns></returns>
        public static string SOURCE_FOLDERS_PATH_TO_HEVC_MP4()
        {

            return "@/../../../../resources/mp4_hevc/folders.txt";

        }

    }
}
