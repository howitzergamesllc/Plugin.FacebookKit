# Plugin.FacebookKit

#### Todo:


#### Bugs:



## Build the Project folders

### Navigate to your "projects" folder
```cmd
cd "C:\Path\to\your\projects"
```

### Make a directory to manage all the repos
```cmd
mkdir -p Plugin.FacebookKit
```

### Download/fork/pull the repo to a shortpath folder and document the base project repo filepath.
```cmd
git clone https://github.com/howitzergamesllc/Plugin.FacebookKit.git
```


## Clean Obj/Bin Folders:

Open terminal
```zsh
chmod + clean.sh
chmod + cleansamples.sh
./clean.sh
devenv /ClearCache
```


## Restore Project:

```zsh
cd "$HOME/Path/to/your/projects/Plugin.FacebookKit/Plugin.FacebookKit"
git fetch
git pull
dotnet restore Plugin.FacebookKit.sln
dotnet restore Plugin.FacebookKit.Nuget.sln
```


## Develop the nuget packages.

### First build the packages for source development.

Build the source code nuget packages using Nuget.Local.Config
Roslyn will analyze the source code using this solution in Visual Studio.
To develop the package select this solution in Visual Studio.
```zsh
dotnet build Plugin.FacebookKit.slnx --configfile Nuget.Config
```

### Clean the sample packages and clear the Nuget cache.
On windows, sometimes there are dotnet tasks running in the background that prevent clearing the Nuget cache. Just open task manager and end them.
```zsh
./cleansamples.ps1
dotnet nuget locals all -c
```

### Build the sample projects with official nugets.
This allows the plugin to be used locally for development.
When opening Visual Studio, select the nuget solution to test the final implementation.
```zsh
dotnet build Plugin.FacebookKit.Nuget.slnx --configfile Nuget.Local.Config
```


## Project Directories

```zsh
cd "$HOME/Path/to/your/projects/Plugin.FacebookKit/Plugin.FacebookKit/src/Plugin"
cd "$HOME/Path/to/your/projects/Plugin.FacebookKit/Plugin.FacebookKit/src/Core"
cd "$HOME/Path/to/your/projects/Plugin.FacebookKit/Plugin.FacebookKit/src/Login"
cd "$HOME/Path/to/your/projects/Plugin.FacebookKit/Plugin.FacebookKit/src/Share"
```


## Build Nuget Release Commands:

```zsh
dotnet build "src/Plugin/Plugin.csproj" -c release
dotnet build "src/Core/Core.csproj" -c release
dotnet build "src/Login/Login.csproj" -c release
dotnet build "src/Share/Share.csproj" -c release
```


## Debug

```zsh
dotnet build "src/Plugin/Plugin.csproj"
dotnet build "src/Core/Core.csproj"
dotnet build "src/Login/Login.csproj"
dotnet build "src/Share/Share.csproj"
```


## FacebookSamples

```zsh
dotnet build "samples\Login\LoginMauiSample\LoginMauiSample.csproj"
dotnet build "samples\Share\ShareMauiSample\ShareMauiSample.csproj"
```


## GitHub Publishing Commands

Repo root
```zsh
cd "$HOME/Path/to/your/projects/Plugin.FacebookKit/Plugin.FacebookKit"
```
Add the files to the local repository. CLRF warnings may appear stating it will auto apply if called again. Just call again.
```zsh
git add .
```    
This will tell you which folders are being tracked by git to ignore. Should see ".vs" and "obj". Update .gitignore file as necessary.
```zsh
git status
```
Commit files to the repository. Provided a summary of quantity of changes.
```zsh
git commit -m "Initial commit with project files"
```
Change branch to main if needed.
```zsh
git branch -m main
```
If errors about master directory then call this: git branch -m main
```zsh
git push -u origin main
```


## Push package for private publishing.

```zsh
dotnet nuget push "$HOME/Path/to/your/projects/Plugin.FacebookKit/Plugin.FacebookKit/src/Plugin/bin/release/Plugin.FacebookKit.10.0.110.nupkg" --source "https://nuget.pkg.github.com/youraccount/index.json" --api-key $GITHUBTOKEN
dotnet nuget push "$HOME/Path/to/your/projects/Plugin.FacebookKit/Plugin.FacebookKit/src/Core/bin/release/Plugin.FacebookKit.Core.10.0.110.nupkg" --source "https://nuget.pkg.github.com/youraccount/index.json" --api-key $GITHUBTOKEN
dotnet nuget push "$HOME/Path/to/your/projects/Plugin.FacebookKit/Plugin.FacebookKit/src/Login/bin/release/Plugin.FacebookKit.Login.10.0.110.nupkg" --source "https://nuget.pkg.github.com/youraccount/index.json" --api-key $GITHUBTOKEN
dotnet nuget push "$HOME/Path/to/your/projects/Plugin.FacebookKit/Plugin.FacebookKit/src/Share/bin/release/Plugin.FacebookKit.Share.10.0.110.nupkg" --source "https://nuget.pkg.github.com/youraccount/index.json" --api-key $GITHUBTOKEN
```


## Changing the solution

### Adding Projects

```zsh
dotnet sln Plugin.FacebookKit.slnx add src\Plugin\Plugin.csproj
```


### Removing Projects

```zsh
dotnet sln Plugin.FacebookKit.slnx remove src\Plugin\Plugin.csproj
```