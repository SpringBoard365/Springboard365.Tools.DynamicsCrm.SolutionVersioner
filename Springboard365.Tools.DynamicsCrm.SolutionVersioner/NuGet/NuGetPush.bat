NuGet.exe pack ../Springboard365.Tools.DynamicsCrm.SolutionVersioner.csproj -Build -Symbols -Version 1.0.0-beta1

NuGet.exe push *.nupkg

pause