using EagleEye.Pages;
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
                    fonts.AddFont("fa-regular-400.ttf", "FontIcon");
                    fonts.AddFont("solid.ttf", "SolidFontIcon");
                });

            #region Services

            // MainPage
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            // Settings page
            builder.Services.AddTransient<SettingsPage>();
            builder.Services.AddSingleton<SettingsViewModel>();

            // About us page
            builder.Services.AddTransient<AboutUsPage>();
            builder.Services.AddTransient<AboutUsViewModel>();


            #endregion

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
