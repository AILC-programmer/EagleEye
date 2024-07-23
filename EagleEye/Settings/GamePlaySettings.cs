using EagleEye.Models.Enums;

namespace EagleEye.Settings
{
    internal class GamePlaySettings
    {
        // Singleton

        private GamePlaySettings() { }
        private static GamePlaySettings instance;
        public static GamePlaySettings Instance => instance ?? (instance = new GamePlaySettings());

        //

        public readonly int[] ColorCounts = new int[] { 3, 4, 5, 6, 7 };

        private int ColorCountIndex
        {
            get => Preferences.Default.Get<int>(SettingsKeysName.ColorCountKey, 3);
            set => Preferences.Default.Set<int>(SettingsKeysName.ColorCountKey, value);
        }

        public GameLevel GameLevel
        {
            get => (GameLevel)Preferences.Default.Get<int>(SettingsKeysName.GameLevelKey, 1);
            set => Preferences.Default.Set<int>(SettingsKeysName.GameLevelKey, (int)value);
        }

        public int ColorCount
        {
            get => ColorCounts[ColorCountIndex];
            set => ColorCountIndex = Array.IndexOf(ColorCounts, value);
        }

        #region Colors settings
        // Red
        public bool IsRedSelected
        {
            get => Preferences.Default.Get<bool>(SettingsKeysName.IsRedSelectedKey, false);
            set => Preferences.Default.Set<bool>(SettingsKeysName.IsRedSelectedKey, value);
        }
        // Green
        public bool IsGreenSelected
        {
            get => Preferences.Default.Get<bool>(SettingsKeysName.IsGreenSelectedKey, false);
            set => Preferences.Default.Set<bool>(SettingsKeysName.IsGreenSelectedKey, value);
        }
        // Blue
        public bool IsBlueSelected
        {
            get => Preferences.Default.Get<bool>(SettingsKeysName.IsBlueSelectedKey, false);
            set => Preferences.Default.Set<bool>(SettingsKeysName.IsBlueSelectedKey, value);
        }
        // Pink
        public bool IsPinkSelected
        {
            get => Preferences.Default.Get<bool>(SettingsKeysName.IsPinkSelectedKey, false);
            set => Preferences.Default.Set<bool>(SettingsKeysName.IsPinkSelectedKey, value);
        }
        // White
        public bool IsWhiteSelected
        {
            get => Preferences.Default.Get<bool>(SettingsKeysName.IsWhiteSelectedKey, false);
            set => Preferences.Default.Set<bool>(SettingsKeysName.IsWhiteSelectedKey, value);
        }
        // Gray
        public bool IsGraySelected
        {
            get => Preferences.Default.Get<bool>(SettingsKeysName.IsGraySelectedKey, false);
            set => Preferences.Default.Set<bool>(SettingsKeysName.IsGraySelectedKey, value);
        }
        // Yellow
        public bool IsYellowSelected
        {
            get => Preferences.Default.Get<bool>(SettingsKeysName.IsYellowSelectedKey, false);
            set => Preferences.Default.Set<bool>(SettingsKeysName.IsYellowSelectedKey, value);
        }
        // Brown
        public bool IsBrownSelected
        {
            get => Preferences.Default.Get<bool>(SettingsKeysName.IsBrownSelectedKey, false);
            set => Preferences.Default.Set<bool>(SettingsKeysName.IsBrownSelectedKey, value);
        }
        // Random colors
        public bool IsRandomSelected
        {
            get => Preferences.Default.Get<bool>(SettingsKeysName.IsRandomSelectedKey, true);
            set => Preferences.Default.Set<bool>(SettingsKeysName.IsRandomSelectedKey, value);
        }
        #endregion
    }
}
