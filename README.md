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


```
dotnet new \
    hw-aspire-clients-maui \
        --output Apps.CloudNative
dotnet new \
    hw-aspire-clients-maui-bret \
        --output Apps.CloudNative.Bret
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
dotnet new \
    uninstall \
        HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui
dotnet new \
    uninstall \
        HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.Bret

dotnet new list


dotnet new \
    install \
        HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui::0.0.1-alpha-20240207110725
            
dotnet new \
    install \
        HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.Bret::0.0.1-alpha-20240207110730

dotnet new list
```

### Local / Development

Bret's approach:

```bash
dotnet new \
    uninstall \
        source/HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.CSharp.Bret/content
]        -v:diagnostic

dotnet new \
    install \
        source/HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.CSharp.Bret/content \
        -v:diagnostic
 ```

Moljac's:

```bash
dotnet new \
    uninstall \
        source/HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.CSharp/content
        -v:diagnostic

dotnet new \
    install \
        source/HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.CSharp/content \
        -v:diagnostic

```

### NuGet local

```bash
dotnet new \
    uninstall \
        -v:diagnostic \
        --add-source ./output \
            HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.Bret
            
dotnet new \
    install \
        -v:diagnostic \
        --add-source ./output \
            HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.Bret
```


## Details


### Build

Quick-n-dirty:

```
git clean -xdf \
&& \
dotnet build \
    -v:diagnostic \
    -c:release \
    source/HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.CSharp/HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.CSharp.csproj \
&& \
dotnet build \
    -v:diagnostic \
    -c:release \
    source/HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.Bret.CSharp/HolisticWare.DotNetNew.Templates.Project.Architecture.AspireWithClientsMaui.Bret.CSharp.csproj
```

A bit more:

```
git clean -xdf && dotnet cake

```

### `dotnet new` templating

https://github.com/moljac/HolisticWare.WebSite.Notes/tree/master/dotnet-netfx/core/dotnet-new-templates
