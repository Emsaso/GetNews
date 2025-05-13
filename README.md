#   GetNews
GetNews prosjektet handler om å bygge et backend for et Nyhets brev, der en brukeren kan både melde intresse,
vertifisere koden som blir sendt på epost og melde av nyhets brevet.

##  Directory tree

```bash
├── GetNews.API
│   ├── ApiModel
│   │   ├── EmailAddress.cs
│   │   ├── Email.cs
│   │   ├── SubscriptionSignUp.cs
│   │   ├── SubscriptionVerification.cs
│   │   └── VerificationRequest.cs
│   ├── AppConfig.cs
│   ├── appsettings.Development.json
│   ├── appsettings.json
│   ├── bin
│   │   └── Debug
│   │       └── net8.0
│   ├── GetNews.API.csproj
│   ├── GetNews.API.http
│   ├── Infrastructure
│   │   ├── DummyEmailService.cs
│   │   └── SubscriptionFileRepository.cs
│   ├── Mapper.cs
│   ├── obj
│   │   ├── Debug
│   │   │   └── net8.0
│   │   │       ├── GetNews.API.AssemblyInfo.cs
│   │   │       ├── GetNews.API.AssemblyInfoInputs.cache
│   │   │       ├── GetNews.API.assets.cache
│   │   │       ├── GetNews.API.csproj.AssemblyReference.cache
│   │   │       ├── GetNews.API.GeneratedMSBuildEditorConfig.editorconfig
│   │   │       ├── GetNews.API.GlobalUsings.g.cs
│   │   │       ├── ref
│   │   │       └── refint
│   │   ├── GetNews.API.csproj.nuget.dgspec.json
│   │   ├── GetNews.API.csproj.nuget.g.props
│   │   ├── GetNews.API.csproj.nuget.g.targets
│   │   ├── project.assets.json
│   │   └── project.nuget.cache
│   ├── PersistentModel
│   │   └── Subscription.cs
│   ├── Program.cs
│   ├── Properties
│   │   └── launchSettings.json
│   ├── SubscriptionController.cs
│   ├── SubscriptionEndpoints.cs
│   └── wwwroot
│       └── index.html
├── GetNews.Core
│   ├── ApplicationService
│   │   └── SubscriptionService.cs
│   ├── bin
│   │   └── Debug
│   │       └── net8.0
│   │           ├── GetNews.Core.deps.json
│   │           ├── GetNews.Core.dll
│   │           └── GetNews.Core.pdb
│   ├── DomainModel
│   │   ├── EmailAddress.cs
│   │   ├── EmailAndSubscription.cs
│   │   ├── Email.cs
│   │   ├── Result.cs
│   │   ├── SignUpError.cs
│   │   ├── Subscription.cs
│   │   └── SubscriptionStatus.cs
│   ├── GetNews.Core.csproj
│   └── obj
│       ├── Debug
│       │   └── net8.0
│       │       ├── GetNews.Core.AssemblyInfo.cs
│       │       ├── GetNews.Core.AssemblyInfoInputs.cache
│       │       ├── GetNews.Core.assets.cache
│       │       ├── GetNews.Core.csproj.AssemblyReference.cache
│       │       ├── GetNews.Core.csproj.CoreCompileInputs.cache
│       │       ├── GetNews.Core.csproj.FileListAbsolute.txt
│       │       ├── GetNews.Core.dll
│       │       ├── GetNews.Core.GeneratedMSBuildEditorConfig.editorconfig
│       │       ├── GetNews.Core.GlobalUsings.g.cs
│       │       ├── GetNews.Core.pdb
│       │       ├── GetNews.Core.sourcelink.json
│       │       ├── ref
│       │       │   └── GetNews.Core.dll
│       │       └── refint
│       │           └── GetNews.Core.dll
│       ├── GetNews.Core.csproj.nuget.dgspec.json
│       ├── GetNews.Core.csproj.nuget.g.props
│       ├── GetNews.Core.csproj.nuget.g.targets
│       ├── project.assets.json
│       └── project.nuget.cache
├── GetNews.Core.Test
│   ├── bin
│   │   └── Debug
│   │       └── net8.0
│   │           ├── CoverletSourceRootsMapping_GetNews.Core.Test
│   │           ├── cs
│   │           │   ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│   │           │   ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│   │           │   ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│   │           │   ├── Microsoft.Testing.Platform.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           ├── de
│   │           │   ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│   │           │   ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│   │           │   ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│   │           │   ├── Microsoft.Testing.Platform.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           ├── es
│   │           │   ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│   │           │   ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│   │           │   ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│   │           │   ├── Microsoft.Testing.Platform.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           ├── fr
│   │           │   ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│   │           │   ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│   │           │   ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│   │           │   ├── Microsoft.Testing.Platform.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           ├── GetNews.Core.dll
│   │           ├── GetNews.Core.pdb
│   │           ├── GetNews.Core.Test.deps.json
│   │           ├── GetNews.Core.Test.dll
│   │           ├── GetNews.Core.Test.pdb
│   │           ├── GetNews.Core.Test.runtimeconfig.json
│   │           ├── it
│   │           │   ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│   │           │   ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│   │           │   ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│   │           │   ├── Microsoft.Testing.Platform.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           ├── ja
│   │           │   ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│   │           │   ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│   │           │   ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│   │           │   ├── Microsoft.Testing.Platform.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           ├── ko
│   │           │   ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│   │           │   ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│   │           │   ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│   │           │   ├── Microsoft.Testing.Platform.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           ├── Microsoft.ApplicationInsights.dll
│   │           ├── Microsoft.Extensions.DependencyInjection.Abstractions.dll
│   │           ├── Microsoft.Extensions.DependencyInjection.dll
│   │           ├── Microsoft.Extensions.Logging.Abstractions.dll
│   │           ├── Microsoft.Extensions.Logging.dll
│   │           ├── Microsoft.Extensions.Options.dll
│   │           ├── Microsoft.Extensions.Primitives.dll
│   │           ├── Microsoft.Testing.Extensions.MSBuild.dll
│   │           ├── Microsoft.Testing.Extensions.Telemetry.dll
│   │           ├── Microsoft.Testing.Extensions.TrxReport.Abstractions.dll
│   │           ├── Microsoft.Testing.Extensions.VSTestBridge.dll
│   │           ├── Microsoft.Testing.Platform.dll
│   │           ├── Microsoft.TestPlatform.CommunicationUtilities.dll
│   │           ├── Microsoft.TestPlatform.CoreUtilities.dll
│   │           ├── Microsoft.TestPlatform.CrossPlatEngine.dll
│   │           ├── Microsoft.TestPlatform.PlatformAbstractions.dll
│   │           ├── Microsoft.TestPlatform.Utilities.dll
│   │           ├── Microsoft.VisualStudio.CodeCoverage.Shim.dll
│   │           ├── Microsoft.VisualStudio.TestPlatform.Common.dll
│   │           ├── Microsoft.VisualStudio.TestPlatform.ObjectModel.dll
│   │           ├── Newtonsoft.Json.dll
│   │           ├── NUnit3.TestAdapter.dll
│   │           ├── NUnit3.TestAdapter.pdb
│   │           ├── nunit.engine.api.dll
│   │           ├── nunit.engine.core.dll
│   │           ├── nunit.engine.dll
│   │           ├── nunit.framework.dll
│   │           ├── nunit.framework.legacy.dll
│   │           ├── nunit_random_seed.tmp
│   │           ├── pl
│   │           │   ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│   │           │   ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│   │           │   ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│   │           │   ├── Microsoft.Testing.Platform.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           ├── pt-BR
│   │           │   ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│   │           │   ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│   │           │   ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│   │           │   ├── Microsoft.Testing.Platform.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           ├── ru
│   │           │   ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│   │           │   ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│   │           │   ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│   │           │   ├── Microsoft.Testing.Platform.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           ├── System.Diagnostics.DiagnosticSource.dll
│   │           ├── testcentric.engine.metadata.dll
│   │           ├── testhost.dll
│   │           ├── tr
│   │           │   ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│   │           │   ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│   │           │   ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│   │           │   ├── Microsoft.Testing.Platform.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           ├── zh-Hans
│   │           │   ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│   │           │   ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│   │           │   ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│   │           │   ├── Microsoft.Testing.Platform.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           └── zh-Hant
│   │               ├── Microsoft.Testing.Extensions.MSBuild.resources.dll
│   │               ├── Microsoft.Testing.Extensions.Telemetry.resources.dll
│   │               ├── Microsoft.Testing.Extensions.VSTestBridge.resources.dll
│   │               ├── Microsoft.Testing.Platform.resources.dll
│   │               ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │               ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │               ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │               ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │               └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   ├── GetNews.Core.Test.csproj
│   ├── obj
│   │   ├── Debug
│   │   │   └── net8.0
│   │   │       ├── GetNews..90780DDE.Up2Date
│   │   │       ├── GetNews.Core.Test.AssemblyInfo.cs
│   │   │       ├── GetNews.Core.Test.AssemblyInfoInputs.cache
│   │   │       ├── GetNews.Core.Test.assets.cache
│   │   │       ├── GetNews.Core.Test.csproj.AssemblyReference.cache
│   │   │       ├── GetNews.Core.Test.csproj.CoreCompileInputs.cache
│   │   │       ├── GetNews.Core.Test.csproj.FileListAbsolute.txt
│   │   │       ├── GetNews.Core.Test.dll
│   │   │       ├── GetNews.Core.Test.GeneratedMSBuildEditorConfig.editorconfig
│   │   │       ├── GetNews.Core.Test.genruntimeconfig.cache
│   │   │       ├── GetNews.Core.Test.GlobalUsings.g.cs
│   │   │       ├── GetNews.Core.Test.pdb
│   │   │       ├── GetNews.Core.Test.sourcelink.json
│   │   │       ├── ref
│   │   │       │   └── GetNews.Core.Test.dll
│   │   │       └── refint
│   │   │           └── GetNews.Core.Test.dll
│   │   ├── GetNews.Core.Test.csproj.nuget.dgspec.json
│   │   ├── GetNews.Core.Test.csproj.nuget.g.props
│   │   ├── GetNews.Core.Test.csproj.nuget.g.targets
│   │   ├── project.assets.json
│   │   └── project.nuget.cache
│   └── SubscriptionServiceTest.cs
├── GetNews.sln
├── GetNewsVSC.code-workspace
├── Plan.md
└── README.md
```
##  Installation
1. Clone the repository
```sh
** Using Github Cli **
gh repo clone krigjo25/console-ConnectSimulator-cs

** Using HTTPS **
git clone https://github.com/krigjo25/console-socialmedia-cs-cs

** Using SSH**
ssh  git@github.com:krigjo25/console-ConnectSimulator-cs.git

```
2. Open the project in Visual Studio / Raider / Code VS
3. Run the project
4. Done!

### Requirements
NUnit 4.3 >
.NET Core 8.0 >
AspNetCore 8.0 >
NUnit.Analyzer 4.7 >
NUnit3TestAdapter 5.0 >
.NetTestSdk 17.13 >
Swasjbuckle.AspNetCore 6.6 >
~~Microsoft.Extensions.Logging" 9 >~~
Visual Studio 2019 > / Rider 2020.3 / Visual Studio Code >

[Recommended Workspace for VSC](https://vscode.dev/profile/github/4c4bde0a91b6c89df4bdfc6f5f022189)

## Summary
Det som er utfordrende med oppgaven er å tenke som en enhet, og forstå det samme som en. Vi har gjennom prosessen tenkt at utvikleren bestemmer strukturen, vi har lært at prosjektet bestemmer strukturen. Dette er en konskevens av å lære "å tenke selv", og troen om "revelatismen". 

##  Developer notes
Dette er en løsnings forslag på utfordringen.

Have a glorious day further,
[Kimser91](), [krigjo25]() & [Emsaso]()