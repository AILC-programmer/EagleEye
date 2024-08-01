using EagleEye.Models.Enums;

namespace EagleEye.Settings
{
    public class GamePlaySettings
    {
        // Singleton

        private GamePlaySettings() 
        {
            loadColors();
        }
        private static GamePlaySettings instance;
        public static GamePlaySettings Instance => instance ?? (instance = new GamePlaySettings());

        //
        private int selectedColorsCount = 0;

        public readonly string[] ColorCounts = new string[] { "3", "4", "5", "6", "7" };

        public GameLevel GameLevel
        {
            get => (GameLevel)Preferences.Default.Get<int>(SettingsKeysName.GameLevelKey, 1);
            set => Preferences.Default.Set<int>(SettingsKeysName.GameLevelKey, (int)value);
        }

        public int ColorCountIndex
        {
            get => Preferences.Default.Get<int>(SettingsKeysName.ColorCountKey, 0);
            set
            {
                Preferences.Default.Set<int>(SettingsKeysName.ColorCountKey, value);
                restartColors();
            }
        }

        public int ColorCount => Convert.ToInt32(ColorCounts[ColorCountIndex]);

        #region Colors settings
        // Red
        public bool IsRedSelected
        {
            get => Preferences.Default.Get<bool>(SettingsKeysName.IsRedSelectedKey, false);
            set
            {
                Preferences.Default.Set<bool>(SettingsKeysName.IsRedSelectedKey, value);
                ColorsManager(value);
            }
        }
        // Green
        public bool IsGreenSelected
        {
            get => Preferences.Default.Get<bool>(SettingsKeysName.IsGreenSelectedKey, false);
            set
            {
                Preferences.Default.Set<bool>(SettingsKeysName.IsGreenSelectedKey, value);
                ColorsManager(value);
            }
        }
        // Blue
        public bool IsBlueSelected
        {
            get => Preferences.Default.Get<bool>(SettingsKeysName.IsBlueSelectedKey, false);
            set
            {
                Preferences.Default.Set<bool>(SettingsKeysName.IsBlueSelectedKey, value);
                ColorsManager(value);
            }
        }
        // Pink
        public bool IsPinkSelected
        {
            get => Preferences.Default.Get<bool>(SettingsKeysName.IsPinkSelectedKey, false);
            set
            {
                Preferences.Default.Set<bool>(SettingsKeysName.IsPinkSelectedKey, value);
                ColorsManager(value);
            }
        }
        // White
        public bool IsWhiteSelected
        {
            get => Preferences.Default.Get<bool>(SettingsKeysName.IsWhiteSelectedKey, false);
            set
            {
                Preferences.Default.Set<bool>(SettingsKeysName.IsWhiteSelectedKey, value);
                ColorsManager(value);
            }
        }
        // Gray
        public bool IsGraySelected
        {
            get => Preferences.Default.Get<bool>(SettingsKeysName.IsGraySelectedKey, false);
            set
            {
                Preferences.Default.Set<bool>(SettingsKeysName.IsGraySelectedKey, value);
                ColorsManager(value);
            }
        }
        // Yellow
        public bool IsYellowSelected
        {
            get => Preferences.Default.Get<bool>(SettingsKeysName.IsYellowSelectedKey, false);
            set
            {
                Preferences.Default.Set<bool>(SettingsKeysName.IsYellowSelectedKey, value);
                ColorsManager(value);
            }
        }
        // Brown
        public bool IsBrownSelected
        {
            get => Preferences.Default.Get<bool>(SettingsKeysName.IsBrownSelectedKey, false);
            set
            {
                Preferences.Default.Set<bool>(SettingsKeysName.IsBrownSelectedKey, value);
                ColorsManager(value);
            }
        }
        // Random colors
        public bool IsRandomSelected
        {
            get => Preferences.Default.Get<bool>(SettingsKeysName.IsRandomSelectedKey, true);
            set
            {
                Preferences.Default.Set<bool>(SettingsKeysName.IsRandomSelectedKey, value);
                if(value)
                    setAllColorsStatus(false);
                ColorsManager(value);

            }
        }
        #endregion

        public bool AreFullColorsSelected => ColorCount == selectedColorsCount;

        #region Methodes

        public void RestartSettings()
        {
            this.GameLevel = GameLevel.ShadeSeeker;
            RestartColors();
        }

        public void ColorsManager(bool value)
        {
            if (value)
                selectedColorsCount++;
            else if (!value && selectedColorsCount > 0)
                selectedColorsCount--;

            if (OnAllSelectedColors != null)
                OnAllSelectedColors();
        }

        public void RestartColors()
        {
            ColorCountIndex = 0;
            IsRandomSelected = true;
        }

        private void restartColors()
        {
            setAllColorsStatus(false);
        }

        private void setAllColorsStatus(bool status)
        {
            IsRedSelected = IsBlueSelected = IsGreenSelected = IsYellowSelected =
                IsPinkSelected = IsBrownSelected = IsWhiteSelected = IsGraySelected = status;
        }

        private void loadColors()
        {
            if (IsRedSelected)
                selectedColorsCount++;
            if (IsBlueSelected)
                selectedColorsCount++;
            if (IsGreenSelected)
                selectedColorsCount++;
            if (IsYellowSelected)
                selectedColorsCount++;
            if (IsPinkSelected)
                selectedColorsCount++;
            if (IsBrownSelected)
                selectedColorsCount++;
            if (IsWhiteSelected)
                selectedColorsCount++;
            if (IsGraySelected)
                selectedColorsCount++;
        }

        #endregion

        // event

        /// <summary>
        /// 
        /// </summary>
        public event Action OnAllSelectedColors;
    }
}
