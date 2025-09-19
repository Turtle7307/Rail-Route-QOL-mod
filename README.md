# Rail Route QOL mod
This is a mod for the game [Rail Route](https://store.steampowered.com/app/1124180/Rail_Route/) that aims to improve the gameplay.

## Current Changes
* The Arrival Sensor is now placable on a Stations Tracks
* The Shunting Sensor is changed to trigger on Contact and Departure instead of Contact and Arrival.  
(The Shunting sensor will trigger later then other sensors and overwrite the previously set path)

## How to Install
Download the latest version of the mod and go to the mods folder of Rail Route. If the mods folder does not exist create it. Finaly extract the zip into the mods folder so that a folder with the name `Rail Route QOL mod` is created containing `0Harmony.dll` and `Rail_Route_QOL_mod.dll`.

Mods folder on Windows:
```
%USERPROFILE%/AppData/LocalLow/bitrich/Rail Route/mods
```
Mods folder on Linux:
```
$HOME/.config/unity3d/bitrich/Rail Route/mods
```

## Building the Mod from Source
To build the mod you need to have the games `RailRoute.dll`, `UnityEngine.dll` and `UnityEngine.CoreModule.dll` in the libs folder.

If you don't want the build process to auto copy the mod or need to change the path you can do that in the `Rail Route QOL mod.csproj` by removing these lines at the end of the file or by changing the path for your System:
```
    <Target Name="PostBuildCopy" AfterTargets="Build">
        <MakeDir Directories="$(USERPROFILE)/AppData/LocalLow/bitrich/Rail Route/mods/Rail Route QOL mod" Condition=" '$(OS)' == 'Windows_NT' " />
        <MakeDir Directories="$(HOME)/.config/unity3d/bitrich/Rail Route/mods/Rail Route QOL mod/" Condition=" '$(OS)' != 'Windows_NT' " />
        <Exec Condition=" '$(OS)' == 'Windows_NT' " Command="copy '$(TargetPath)' '$(USERPROFILE)/AppData/LocalLow/bitrich/Rail Route/mods/Rail Route QOL mod/$(TargetFileName)'" />
        <Exec Condition=" '$(OS)' != 'Windows_NT' " Command="cp '$(TargetPath)' '$(HOME)/.config/unity3d/bitrich/Rail Route/mods/Rail Route QOL mod/$(TargetFileName)'" />
        <Exec Condition=" '$(OS)' == 'Windows_NT' " Command="copy '$(OutputPath)/0Harmony.dll' '$(USERPROFILE)/AppData/LocalLow/bitrich/Rail Route/mods/Rail Route QOL mod/0Harmony.dll'" />
        <Exec Condition=" '$(OS)' != 'Windows_NT' " Command="cp '$(OutputPath)/0Harmony.dll' '$(HOME)/.config/unity3d/bitrich/Rail Route/mods/Rail Route QOL mod/0Harmony.dll'" />
    </Target>
```