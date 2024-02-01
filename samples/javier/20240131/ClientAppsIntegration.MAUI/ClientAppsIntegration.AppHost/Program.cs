using HolisticWare.Aspire.Hosting.Maui;

HolisticWare.Tools.Devices.Android.Emulator.Launch("nexus_9_api_33");
HolisticWare.Tools.Devices.Android.Emulator.Launch("Pixel_3a_API_34_extension_level_7_arm64-v8a");
    
System.Threading.Thread.Sleep(10000);

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
                "net8.0-android",
                "Pixel_3a_API_34_extension_level_7_arm64-v8a",
                2
            )
    .WithReference(apiService);

builder
    .BuildClient
            (
                "net8.0-android",
                "Pixel_3a_API_34_extension_level_7_arm64-v8a",
                2
            )
    .BuildClient
            (
                "net8.0-android",
                "Nexus_9_API_33"    // tablet
                // default = 1
            )
    .BuildClient
            (
                "net8.0-ios",
                "8DD23CF2-C0C4-4A5C-928C-4C8AC83EE8D0",                
                2
            )
    .BuildClient
            (
                "net8.0-ios",
                "4066B4FA-CCEF-4F1D-ABEA-BDE0E1471E33"  // iPad
            )
    .BuildClient("maccatalyst")
    ;


builder.Build().Run();