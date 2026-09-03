# Plugin


## Nuget

Installing using the dotnet command line interface.
```zsh
dotnet package add Plugin.FacebookKit
```


## Setup

Basic Facebook Setup instructions: [BasicSetup](https://developers.facebook.com/documentation/ios/getting-started)
Follow the basic Plugin.FacebookKit instructions for installing here [BasicPluginSetup](https://github.com/howitzergamesllc/Plugin.FacebookKit/blob/main/Readme.md)

### Facebook Controls

When bundling, UseFacebookLoginControls and UseFacebookShareControls can be simplified to UseFacebookControls.
```c#
using Plugin.FacebookKit;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        return MauiApp
            .CreateBuilder()
            .UseMauiApp<App>()
            ...
            .UseFacebookControls()
            .Build();
    }
}
```
