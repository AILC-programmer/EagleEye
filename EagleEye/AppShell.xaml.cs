using EagleEye.Pages;
using EagleEye.Pages.GamePlay;
using EagleEye.Settings;

namespace EagleEye
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(AboutUsPage), typeof(AboutUsPage));
            Routing.RegisterRoute(nameof(GamesListPage), typeof(GamesListPage));
            Routing.RegisterRoute(nameof(RememberColorsPage), typeof(RememberColorsPage));
        }

        protected async override void OnNavigating(ShellNavigatingEventArgs args)
        {
            base.OnNavigating(args);
            if (Shell.Current == null) return;
            if (Shell.Current.CurrentState.Location.OriginalString == $"//{nameof(MainPage)}/{nameof(SettingsPage)}")
            {
                var settings = GamePlaySettings.Instance;

                if (!settings.IsOK)
                {
                    await Shell.Current.DisplayAlert("Settings not set!", "The number of selected colors does not match the specified number.\n" +
                            "The system will save the random color options.", "OK");
                    settings.IsRandomSelected = true;
                }
            }
        }
    }
}
