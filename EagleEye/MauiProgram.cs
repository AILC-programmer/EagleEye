using EagleEye.Pages;
using EagleEye.Pages.GamePlay;
using EagleEye.ViewModels;
using EagleEye.ViewModels.GamePlay;
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
                    fonts.AddFont("fa-regular-400.ttf", "FontIcon");
                    fonts.AddFont("solid.ttf", "SolidFontIcon");
                });

            #region Services

            // MainPage
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            // Settings page
            builder.Services.AddTransient<SettingsPage>();
            builder.Services.AddTransient<SettingsViewModel>();

            // About us page
            builder.Services.AddTransient<AboutUsPage>();
            builder.Services.AddTransient<AboutUsViewModel>();

            // Game list page
            builder.Services.AddTransient<GamesListPage>();
            builder.Services.AddTransient<GamesListViewModel>();

            // Remember colors page
            builder.Services.AddTransient<RememberColorsPage>();
            builder.Services.AddTransient<RememberColorsViewModel>();

            #endregion

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
