using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EagleEye.Models;
using EagleEye.Models.Enums;
using EagleEye.Settings;
using System.ComponentModel;

namespace EagleEye.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {
        GamePlaySettings settings;

        public SettingsViewModel()
        {
            initializeSettings();
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            switch (e.PropertyName)
            {
                case nameof(SelectedColorIntex):
                    {
                        settings.ColorCountIndex = SelectedColorIntex;
                    }
                    break;
                case nameof(RedIsChecked):
                    {
                        settings.IsRedSelected = RedIsChecked;
                        CheckedCountChanged();
                    }
                    break;
                case nameof(GreenIsChecked):
                    {
                        settings.IsGreenSelected = GreenIsChecked;
                        CheckedCountChanged();
                    }
                    break;
                case nameof(BlueIsChecked):
                    {
                        settings.IsBlueSelected = BlueIsChecked;
                        CheckedCountChanged();
                    }
                    break;
                case nameof(PinkIsChecked):
                    {
                        settings.IsPinkSelected = PinkIsChecked;
                        CheckedCountChanged();
                    }
                    break;
                case nameof(WhiteIsChecked):
                    {
                        settings.IsWhiteSelected = WhiteIsChecked;
                        CheckedCountChanged();
                    }
                    break;
                case nameof(GrayIsChecked):
                    {
                        settings.IsGraySelected = GrayIsChecked;
                        CheckedCountChanged();
                    }
                    break;
                case nameof(YellowIsChecked):
                    {
                        settings.IsYellowSelected = YellowIsChecked;
                        CheckedCountChanged();
                    }
                    break;
                case nameof(BrownIsChecked):
                    {
                        settings.IsBrownSelected = BrownIsChecked;
                        CheckedCountChanged();
                    }
                    break;
                case nameof(RandomIsChecked):
                    {
                        settings.IsRandomSelected = RandomIsChecked;
                        if (!RandomIsChecked)
                        {
                            changeEnabilityOfCheckBoxes(true);
                            break;
                        }

                        settings.ResetColors();
                        initializeColors();

                        changeEnabilityOfCheckBoxes(false);
                    }
                    break;
                case nameof(ColorExplorerIsChecked):
                    {
                        if (ColorExplorerIsChecked)
                            settings.GameLevel = GameLevel.ColorExplorer;
                    }
                    break;
                case nameof(ShadeSeekerIsChecked):
                    {
                        if (ShadeSeekerIsChecked)
                            settings.GameLevel = GameLevel.ShadeSeeker;
                    }
                    break;
                case nameof(HueHunterIsChecked):
                    {
                        if (HueHunterIsChecked)
                            settings.GameLevel = GameLevel.HueHunter;
                    }
                    break;
                case nameof(TintTrackerIsChecked):
                    {
                        if (TintTrackerIsChecked)
                            settings.GameLevel = GameLevel.TintTracker;
                    }
                    break;
                case nameof(ChromaticMasterIsChecked):
                    {
                        if (ChromaticMasterIsChecked)
                            settings.GameLevel = GameLevel.ChromaticMaster;
                    }
                    break;
                default:
                    break;
            }
        }

        #region Observable properties

        [ObservableProperty]
        string[] colorCounts;
        [ObservableProperty]
        int selectedColorIntex;
        [ObservableProperty]
        GameColors colors;

        // Colors Check

        [ObservableProperty]
        bool redIsChecked;
        [ObservableProperty]
        bool greenIsChecked;
        [ObservableProperty]
        bool blueIsChecked;
        [ObservableProperty]
        bool pinkIsChecked;
        [ObservableProperty]
        bool whiteIsChecked;
        [ObservableProperty]
        bool grayIsChecked;
        [ObservableProperty]
        bool yellowIsChecked;
        [ObservableProperty]
        bool brownIsChecked;
        [ObservableProperty]
        bool randomIsChecked;

        // CheckBoxes Enability

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

        // Game levels

        [ObservableProperty]
        bool colorExplorerIsChecked;
        [ObservableProperty]
        bool shadeSeekerIsChecked;
        [ObservableProperty]
        bool hueHunterIsChecked;
        [ObservableProperty]
        bool tintTrackerIsChecked;
        [ObservableProperty]
        bool chromaticMasterIsChecked;


