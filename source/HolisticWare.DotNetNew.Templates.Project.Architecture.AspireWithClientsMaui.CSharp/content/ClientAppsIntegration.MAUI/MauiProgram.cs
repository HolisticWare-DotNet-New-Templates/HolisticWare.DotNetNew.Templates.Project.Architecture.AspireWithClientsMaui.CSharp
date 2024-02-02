using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ClientAppsIntegration.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var mauiAppBuilder = MauiApp.CreateBuilder();

            mauiAppBuilder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            var wrapperMauiAppBuilder = new WrapperMauiAppBuilder(mauiAppBuilder);

            wrapperMauiAppBuilder.AddAppDefaults();

#if DEBUG
            wrapperMauiAppBuilder.Logging.AddDebug();
#endif

            var scheme = wrapperMauiAppBuilder.Environment.IsDevelopment() ? "http" : "https";

            //wrapperMauiAppBuilder.Services.AddHttpClient<WeatherApiClient>(client => client.BaseAddress = new($"{scheme}://apiservice"));
            #if ! __ANDROID__ 
            wrapperMauiAppBuilder.Services.AddHttpClient<WeatherApiClient>(client => client.BaseAddress = new($"{scheme}://localhost:5303"));
            #elif __ANDROID__
            wrapperMauiAppBuilder.Services.AddHttpClient<WeatherApiClient>(client => client.BaseAddress = new($"{scheme}://10.0.2.2:5303"));
            #endif
            // wrapperMauiAppBuilder.Services.AddHttpServiceReference<CatalogServiceClient>("http://catalogservice", healthRelativePath: "readiness");               

            wrapperMauiAppBuilder.Services.AddHttpClient<WeatherApiClient>(client => client.BaseAddress = new($"{scheme}://localhost:5303"));
            wrapperMauiAppBuilder.Services.AddSingleton<MainPage>();
            wrapperMauiAppBuilder.Services.AddSingleton<App>();

            MauiApp app = wrapperMauiAppBuilder.Build();

            /*
            WPF

            appHost.Start();
            app.Run(mainWindow);
            appHost.StopAsync().GetAwaiter().GetResult();
            */
            /*
            WinForms

            ApplicationConfiguration.Initialize();
            System.Windows.Forms.Application.Run(ActivatorUtilities.CreateInstance<MainForm>(app.Services));
            app.StopAsync().GetAwaiter().GetResult();
            */

            MainPage mp = ActivatorUtilities.CreateInstance<MainPage>(app.Services);
            App app_maui = ActivatorUtilities.CreateInstance<App>(app.Services);

            // app_maui.Run();

            return app;
        }
    }
}
