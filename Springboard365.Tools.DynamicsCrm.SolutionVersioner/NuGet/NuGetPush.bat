NuGet.exe pack ../Springboard365.Tools.DynamicsCrm.SolutionVersioner.csproj -Build -Symbols -Properties Version="1.0.0-beta1"

NuGet.exe push *.nupkg

pause