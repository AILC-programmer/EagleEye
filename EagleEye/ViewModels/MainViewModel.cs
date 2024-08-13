using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EagleEye.Models;
using EagleEye.Pages;
using EagleEye.Pages.GamePlay;
using EagleEye.Tools;

namespace EagleEye.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            LoadModel();
        }

        [ObservableProperty]
        UserModel user = new UserModel();

        [RelayCommand]
        async Task GoToSettings() => await AppShell.Current.GoToAsync(nameof(SettingsPage));

        [RelayCommand]
        async Task GoToAboutUs() => await AppShell.Current.GoToAsync(nameof(AboutUsPage));

        [RelayCommand]
        async Task GoToGamesList() => await AppShell.Current.GoToAsync(nameof(GamesListPage));

        void LoadModel()
        {
            var result = ObjectSerializer.DeserializeObject<UserModel>(PathWorker.Instance.GetUserFilePath);
            if (result != null)
                User = result;
            else
            {
                User = new UserModel()
                {
                    Username = "User",
                };
                saveModel();
            }
        }

        async void saveModel() => await ObjectSerializer.SerializeObject(PathWorker.Instance.GetUserFilePath, User);
    }
}
