#   GetNews
GetNews prosjektet handler om å bygge et backend for et Nyhets brev, der en brukeren kan både melde intresse,
vertifisere koden som blir sendt på epost og melde av nyhets brevet.

##  Directory tree

```sh
├── GetNews.API
│   ├── ApiModel
│   │   ├── EmailAddress.cs                 # Ansvarlig for sjekk av inn skrevet Emailadresse
│   │   ├── Email.cs                        # Ansvarlig for mottak av Email innhold fra frontend
│   │   ├── SubscriptionSignUp.cs           # Ansvarlig for mottak av Emailadresse for sjekk i Backend
│   │   ├── SubscriptionVerification.cs     # Ansvarlig for mottak av emailadressen og verificationCode
│   │   └── VerificationRequest.cs          # Ansvarlig for videresending av emailadressen og verifikasjonskoden til backend
│   │
│   ├── AppConfig.cs                        # Ansvarlig for å sette BasePath for fillagring
│   ├── appsettings.Development.json
│   ├── appsettings.json
│   ├── GetNews.API.csproj
│   ├── GetNews.API.http
│   ├── Infrastructure
│   │   ├── DummyEmailService.cs            # Lager ett JSON objekt og lagrer det som en fil i Subscription mappen
│   │   └── SubscriptionFileRepository.cs   # Henter JSON objektet fra Riktig fil bestemt av Emailadressen som blir sendt med fra UI
│   │
│   ├── Mapper.cs                           # Inneholder DTO'er som sikrer at riktig dataflyt og at kun ønsket del av JSON ovjektet kommer dit det skal
│   ├── PersistentModel
│   │   └── Subscription.cs                 # Lager innholdet som skal lagres i "Emailen" som blir laget av DummyEmailService.cs
│   │
│   ├── Program.cs                          # Henter inn avhengigheter og lytter etter API kall via MapPost
│   ├── Properties
│   │   └── launchSettings.json
│   │
│   ├── SubscriptionController.cs           # Ansvarlig for Sending og mottak av informasjon til Backend
│   ├── SubscriptionEndpoints.cs            # Alternativ måte å ha em  Router til API om en ønsker (mer dynamisk og ryddigere enn å legge alt i Program) 
│   └── wwwroot                             # Inneholder frontend delen av prosjektet
│   │   └── index.html
│   │
├── GetNews.Core
│   ├── ApplicationService
│   │   └── SubscriptionService.cs          # Håndtering av registering, vertifisering og avmelding
│   ├── GetNews.Core.csproj
│
├── GetNews.Core.Test
│   ├── GetNews.Core.Test.csproj
│   └── SubscriptionServiceTest.cs        
│
├── GetNews.sln
├── GetNewsVSC.code-workspace
└── README.md
```
##  Installation
1. Clone the repository
```sh
Using Github Cli
gh repo clone krigjo25/console-ConnectSimulator-cs

Using HTTPS
git clone https://github.com/krigjo25/console-socialmedia-cs-cs

Using SSH
ssh  git@github.com:krigjo25/console-ConnectSimulator-cs.git

```
2. Open the project in Visual Studio / Raider / Code VS
3. Run the project
4. Done!

### Requirements
Visual Studio 2019 > / Rider 2020.3 / Visual Studio Code >

NUnit 4.3 >
.NET Core 8.0 >
AspNetCore 8.0 >
NUnit.Analyzer 4.7 >
NUnit3TestAdapter 5.0 >
.NetTestSdk 17.13 >
Swasjbuckle.AspNetCore 6.6 >
~~Microsoft.Extensions.Logging" 9 >~~


[Recommended Workspace for VSC](https://vscode.dev/profile/github/4c4bde0a91b6c89df4bdfc6f5f022189)

## Summary
Det som er utfordrende med oppgaven er å tenke som en enhet, og forstå det samme som en. Vi har gjennom prosessen tenkt at utvikleren bestemmer strukturen, vi har lært at prosjektet bestemmer strukturen. Dette er en konskevens av å lære "å tenke selv", og troen om "revelatismen". 

##  Developer notes
Dette er en løsnings forslag på utfordringen.

Have a glorious day further,
[Kimser91](), [krigjo25]() & [Emsaso]()