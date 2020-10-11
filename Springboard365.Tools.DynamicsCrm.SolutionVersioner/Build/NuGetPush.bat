SET packageVersion=2.0.0-alpha03

NuGet.exe pack ../Springboard365.Tools.DynamicsCrm.SolutionVersioner.nuspec -Build -Symbols -Version %packageVersion% -Properties Configuration=Release;id="Springboard365.Tools.DynamicsCrm.SolutionVersioner";author="Springboard 365 Ltd";repo="https://github.com/SpringBoard365/Springboard365.Tools.DynamicsCrm.SolutionVersioner";description="The solution version increment tool for Dynamics Crm.";tags="Solution Version Increment Microsoft Dynamics CRM 2011 2013 2015 2016 SDK XRM 365 Online";

NuGet.exe push Springboard365.Tools.DynamicsCrm.SolutionVersioner.%packageVersion%.nupkg -Source "https://api.nuget.org/v3/index.json"

pause