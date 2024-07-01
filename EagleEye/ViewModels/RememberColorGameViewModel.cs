using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EagleEye.Models;
using EagleEye.Tools;

namespace EagleEye.ViewModels
{
    public partial class RememberColorGameViewModel : ObservableObject
    {
        SettingsModel settings;

        bool isPlaying = false;
        bool isPlayed = false;

        public RememberColorGameViewModel()
        {
            Colors = new GameColors();

            loadSettings();

            // Game level
            EasyTitleVisiblity = settings.gameLevel == Enums.GameLevel.Easy;
            MediumTitleVisiblity = settings.gameLevel == Enums.GameLevel.Medium;
            HardTitleVisiblity = settings.gameLevel == Enums.GameLevel.Hard;


            // colors
            RedVisiblity = settings.RedCheckBox || settings.RandomColorCheckBox;
            GreenVisiblity = settings.GreenCheckBox || settings.RandomColorCheckBox;
            BlueVisiblity = settings.BlueCheckBox || settings.RandomColorCheckBox;
            YellowVisiblity = settings.YellowCheckBox || settings.RandomColorCheckBox;
            PinkVisiblity = settings.PinkCheckBox || settings.RandomColorCheckBox;
            BrownVisiblity = settings.BrownCheckBox || settings.RandomColorCheckBox;
            WhiteVisiblity = settings.WhiteCheckBox || settings.RandomColorCheckBox;
            GrayVisiblity = settings.GrayCheckBox || settings.RandomColorCheckBox;

            loadGamePlayModel();
        }

        [ObservableProperty]
        GameColors colors;

        [ObservableProperty]
        GamePlayModel model;

        [ObservableProperty]
        Brush frameColor;

        [ObservableProperty]
        byte numberOfRecentGamePlays = 0;
        [ObservableProperty]
        int recentScores = 0;
        [ObservableProperty]
        byte successfulPlayed = 0;

        // Title

        [ObservableProperty]
        bool easyTitleVisiblity;
        [ObservableProperty]
        bool mediumTitleVisiblity;
        [ObservableProperty]
        bool hardTitleVisiblity;

        // colors

        [ObservableProperty]
        bool redVisiblity;
        [ObservableProperty]
        bool greenVisiblity;
        [ObservableProperty]
        bool blueVisiblity;
        [ObservableProperty]
        bool yellowVisiblity;
        [ObservableProperty]
        bool pinkVisiblity;
        [ObservableProperty]
        bool brownVisiblity;
        [ObservableProperty]
        bool whiteVisiblity;
        [ObservableProperty]
        bool grayVisiblity;

        //

        [ObservableProperty]
        bool checkButtonVisiblity;
        [ObservableProperty]
        bool playButtonEnabled;

        [RelayCommand]
        void Play()
        {
            isPlaying = true;
            NumberOfRecentGamePlays++;

            var numOfColorShows = RandomGenerator.NumberOfShow(settings.gameLevel);

            if (numOfColorShows == 0) return;

            for (int i = 0; i < numOfColorShows; i++)
            {
                setColor();
            }



        }

        [RelayCommand]
        void Check()
        {

        }

        void setColor()
        {
            if (!isPlaying) return;


        }

        async void loadSettings()
        {
            if(PathWorker.Instance.IsSettingsFileExists)
                settings =  ObjectSerializer.DeserializeObject<Models.SettingsModel>(PathWorker.Instance.GetSettingsFilePath);
            else
            {
                settings = new Models.SettingsModel()
                {
                    RandomColorCheckBox = true,
                    gameLevel = Enums.GameLevel.Easy,
                };

                await ObjectSerializer.SerializeObject(PathWorker.Instance.GetSettingsFilePath, settings);
            }
                
        }

        void loadGamePlayModel()
        {
            if(PathWorker.Instance.IsGamePlayFileExitst)
            {
                Model = ObjectSerializer.DeserializeObject<GamePlayModel>(PathWorker.Instance.GetGamePlayFilePath);
            }
        }
    }
}
