


```
dotnet new \
    uninstall \
        HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.Bret

dotnet new \
    install \
        HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.Bret::0.0.1-alpha-20240207114335

dotnet new \
    hw-aspire-clients-maui-bret \
        --output Apps.CloudNative.Bret
```

```
dotnet build Apps.CloudNative.Bret/

dotnet run \
    --project Apps.CloudNative.Bret/ClientAppsIntegration.AppHost/ClientAppsIntegration.AppHost.csproj
```