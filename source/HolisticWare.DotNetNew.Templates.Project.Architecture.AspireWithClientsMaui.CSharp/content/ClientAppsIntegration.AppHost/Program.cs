using HolisticWare.Aspire.Hosting.Maui;

// HolisticWare.Tools.Devices.Android.Emulator.Launch("nexus_9_api_33");
HolisticWare.Tools.Devices.Android.Emulator.Launch("emulator-android-34-google-apis-arm-v8a-pixel");

var builder = DistributedApplication.CreateBuilder(args);

var apiservice = builder.AddProject<Projects.ClientAppsIntegration_ApiService>("apiservice");

var web_frontnend = builder
                        .AddProject<Projects.ClientAppsIntegration_Web>
                                                         (
                                                            "webfrontend"
                                                         )
                                                         .WithReference(apiservice);

// Register the client apps by project path as they target a TFM incompatible with the AppHost so can't be added as
// regular project references (see the AppHost.csproj file for additional metadata added to the ProjectReference to
// coordinate a build dependency though).

string project_maui_simple = @"..\\Clients\\MAUI\\ClientAppsIntegration.MAUI.Simple\\ClientAppsIntegration.MAUI.Simple.csproj";
string project_maui_refactored = @"..\\Clients\\MAUI\\ClientAppsIntegration.MAUI.Refactored\\ClientAppsIntegration.MAUI.Refactored.csproj";
string project_maui_blazor = @"..\\Clients\\MAUI\\ClientAppsIntegration.MAUI.Blazor\\ClientAppsIntegration.MAUI.Blazor.csproj";

string project_avalonia = @"..\\Clients\\Avalonia\\ClientAppsIntegration.AppAvalonia\\ClientAppsIntegration.AppAvalonia.csproj";
string project_avalonia_mvvm = @"..\\Clients\\Avalonia\\ClientAppsIntegration.AppAvalonia.MVVM\\ClientAppsIntegration.AppAvalonia.MVVM.csproj";

builder
   .AddProject
         (
            "frontend_client_console",
            @"..\\Clients\\Console\\ClientAppsIntegration.AppConsole\\ClientAppsIntegration.AppConsole.csproj"
         )
         .WithReference(apiservice);

builder
   .AddProject
         (
            "frontend_client_maui_simple",
            project_maui_simple,
            // overload added just to avoid ambigious call and leave the method name as is
            // without this parameter - ambigious call
            new[] 
            {
               "net8.0-android",
               "net8.0-ios",
               "net8.0-maccatalyst",
            }
         )
         .WithReference(apiservice);

builder
   .AddProject
         (
            "frontend_client_maui_refactored",
            project_maui_refactored,
            // overload added just to avoid ambigious call and leave the method name as is
            // without this parameter - ambigious call
            new[] 
            {
               "net8.0-android",
               "net8.0-ios",
               "net8.0-maccatalyst",
            }
         )
         .WithReference(apiservice);

/*
Problems - not working yet - MAUI Blazor
must recreate projects

builder
   .AddProject
         (
            "frontend_client_maui_blazor",
            project_maui_blazor,
            // overload added just to avoid ambigious call and leave the method name as is
            // without this parameter - ambigious call
            new[] 
            {
               "net8.0-android",
               "net8.0-ios",
               "net8.0-maccatalyst",
            }
         )
         .WithReference(apiservice);
*/

builder
   .AddProject
         (
            "frontend_client_avalonia",
            project_avalonia
         )
         .WithReference(apiservice);

builder
   .AddProject
         (
            "frontend_client_avalonia_mvvm",
            project_avalonia_mvvm
         )
         .WithReference(apiservice);






builder
   .BuildClient
         (
            "net8.0-android",
            "emulator-android-34-google-apis-arm-v8a-pixel_xl"
         )         
   /*
   Launching n=2 emulators does not work yet
   .BuildClient
         (
            "net8.0-android",
            "Nexus_9_API_33"     // tablet
            2                    // default = 1
         )
   */
   .BuildClient
         (
            "net8.0-ios",
            "017184FB-06E4-4C88-9662-13C1E2444486",
            2
         )
   .BuildClient
         (
            "net8.0-ios",
            "43A58A15-E4EA-4FDD-9DBD-5E8C16CBAF98"  // iPad
         )
   .BuildClient("maccatalyst")
   ;

builder
   // intercepting Build() to build/launch MAUI clients defined above
   // .Build()
   .BuildDistributedAppWithClientsMAUI()
   .Run();