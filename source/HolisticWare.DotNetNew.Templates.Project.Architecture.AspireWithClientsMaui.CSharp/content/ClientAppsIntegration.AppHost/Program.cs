using HolisticWare.Aspire.Hosting.Maui;

// HolisticWare.Tools.Devices.Android.Emulator.Launch("nexus_9_api_33");
HolisticWare.Tools.Devices.Android.Emulator.Launch("Pixel_3a_API_34_extension_level_7_arm64-v8a");

var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.ClientAppsIntegration_ApiService>("apiservice");

// Register the client apps by project path as they target a TFM incompatible with the AppHost so can't be added as
// regular project references (see the AppHost.csproj file for additional metadata added to the ProjectReference to
// coordinate a build dependency though).

string project_maui = @"..\\ClientAppsIntegration.MAUI\\ClientAppsIntegration.MAUI.csproj";

builder
   .AddProject
         (
            "frontend_client_maui",
            project_maui,
            // overload added just to avoid ambigious call and leave the method name as is
            // without this parameter - ambigious call
            new[] 
            {
               "net8.0-android",
               "net8.0-ios",
               "net8.0-maccatalyst",
            }
         )
         .WithReference(apiService);

builder
   .BuildClient
         (
            "net8.0-android",
            "Pixel_3a_API_34_extension_level_7_arm64-v8a"
         )         
   /*
   Launching 2 emulators does not work yet
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