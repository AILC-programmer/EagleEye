using EagleEye.GamePages;
using EagleEye.ViewModels;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace EagleEye
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSkiaSharp()
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
            // Remember color page
            builder.Services.AddTransient<RememberColorGamePage>();
            builder.Services.AddTransient<RememberColorGameViewModel>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
