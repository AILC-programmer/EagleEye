using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EagleEye.Models;
using EagleEye.Pages.GamePlay;
using EagleEye.Tools;

namespace EagleEye.ViewModels.GamePlay
{
    public partial class GamesListViewModel : ObservableObject
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public GamesListViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            loadUser();
        }

        [ObservableProperty]
        UserModel user;

        [RelayCommand]
        async Task GoToRemeberColors()
        {
            await AppShell.Current.GoToAsync(nameof(RememberColorsPage));
        }

        private void loadUser()
        {
            User = ObjectSerializer.DeserializeObject<UserModel>(PathWorker.Instance.GetUserFilePath);
        }
    }
}
