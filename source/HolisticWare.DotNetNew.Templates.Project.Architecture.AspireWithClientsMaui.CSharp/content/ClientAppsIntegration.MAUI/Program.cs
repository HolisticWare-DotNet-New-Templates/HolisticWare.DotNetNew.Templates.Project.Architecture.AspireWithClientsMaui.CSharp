#if IOS || MACCATALYST
using ObjCRuntime;
using UIKit;
#endif

using System;
using System.Diagnostics.Metrics;
using System.Net.Http;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Logs;
using OpenTelemetry.Trace;
using OpenTelemetry.Resources;

namespace ClientAppsIntegration.MAUI;


internal class Program
{
    // This is the main entry point of the application.
    public static void Main(string[] args)
    {
        // -------------------------------------------------------------------------------------------------------------
        // Hosting
        //  start
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();

        builder.AddAppDefaults();
        
        string scheme = builder.Environment.IsDevelopment() ? "http" : "https";

        Uri endpoint = new($"{scheme}://apiservice");
        /*
        builder.Services.AddHttpClient<BasketServiceApiClient>(client => client.BaseAddress = endpoint);
        builder.Services
                .AddHttpServiceReference<CatalogServiceClient>("http://catalogservice", healthRelativePath: "readiness");

        builder.Services
                .AddSingleton<BasketServiceClient>()
                .AddGrpcServiceReference<Basket.BasketClient>("http://basketservice", failureStatus: HealthStatus.Degraded);
        */
        
        // WPF
        /*
        builder.Services.AddSingleton<App>();
        builder.Services.AddSingleton<MainPage>();
        */
        
        using
            ILoggerFactory loggerFactory = LoggerFactory.Create
                                                            (
                                                                builder => 
                                                                {
                                                                    builder.AddOpenTelemetry
                                                                                (
                                                                                    options => 
                                                                                    {
                                                                                    options.AddConsoleExporter();
                                                                                    }
                                                                                );
                                                                }
                                                            );

        ILogger<Program> logger = loggerFactory.CreateLogger < Program > ();

        logger.LogInformation("Hello from OpenTelemetry");



        Meter MauiMeter = new("ConsoleDemo.Metrics", "1.0");

        Counter<long> RequestCounter = MauiMeter.CreateCounter<long>("RequestCounter");

        using MeterProvider meterProvider = Sdk
                                                .CreateMeterProviderBuilder()
                                                .AddMeter("ConsoleDemo.Metrics")
                                                .AddConsoleExporter()
                                                .Build();

        RequestCounter.Add(1, new KeyValuePair<string, object?>("POST Request", HttpMethod.Post));
        RequestCounter.Add(1, new KeyValuePair<string, object?>("GET Request", HttpMethod.Get));
        RequestCounter.Add(1, new KeyValuePair<string, object?>("GET Request", HttpMethod.Get));
        RequestCounter.Add(1, new KeyValuePair<string, object?>("POST Request", HttpMethod.Post));
        RequestCounter.Add(1, new KeyValuePair<string, object?>("PUT Request", HttpMethod.Put));

        const string serviceName = "maui-telemetry";

        builder.Logging.AddOpenTelemetry
                            (
                                options =>
                                {
                                    options
                                        .SetResourceBuilder
                                            (
                                                ResourceBuilder
                                                        .CreateDefault()
                                                        .AddService(serviceName)
                                            )
                                            .AddConsoleExporter();
                                }
                            );
        builder.Services
                    .AddOpenTelemetry()
                    .ConfigureResource(resource => resource.AddService(serviceName))
                    .WithTracing
                        (
                            tracing => 
                            tracing
                                .AddGrpcClientInstrumentation()
                                .AddConsoleExporter()
                        )
                    .WithMetrics
                        (
                            metrics =>
                            metrics
                                .AddHttpClientInstrumentation()
                                .AddConsoleExporter()
                        );



        IHost app_host = builder.Build();

        // WinForms
        /*
        */

        // WPF
        /*
        App app = app_host.Services.GetRequiredService<App>();
        Page page = app_host.Services.GetRequiredService<MainPage>();
        
        app_host.Start();
        app.Run(page);
       */

        //  stop
        // Hosting
        // -------------------------------------------------------------------------------------------------------------

        /*
            Original MAUI code:

            No Program.cs
        */

        #if ANDROID
        Microsoft.Maui.Hosting.MauiApp app_maui = CreateMauiApp();
        #endif

        #if IOS
        ProgramiOS.MainiOS(args);
        #endif

        #if MACCATALYST
        ProgramMacCatalyst.MainMacCatalyst(args);
        #endif
        
        #if TIZEN
        ProgramTizen.MainTizen(args);
        #endif

        Services = app_host.Services;
        app_host.Start();
        app_host.Run();
        
        // app_host.StopAsync().GetAwaiter().GetResult();

        return;
    }

    #if TIZEN
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    #endif

    public static IServiceProvider Services { get; private set; } = default!;

    public static Microsoft.Maui.Hosting.MauiApp CreateMauiApp()
    {
        return MauiProgram.CreateMauiApp();
    }
}