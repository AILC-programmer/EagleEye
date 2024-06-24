namespace EagleEye.Tools
{
    public class PathWorker
    {
        private PathWorker() { }

        private static PathWorker instance;

        public static PathWorker Instance
        {
            get
            {
                if (instance == null)
                    instance = new PathWorker();

                return instance;
            }
        }

        string binFile = Path.Combine(FileSystem.AppDataDirectory, "Bin");
        public string DirectoryPath
        {
            get
            {
                if (!Directory.Exists(binFile))
                    Directory.CreateDirectory(binFile);
                return binFile;
            }
        }

        public string GetSettingsFilePath => Path.Combine(DirectoryPath, "Settings.json");

        public bool IsSettingsFileExists => File.Exists(GetSettingsFilePath);
    }
}
