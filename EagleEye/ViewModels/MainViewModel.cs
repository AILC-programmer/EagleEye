using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace EagleEye.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [RelayCommand]
        async Task Play()
        {
            await Shell.Current.GoToAsync(nameof(GamePage));
        }

        [RelayCommand]
        async Task Settings()
        {
            await Shell.Current.GoToAsync(nameof(SettingsPage));
        }

        [RelayCommand]
        async Task AboutUs()
        {
            await Shell.Current.GoToAsync(nameof(AboutUsPage));
        }
    }
}
