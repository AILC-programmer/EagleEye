namespace EagleEye.Tools
{
    public class PathWorker
    {
        private PathWorker() { }

        private static PathWorker instance;

        public static PathWorker Instance
        {
            get => instance ?? (instance = new PathWorker());
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

        public string GetGamePlayFilePath => Path.Combine(DirectoryPath, "GamePlay.json");
        public bool IsGamePlayFileExitst => File.Exists(GetGamePlayFilePath);
    }
}
