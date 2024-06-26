﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EagleEye.Models;
using EagleEye.Tools;
using System.ComponentModel;

namespace EagleEye.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {
        byte SelectedColorsCount = 0;
        Models.SettingsModel model;

        [ObservableProperty]
        string[] numOfColors;

        [ObservableProperty]
        GameColors colors;

        public SettingsViewModel()
        {
            NumOfColors = new string[] { "3", "4", "5", "6", "7" };

            LoadModel();

            Colors = new GameColors();
            NumOfColorsSelectedIndex = 0;
            EasyRadioButton = true;

            if (!(RedCheckBox || BlueCheckBox || GreenCheckBox || PinkCheckBox || WhiteCheckBox || 
                GrayCheckBox || YellowCheckBox || BrownCheckBox) && !RandomColorCheckBox)
                changeEnabilityOfCheckBoxes(true);
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            switch (e.PropertyName)
            {
                case nameof(RedCheckBox):
                    {
                        if (RedCheckBox)
                            SelectedColorsCount++;
                        else
                            SelectedColorsCount--;
                        CheckedCountChanged();
                    }
                    break;
                case nameof(GreenCheckBox):
                    {
                        if (GreenCheckBox)
                            SelectedColorsCount++;
                        else
                            SelectedColorsCount--;
                        CheckedCountChanged();
                    }
                    break;
                case nameof(BlueCheckBox):
                    {
                        if (BlueCheckBox)
                            SelectedColorsCount++;
                        else
                            SelectedColorsCount--;
                        CheckedCountChanged();
                    }
                    break;
                case nameof(PinkCheckBox):
                    {
                        if (PinkCheckBox)
                            SelectedColorsCount++;
                        else
                            SelectedColorsCount--;
                        CheckedCountChanged();
                    }
                    break;
                case nameof(WhiteCheckBox):
                    {
                        if (WhiteCheckBox)
                            SelectedColorsCount++;
                        else
                            SelectedColorsCount--;
                        CheckedCountChanged();
                    }
                    break;
                case nameof(GrayCheckBox):
                    {
                        if (GrayCheckBox)
                            SelectedColorsCount++;
                        else
                            SelectedColorsCount--;
                        CheckedCountChanged();
                    }
                    break;
                case nameof(YellowCheckBox):
                    {
                        if (YellowCheckBox)
                            SelectedColorsCount++;
                        else
                            SelectedColorsCount--;
                        CheckedCountChanged();
                    }
                    break;
                case nameof(BrownCheckBox):
                    {
                        if (BrownCheckBox)
                            SelectedColorsCount++;
                        else
                            SelectedColorsCount--;
                        CheckedCountChanged();
                    }
                    break;
                case nameof(NumOfColorsSelectedIndex):
                    CheckedCountChanged();
                    break;
                case nameof(RandomColorCheckBox):
                    {
                        if (!RandomColorCheckBox)
                        {
                            changeEnabilityOfCheckBoxes(true);
                            break;
                        }

                        setColorsCheck(false);
                        
                        changeEnabilityOfCheckBoxes(false);
                    }
                    break;
                default:
                    break;
            }
        }

        #region Observable properties

        [ObservableProperty]
        byte numOfColorsSelectedIndex;
        [ObservableProperty]
        bool easyRadioButton;
        [ObservableProperty]
        bool mediumRadioButton;
        [ObservableProperty]
        bool hardRadioButton;
        [ObservableProperty]
        bool redCheckBox;
        [ObservableProperty]
        bool greenCheckBox;
        [ObservableProperty] 
        bool blueCheckBox;
        [ObservableProperty]
        bool pinkCheckBox;
        [ObservableProperty]
        bool whiteCheckBox;
        [ObservableProperty]
        bool grayCheckBox;
        [ObservableProperty]
        bool yellowCheckBox;
        [ObservableProperty]
        bool brownCheckBox;
        [ObservableProperty]
        bool randomColorCheckBox;
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

        void CheckedCountChanged()
        {
            if (int.Parse(NumOfColors[NumOfColorsSelectedIndex]) == SelectedColorsCount)
                changeEnabilityOfCheckBoxes(false);
            else if (int.Parse(NumOfColors[NumOfColorsSelectedIndex]) < SelectedColorsCount)
            {
                RandomColorCheckBox = true;
                RedCheckBoxEnabled = GreenCheckBoxEnabled = BlueCheckBoxEnabled = PinkCheckBoxEnabled = WhiteCheckBoxEnabled =
                    GrayCheckBoxEnabled = YellowCheckBoxEnabled = BrownCheckBoxEnabled = false;
                changeEnabilityOfCheckBoxes(false);
            }
            else
                changeEnabilityOfCheckBoxes(true);

        }

