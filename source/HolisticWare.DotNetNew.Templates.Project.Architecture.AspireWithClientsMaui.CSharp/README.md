<!-- 
Provide an overview of what your template package does and how to get started.
Consider previewing the README before uploading 
(https://learn.microsoft.com/en-us/nuget/nuget-org/package-readme-on-nuget-org#preview-your-readme). 
-->

Template for Aspire and client MAUI integration.

Based on

```shell
dotnet new aspire-starter -o Apps.AspireStarter
mkdir Clients
dotnet new maui -o Clients/Apps.MAUI
```



```
./source/content/Apps.AspireStarter/Apps.AspireStarter.AppHost/Apps.AspireStarter.AppHost.csproj : error NU1201: Project Apps.MAUI is not compatible with net8.0 (.NETCoreApp,Version=v8.0). Project Apps.MAUI supports:
./source/content/Apps.AspireStarter/Apps.AspireStarter.AppHost/Apps.AspireStarter.AppHost.csproj : error NU1201:   - net8.0-android34.0 (.NETCoreApp,Version=v8.0)
./source/content/Apps.AspireStarter/Apps.AspireStarter.AppHost/Apps.AspireStarter.AppHost.csproj : error NU1201:   - net8.0-ios17.2 (.NETCoreApp,Version=v8.0)
./source/content/Apps.AspireStarter/Apps.AspireStarter.AppHost/Apps.AspireStarter.AppHost.csproj : error NU1201:   - net8.0-maccatalyst17.2 (.NETCoreApp,Version=v8.0)

The build failed. Fix the build errors and run again.
```