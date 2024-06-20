using EagleEye.ViewModels;
using Microsoft.Extensions.Logging;

namespace EagleEye
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Main page
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();
            // Settings page
            builder.Services.AddTransient<SettingsPage>();
            builder.Services.AddTransient<SettingsViewModel>();
            // Game page
            builder.Services.AddTransient<GamePage>();
            builder.Services.AddTransient<GameViewModel>();
            // About us page
            builder.Services.AddTransient<AboutUsPage>();
            builder.Services.AddTransient<AboutUsVIewModel>();


#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
