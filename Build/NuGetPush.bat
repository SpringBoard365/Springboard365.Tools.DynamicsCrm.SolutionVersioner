SET packageVersion=2.0.0-beta01

NuGet.exe pack ../src/SolutionVersioner.nuspec -Build -Symbols -Version %packageVersion% -Properties Configuration=Release;id="Springboard365.Tools.DynamicsCrm.SolutionVersioner";author="Springboard 365 Ltd";repo="https://github.com/SpringBoard365/Springboard365.Tools.DynamicsCrm.SolutionVersioner";description="The solution version increment tool for Dynamics Crm.";tags="Solution Version Increment Microsoft Dynamics CRM 2011 2013 2015 2016 SDK XRM 365 Online";

pause

NuGet.exe push Springboard365.Tools.DynamicsCrm.SolutionVersioner.%packageVersion%.nupkg -Source "https://api.nuget.org/v3/index.json"

pause