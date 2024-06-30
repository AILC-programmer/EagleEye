using EagleEye.GamePages;

namespace EagleEye
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AboutUsPage), typeof(AboutUsPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(GamePage), typeof(GamePage));
            Routing.RegisterRoute(nameof(RememberColorGamePage), typeof(RememberColorGamePage));
        }
    }
}
