using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using QApp.UI.Pages.Business.Service;
using QApp.UI.ViewModels.Business;

namespace QApp.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit(options =>
                {
                    options.SetShouldSuppressExceptionsInConverters(false);
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiMaps();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            //builder.UseSentry(options =>
            //{
            //    // The DSN is the only required setting.
            //    options.Dsn = "https://8dff6094f3706aa956fe83e04e295f50@o4506599958642688.ingest.sentry.io/4506599961591808";

            //    // Use debug mode if you want to see what the SDK is doing.
            //    // Debug messages are written to stdout with Console.Writeline,
            //    // and are viewable in your IDE's debug console or with 'adb logcat', etc.
            //    // This option is not recommended when deploying your application.
            //    options.Debug = true;

            //    // Set TracesSampleRate to 1.0 to capture 100% of transactions for performance monitoring.
            //    // We recommend adjusting this value in production.
            //    options.TracesSampleRate = 1.0;

            //    // Other Sentry options can be set here.
            //});

            builder.Services.AddSingleton<BusServiceListPage>();
            builder.Services.AddSingleton<BusServiceListViewModel>();

            return builder.Build();
        }

    }
}