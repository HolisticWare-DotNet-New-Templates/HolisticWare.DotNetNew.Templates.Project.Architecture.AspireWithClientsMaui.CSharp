# HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.CSharp

readme.md

Template for Aspire and Client[s] MAUI integration.

## Usage

Bret's approach

```
dotnet new \
    hw-aspire-clients-maui-bret \
        --output Apps.CloudNative.Bret
```

Bret's approach

```
dotnet new \
    hw-aspire-clients-maui \
        --output Apps.CloudNative
```

verification:

```
tree
```

creates:

```
```

## Installation

### NuGet published

```bash
dotnet tool \
    uninstall \
        --global \
            HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui
dotnet tool \
    install \
        --global \
            HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui
dotnet tool \
    uninstall \
        --global \
            HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.Bret
dotnet tool \
    install \
        --global \
            HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.Bret
```

### Local / Development

Bret's approach:

```bash
dotnet new \
    uninstall \
        source/HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.CSharp.Bret/content
        --force \
        -v:diagnostic

dotnet new \
    install \
        source/HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.CSharp.Bret/content \
        --force \
        -v:diagnostic
 ```

Moljac's:

```bash
dotnet new \
    uninstall \
        source/HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.CSharp/content
        --force \
        -v:diagnostic

dotnet new \
    install \
        source/HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.CSharp/content \
        --force \
        -v:diagnostic
 ```

### NuGet local

```bash
dotnet tool \
    uninstall \
        --global \
        --add-source ./output \
            HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.Bret
            
dotnet tool \
    install \
        --global \
        --add-source ./output \
            HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.Bret
```


## Details


### Build

```
git clean -xdf \
&& \
dotnet build \
    -c:release \
    source/HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.CSharp/HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.CSharp.csproj \
&& \
dotnet build \
    -c:release \
    source/HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.Bret.CSharp/HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.Bret.CSharp.csproj
```


### `dotnet new` templating

https://github.com/moljac/HolisticWare.WebSite.Notes/tree/master/dotnet-netfx/core/dotnet-new-templates
