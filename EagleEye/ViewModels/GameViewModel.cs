using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EagleEye.GamePages;
using EagleEye.Models;
using EagleEye.Tools;

namespace EagleEye.ViewModels
{
    public partial class GameViewModel : ObservableObject
    {
        public GameViewModel()
        {
            loadGamePlayModel();
        }

        [ObservableProperty]
        GamePlayModel model;

        [RelayCommand]
        async Task RememberColorItem()
        {
            await Shell.Current.GoToAsync(nameof(RememberColorGamePage));
        }

        async void loadGamePlayModel()
        {
            if (PathWorker.Instance.IsGamePlayFileExitst)
            {
                ObjectSerializer.DeserializeObject<GamePlayModel>(PathWorker.Instance.GetGamePlayFilePath);
            }
            else
            {
                Model = new GamePlayModel()
                {
                    RCEScore = 0,
                    RCMScore = 0,
                    RCHScore = 0,
                };
                await ObjectSerializer.SerializeObject(PathWorker.Instance.GetGamePlayFilePath, Model);
            }
        }
    }
}
