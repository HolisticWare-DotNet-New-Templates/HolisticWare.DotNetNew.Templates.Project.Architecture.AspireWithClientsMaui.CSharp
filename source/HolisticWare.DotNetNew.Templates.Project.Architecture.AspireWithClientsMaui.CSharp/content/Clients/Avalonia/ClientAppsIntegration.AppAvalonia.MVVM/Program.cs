using Avalonia;
using Avalonia.ReactiveUI;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ClientAppsIntegration.AppAvalonia.MVVM;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) 
    {
        // Register your appsettings.json config file
        IConfigurationRoot configuration = new ConfigurationBuilder()
                                                            .AddJsonFile
                                                                (
                                                                    Path.Combine("Properties", "appsettings.json"), 
                                                                    optional: true, 
                                                                    reloadOnChange: true
                                                                )
                                                            .Build();

        // Create a service provider registering the service discovery and HttpClient extensions
        ServiceProvider provider = new ServiceCollection()
                                                .AddServiceDiscovery()
                                                .AddHttpClient()
                                                .AddSingleton<IConfiguration>(configuration)
                                                .ConfigureHttpClientDefaults
                                                    (
                                                        static http =>
                                                        {
                                                            // Configure the HttpClient to use service discovery
                                                            http.UseServiceDiscovery();
                                                        }
                                                    )
                                                .BuildServiceProvider();

        // Grab a new client from the service provider
        HttpClient client = provider.GetService<HttpClient>()!;

        // Call an API called `apiservice` using service discovery
        HttpResponseMessage response = client.GetAsync("http://apiservice/weatherforecast").Result;
        string body = response.Content.ReadAsStringAsync().Result;

        Console.WriteLine(body);

        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        return;
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI();
}
