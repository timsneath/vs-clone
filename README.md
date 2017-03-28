# Clone Visual Studio
Clones a Visual Studio 2017 installation so it can be reproduced on another 
machine. Run this on a machine that already has Visual Studio 2017 installed, 
and it will interrogate the instance of Visual Studio to identify what workloads 
and components were selected, and attempt to create a command line that 
recreates the same installation.

Syntax:
```
clonevs.exe
```

## Limitations 

 * _Very_ limited testing done so far
 * Doesn't identify language packs installed
 * Assumes only one VS2017 instance on the machine
 * While it recognizes component groups, it also identifies individual components
 that are part of the component group as if they've been individually selected.
 * Code isn't very pretty yet

Example results from my machine:
```
vs_enterprise.exe --installPath "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise" ^
   --add Microsoft.VisualStudio.Workload.CoreEditor ^
   --add Microsoft.VisualStudio.Workload.ManagedDesktop ^
   --add Microsoft.VisualStudio.Workload.NetWeb ^
   --add Component.GitHub.VisualStudio ^
   --add Microsoft.Component.ClickOnce ^
   --add Microsoft.Component.MSBuild ^
   --add Microsoft.ComponentGroup.Blend ^
   --add Microsoft.Net.Component.4.5.1.TargetingPack ^
   --add Microsoft.Net.Component.4.5.2.TargetingPack ^
   --add Microsoft.Net.Component.4.5.TargetingPack ^
   --add Microsoft.Net.Component.4.6.1.SDK ^
   --add Microsoft.Net.Component.4.6.1.TargetingPack ^
   --add Microsoft.Net.Component.4.6.TargetingPack ^
   --add Microsoft.Net.Component.4.TargetingPack ^
   --add Microsoft.Net.ComponentGroup.DevelopmentPrerequisites ^
   --add Microsoft.Net.ComponentGroup.TargetingPacks.Common ^
   --add Microsoft.Net.Core.Component.SDK ^
   --add Microsoft.NetCore.ComponentGroup.Web ^
   --add Microsoft.VisualStudio.Component.AppInsights.Tools ^
   --add Microsoft.VisualStudio.Component.CloudExplorer ^
   --add Microsoft.VisualStudio.Component.Common.Azure.Tools ^
   --add Microsoft.VisualStudio.Component.CoreEditor ^
   --add Microsoft.VisualStudio.Component.Debugger.JustInTime ^
   --add Microsoft.VisualStudio.Component.DiagnosticTools ^
   --add Microsoft.VisualStudio.Component.DockerTools ^
   --add Microsoft.VisualStudio.Component.EntityFramework ^
   --add Microsoft.VisualStudio.Component.IISExpress ^
   --add Microsoft.VisualStudio.Component.IntelliTrace.FrontEnd ^
   --add Microsoft.VisualStudio.Component.JavaScript.Diagnostics ^
   --add Microsoft.VisualStudio.Component.JavaScript.TypeScript ^
   --add Microsoft.VisualStudio.Component.LiveUnitTesting ^
   --add Microsoft.VisualStudio.Component.ManagedDesktop.Core ^
   --add Microsoft.VisualStudio.Component.ManagedDesktop.Prerequisites ^
   --add Microsoft.VisualStudio.Component.NuGet ^
   --add Microsoft.VisualStudio.Component.PortableLibrary ^
   --add Microsoft.VisualStudio.Component.Roslyn.Compiler ^
   --add Microsoft.VisualStudio.Component.Roslyn.LanguageServices ^
   --add Microsoft.VisualStudio.Component.SQL.ADAL ^
   --add Microsoft.VisualStudio.Component.SQL.CLR ^
   --add Microsoft.VisualStudio.Component.SQL.CMDUtils ^
   --add Microsoft.VisualStudio.Component.SQL.DataSources ^
   --add Microsoft.VisualStudio.Component.SQL.LocalDB.Runtime ^
   --add Microsoft.VisualStudio.Component.SQL.NCLI ^
   --add Microsoft.VisualStudio.Component.SQL.SSDT ^
   --add Microsoft.VisualStudio.Component.Static.Analysis.Tools ^
   --add Microsoft.VisualStudio.Component.TextTemplating ^
   --add Microsoft.VisualStudio.Component.TypeScript.2.1 ^
   --add Microsoft.VisualStudio.Component.VisualStudioData ^
   --add Microsoft.VisualStudio.Component.Wcf.Tooling ^
   --add Microsoft.VisualStudio.Component.Web ^
   --add Microsoft.VisualStudio.Component.WebDeploy
   ```