        void changeEnabilityOfCheckBoxes(bool enability)
        {
            if (enability)
            {
                RedCheckBoxEnabled = GreenCheckBoxEnabled = BlueCheckBoxEnabled = PinkCheckBoxEnabled = WhiteCheckBoxEnabled =
                    GrayCheckBoxEnabled = YellowCheckBoxEnabled = BrownCheckBoxEnabled = true;
                return;
            }

            RedCheckBoxEnabled = RedCheckBox;
            GreenCheckBoxEnabled = GreenCheckBox;
            BlueCheckBoxEnabled = BlueCheckBox;
            PinkCheckBoxEnabled = PinkCheckBox;
            WhiteCheckBoxEnabled = WhiteCheckBox;
            GrayCheckBoxEnabled = GrayCheckBox;
            YellowCheckBoxEnabled = YellowCheckBox;
            BrownCheckBoxEnabled = BrownCheckBox;
        }

        void setColorsCheck(bool isCheck)
        {
            RedCheckBox = GreenCheckBox = BlueCheckBox = PinkCheckBox = WhiteCheckBox = GrayCheckBox =
                YellowCheckBox = BrownCheckBox = isCheck;
        }

        void LoadModel()
        {
            var result = ObjectSerializer.DeserializeObject<Models.SettingsModel>(PathWorker.Instance.GetSettingsFilePath);
            if(result != null)
                model = result;
            else
                model =  new Models.SettingsModel();

            updateModel(false);
        }

        [RelayCommand]
        async Task Save()
        {
            if (int.Parse(NumOfColors[NumOfColorsSelectedIndex]) != SelectedColorsCount && !RandomColorCheckBox)
            {
                var res = await Shell.Current.DisplayAlert("Selected colors", "The number of selected colors does not match the specified number.\n" +
                    "If you wish to continue, the system will save the random color options.\n" +
                    "Do you want to continye?", "Yes", "No");
                
                if (!res)
                    return;

                setColorsCheck(false);

                RandomColorCheckBox = true;
            }
            updateModel(true);
            await ObjectSerializer.SerializeObject(PathWorker.Instance.GetSettingsFilePath, model);

            await Shell.Current.GoToAsync("..");
        }

        void updateModel(bool isForSave)
        {
            if (isForSave)
            {
                model.NumOfColorsSelectedIndex = NumOfColorsSelectedIndex;
                if (EasyRadioButton)
                    model.gameLevel = Enums.GameLevel.Easy;
                else if (MediumRadioButton)
                    model.gameLevel = Enums.GameLevel.Medium;
                else if (HardRadioButton)
                    model.gameLevel = Enums.GameLevel.Hard;
                model.BlueCheckBox = BlueCheckBox;
                model.GreenCheckBox = GreenCheckBox;
                model.PinkCheckBox = PinkCheckBox;
                model.WhiteCheckBox = WhiteCheckBox;
                model.GrayCheckBox = GrayCheckBox;
                model.YellowCheckBox = YellowCheckBox;
                model.BrownCheckBox = BrownCheckBox;
                model.RandomColorCheckBox = RandomColorCheckBox;
            }
            else
            {
                NumOfColorsSelectedIndex = model.NumOfColorsSelectedIndex;
                if (model.gameLevel == Enums.GameLevel.Easy)
                    EasyRadioButton = true;
                else if(model.gameLevel == Enums.GameLevel.Medium)
                    MediumRadioButton = true;
                else if(model.gameLevel == Enums.GameLevel.Hard)
                    HardRadioButton = true;
                RedCheckBox = model.RedCheckBox;
                GreenCheckBox = model.GreenCheckBox;
                BlueCheckBox = model.BlueCheckBox;
                PinkCheckBox = model.PinkCheckBox;
                WhiteCheckBox = model.WhiteCheckBox;
                GrayCheckBox = model.GrayCheckBox;
                YellowCheckBox = model.YellowCheckBox;
                BrownCheckBox = model.BrownCheckBox;
                RandomColorCheckBox = model.RandomColorCheckBox;
            }

        }

        [RelayCommand]
        async Task Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
