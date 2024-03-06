

```
dotnet new list | grep avalonia
```

```
Avalonia .NET App   avalonia.app                  [C#],F#     Desktop/Xaml/Avalonia/Windows/Linux/macOS                                                                                                
Avalonia .NET M...  avalonia.mvvm                 [C#],F#     Desktop/Xaml/Avalonia/Windows/Linux/macOS                                                                                                
Avalonia Cross ...  avalonia.xplat                [C#],F#     Desktop/Xaml/Avalonia/Web/Mobile                                                                                                         
Avalonia Resour...  avalonia.resource                         Desktop/Xaml/Avalonia/Windows/Linux/macOS                                                                                                
Avalonia Styles     avalonia.styles                           Desktop/Xaml/Avalonia/Windows/Linux/macOS                                                                                                
Avalonia Templa...  avalonia.templatedcontrol     [C#],F#     Desktop/Xaml/Avalonia/Windows/Linux/macOS                                                                                                
Avalonia UserCo...  avalonia.usercontrol          [C#],F#     Desktop/Xaml/Avalonia/Windows/Linux/macOS                                                                                                
Avalonia Window     avalonia.window               [C#],F#     Desktop/Xaml/Avalonia/Windows/Linux/macOS                                                                                                
Epoxy.Avalonia ...  epoxy-avalonia                [C#],F#     Epoxy/Avalonia/XAML/Desktop                                                                                                              
Epoxy.Avalonia1...  epoxy-avalonia11              [C#],F#     Epoxy/Avalonia/XAML/Desktop/Web/Mobile 
```

dotnet new avalonia.app -o ClientAppsIntegration.AppAvalonia
dotnet new avalonia.mvvm -o ClientAppsIntegration.AppAvalonia.MVVM
dotnet new avalonia.xplat -o ClientAppsIntegration.AppAvalonia.XPlat