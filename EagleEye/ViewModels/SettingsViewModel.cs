using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EagleEye.Models;
using EagleEye.Settings;

namespace EagleEye.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {
        public SettingsViewModel()
        {
            Settings.OnAllSelectedColors += Instance_OnAllSelectedColors;
        }

        private void Instance_OnAllSelectedColors()
        {
            changeEnabilityOfCheckBoxes(!(Settings.AreFullColorsSelected || Settings.IsRandomSelected));
        }

        #region Observable properties

        [ObservableProperty]
        string[] colorCounts = GamePlaySettings.Instance.ColorCounts;
        [ObservableProperty]
        GamePlaySettings settings = GamePlaySettings.Instance;
        [ObservableProperty]
        GameColors colors = new GameColors();
        [ObservableProperty]
        bool redCheckBoxEnabled;
        [ObservableProperty]
        bool greenCheckBoxEnabled;
        [ObservableProperty]
        bool blueCheckBoxEnabled;
        [ObservableProperty]
        bool pinkCheckBoxEnabled;
        [ObservableProperty]
        bool whiteCheckBoxEnabled;
        [ObservableProperty]
        bool grayCheckBoxEnabled;
        [ObservableProperty]
        bool yellowCheckBoxEnabled;
        [ObservableProperty]
        bool brownCheckBoxEnabled;

        #endregion

        void changeEnabilityOfCheckBoxes(bool AreAllEnable)
        {
            if (AreAllEnable)
            {
                RedCheckBoxEnabled = GreenCheckBoxEnabled = BlueCheckBoxEnabled = PinkCheckBoxEnabled = WhiteCheckBoxEnabled =
                    GrayCheckBoxEnabled = YellowCheckBoxEnabled = BrownCheckBoxEnabled = true;
                return;
            }

            RedCheckBoxEnabled = Settings.IsRedSelected;
            GreenCheckBoxEnabled = Settings.IsGreenSelected;
            BlueCheckBoxEnabled = Settings.IsBlueSelected;
            PinkCheckBoxEnabled = Settings.IsPinkSelected;
            WhiteCheckBoxEnabled = Settings.IsWhiteSelected;
            GrayCheckBoxEnabled = Settings.IsGraySelected;
            YellowCheckBoxEnabled = Settings.IsYellowSelected;
            BrownCheckBoxEnabled = Settings.IsBrownSelected;
        }

        [RelayCommand]
        async Task GoBack() => await AppShell.Current.GoToAsync("..");
    }
}
