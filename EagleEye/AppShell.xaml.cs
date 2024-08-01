using EagleEye.Pages;

namespace EagleEye
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(AboutUsPage), typeof(AboutUsPage));
        }
    }
}
