namespace EagleEye.Tools
{
    public class PathWorker
    {
        // Singleton

        private PathWorker() { }
        private static PathWorker instance;
        public static PathWorker Instance => instance ?? (instance = new PathWorker());

        //


        public string DirectoryPath
        {
            get
            {
                string binFile = Path.Combine(FileSystem.AppDataDirectory, "Bin");
                if (!Directory.Exists(binFile))
                    Directory.CreateDirectory(binFile);
                return binFile;
            }
        }

        public string GetUserFilePath => Path.Combine(DirectoryPath, "User.json");
        public bool IsUserFileExitst => File.Exists(GetUserFilePath);
    }
}