        #endregion

        #region Methods

        void initializeSettings()
        {
            settings = GamePlaySettings.Instance;
            ColorCounts = settings.ColorCounts;
            Colors = new GameColors();

            initializeColors();

            initializeGameLevel();
        }

        void initializeColors()
        {
            SelectedColorIntex = settings.ColorCountIndex;
            RedIsChecked = settings.IsRedSelected;
            GreenIsChecked = settings.IsGreenSelected;
            BlueIsChecked = settings.IsBlueSelected;
            YellowIsChecked = settings.IsYellowSelected;
            PinkIsChecked = settings.IsPinkSelected;
            BrownIsChecked = settings.IsBrownSelected;
            WhiteIsChecked = settings.IsWhiteSelected;
            GrayIsChecked = settings.IsGraySelected;
            RandomIsChecked = settings.IsRandomSelected;
        }

        void initializeGameLevel()
        {
            ColorExplorerIsChecked = ShadeSeekerIsChecked = HueHunterIsChecked = TintTrackerIsChecked = ChromaticMasterIsChecked = false;

            if (settings.GameLevel == GameLevel.ColorExplorer)
                ColorExplorerIsChecked = true;
            else if (settings.GameLevel == GameLevel.ShadeSeeker)
                ShadeSeekerIsChecked = true;
            else if (settings.GameLevel == GameLevel.HueHunter)
                HueHunterIsChecked = true;
            else if (settings.GameLevel == GameLevel.TintTracker)
                TintTrackerIsChecked = true;
            else if (settings.GameLevel == GameLevel.ChromaticMaster)
                ChromaticMasterIsChecked = true;
        }

        void CheckedCountChanged()
        {
            if (settings.ColorCount == settings.SelectedColorsCount())
                changeEnabilityOfCheckBoxes(false);
            else if (settings.ColorCount < settings.SelectedColorsCount())
            {
                settings.IsRandomSelected = true;
                RedCheckBoxEnabled = GreenCheckBoxEnabled = BlueCheckBoxEnabled = PinkCheckBoxEnabled = WhiteCheckBoxEnabled =
                    GrayCheckBoxEnabled = YellowCheckBoxEnabled = BrownCheckBoxEnabled = false;
                changeEnabilityOfCheckBoxes(false);
            }
            else
                changeEnabilityOfCheckBoxes(true);

        }

        void changeEnabilityOfCheckBoxes(bool AreAllEnable)
        {
            if (AreAllEnable)
            {
                RedCheckBoxEnabled = GreenCheckBoxEnabled = BlueCheckBoxEnabled = PinkCheckBoxEnabled = WhiteCheckBoxEnabled =
                    GrayCheckBoxEnabled = YellowCheckBoxEnabled = BrownCheckBoxEnabled = true;
                return;
            }

            RedCheckBoxEnabled = settings.IsRedSelected;
            GreenCheckBoxEnabled = settings.IsGreenSelected;
            BlueCheckBoxEnabled = settings.IsBlueSelected;
            PinkCheckBoxEnabled = settings.IsPinkSelected;
            WhiteCheckBoxEnabled = settings.IsWhiteSelected;
            GrayCheckBoxEnabled = settings.IsGraySelected;
            YellowCheckBoxEnabled = settings.IsYellowSelected;
            BrownCheckBoxEnabled = settings.IsBrownSelected;
        }

        #endregion

        #region Commands

        [RelayCommand]
        async Task GoBack() => await AppShell.Current.GoToAsync(".."); 

        [RelayCommand]
        void ResetColorsSettings()
        {
            settings.ResetColorsSettings();
            initializeColors();
        }

        [RelayCommand]
        void UncheckColors()
        {
            settings.ResetColors();
            initializeColors();
        }

        [RelayCommand]
        void ResetGameLevel()
        {
            settings.ResetGameLevel();
            initializeGameLevel();
        }

        [RelayCommand]
        void ResetSettings()
        {
            settings.ResetSettings();
            initializeSettings();
        }

        #endregion
    }
}
