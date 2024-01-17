using DailyDoseOfMyLife.View;
using Microsoft.Extensions.Logging;

namespace DailyDoseOfMyLife
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<AddEventPage>();
            builder.Services.AddSingleton<CalendarPage>();
            builder.Services.AddSingleton<ProfilePage>();
            builder.Services.AddTransient<LoginPage>();
            return builder.Build();
        }
    }
}
