# Details

readme.md

*   motivation - use cases

    *   repro samples for issues (.NET TFMs)

    *   side projects 
    
        *   architecture

            *   libraries 
            
                *   business/domain logic

                *   UI interface - controls

        *   project strucutre

            *   samples + tests

                *   `<ProjectReferences>`s

                *   `<PackageReferences>`s

        *   learning/playing with various 
        
            *   UI frameworks

                *   Maui (priority #1)

                *   Xamarin.Forms

                *   Avalonia

                *   Uno

                *   Blazor

                *   Comet

            *   architectures

                *   microservices

                *   monolith



## Sample
```
├── net6.0
│   ├── begin
│   │   └── AppMAUI.Issue752_KotlinGeneratedByMoreThan
│   ├── end-20230727
│   │   ├── AppMAUI.Issue752_KotlinGeneratedByMoreThan
│   ├── global.json
├── net7.0
│   ├── begin
│   │   ├── AppMAUI.Issue752_KotlinGeneratedByMoreThan
│   ├── end
│   │   ├── AppMAUI.Issue752_KotlinGeneratedByMoreThan
│   └── global.json
├── net8.0
│   ├── begin
│   │   └── AppMAUI.Issue752_KotlinGeneratedByMoreThan
│   └── global.json
```

Details (real world sample):

```
├── net6.0
│   ├── begin
│   │   └── AppMAUI.Issue752_KotlinGeneratedByMoreThan
│   ├── end-20230727
│   │   ├── AppMAUI.Issue752_KotlinGeneratedByMoreThan
│   │   ├── log.txt
│   │   └── msbuild.binlog
│   ├── global.json
│   └── project.assets.json
├── net7.0
│   ├── begin
│   │   ├── AppMAUI.Issue752_KotlinGeneratedByMoreThan
│   │   └── project.assets.json
│   ├── end
│   │   ├── AppMAUI.Issue752_KotlinGeneratedByMoreThan
│   │   └── project.assets.json
│   ├── end-20230727
│   │   ├── AppMAUI.Issue752_KotlinGeneratedByMoreThan
│   │   ├── log.txt
│   │   ├── msbuild.binlog
│   │   └── project.assets.json
│   └── global.json
├── net8.0
│   ├── begin
│   │   └── AppMAUI.Issue752_KotlinGeneratedByMoreThan
│   └── global.json
```