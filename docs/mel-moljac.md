# Template Mel

mel-moljac.md


```bash
rm -fr $HOME/.templateengine
```

```bash
dotnet new \
    uninstall \
        HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui
dotnet new \
    uninstall \
        HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.Bret

dotnet new \
    install \
        HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui::0.0.1-alpha-20240207114335

rm -fr Apps.CloudNative/
dotnet new \
    hw-aspire-clients-maui \
        --output Apps.CloudNative
```

```bash
dotnet build Apps.CloudNative/ClientAppsIntegration.sln

dotnet run \
    --project Apps.CloudNative/ClientAppsIntegration.AppHost/ClientAppsIntegration.AppHost.csproj
```



```xml
	<PropertyGroup>
		<EnableSplashScreenProcessing>false</EnableSplashScreenProcessing>
	</PropertyGroup>

```