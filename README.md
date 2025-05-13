#   GetNews
GetNews prosjektet handler om å bygge et backend for et Nyhets brev, der en brukeren kan både melde intresse,
vertifisere koden som blir sendt på epost og melde av nyhets brevet.

##  Directory tree

```shell
├── GetNews.API
│   ├── ApiModel
│   │   ├── EmailAddress.cs
│   │   ├── Email.cs
│   │   ├── SubscriptionSignUp.cs
│   │   ├── SubscriptionVerification.cs
│   │   └── VerificationRequest.cs
│   │
│   ├── AppConfig.cs
│   ├── appsettings.Development.json
│   ├── appsettings.json
│   ├── GetNews.API.csproj
│   ├── GetNews.API.http
│   ├── Infrastructure
│   │   ├── DummyEmailService.cs
│   │   └── SubscriptionFileRepository.cs
│   │
│   ├── Mapper.cs
│   ├── PersistentModel
│   │   └── Subscription.cs
│   │
│   ├── Program.cs
│   ├── Properties
│   │   └── launchSettings.json
│   │
│   ├── SubscriptionController.cs
│   ├── SubscriptionEndpoints.cs
│   └── wwwroot
│   │   └── index.html
│   │
├── GetNews.Core
│   ├── ApplicationService
│   │   └── SubscriptionService.cs
│   ├── GetNews.Core.csproj
│
├── GetNews.Core.Test
│   ├── GetNews.Core.Test.csproj
│   └── SubscriptionServiceTest.cs
│
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