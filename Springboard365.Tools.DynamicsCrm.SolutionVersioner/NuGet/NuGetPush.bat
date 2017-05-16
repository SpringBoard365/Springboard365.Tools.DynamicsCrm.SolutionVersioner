NuGet.exe pack ../Springboard365.Tools.DynamicsCrm.SolutionVersioner.csproj -Build -Symbols -Version 1.0.0-beta3

NuGet.exe push *.nupkg

pause