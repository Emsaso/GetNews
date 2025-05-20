#   GetNews - Nyhetsbrev-backend
Prosjektet GetNews omhandler utviklingen av en backend-tjeneste for et nyhetsbrev.
Tjenesten tillater brukere å :
* Påmelding av nyhetsbrevet
* Vertifisere påmelding ved hjelp av en tilsendt kode via e-post
* Melde seg av nyhetsbrevet.

## Helt overordnet
[Modellering av Prosjektet](./model/getnews.md)

<!--?  Hva synes dere om denne endringen?
Prosjektet er delt inn i tre hovedkomponenter:
* **API**: Ansvarlig for grensesnitt mot eksterne systemer/frontend
* **Core**: Inneholder kjernelogikken og forretningsreglene
* **Test**: Omfatter enhetstester og integrasjonstester.

### Dataflyt og mønstere
Systemet benytter et mønster for dataflyt som kan visualiseres som:
```mermaid
%% Input/Output(IO) -> Kall til kjerne -> IO
Denne [linken]() Inneholder en mer detaljert forklaring av dataflyten.

```
### Core-laget
[Modellering av hvordan Core fungerer sammen](./model/core.md)
Dette laget implementerer all forretningslogikk for håndtering av abonnementer, verifisering og avmelding

### Test-laget
Se [Modellering av testene](./model/testModel.md) for en visuell oversikt over teststrukturen.
Vårt testregime har oppnådd en testdekning på 99% i kjernelaget, noe som sikrer robusthet og kvalitet i de fleste funksjoner.
-->

Tre prosjekter: 
- API
- Core
- Test

Forklare. Hvorfor? Hva skal hvor?

Ulike modeller og mapping. 

Forklare mønsteret IO -> kalle kjerne -> IO
Ev. IO -> kalle kjerne -> IO -> kalle kjerne -> IO

Vise til video fra youtube



### Core
Se over [Modellering av core](./model/core.md) for å få et visuelt bilde av hvordan testene fungerer.

### Test
Se over [Modellering av testene](./model/testModel.md) for å få et visuelt bilde av hvordan testene fungerer.
Gjennom kjerne testene har vi oppnåd en 99% grundig testing der vi har testet de fleste funksjonene i koden.

##  Directory tree
[Visuell oversikt over mappe treet](./model/tree.md)

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
##  Installasjon av prosjektet
1. Clone the repository
```sh
Using Github Cli
gh repo clone krigjo25/console-ConnectSimulator-cs

Using HTTPS
git clone https://github.com/krigjo25/console-socialmedia-cs-cs

Using SSH
ssh  git@github.com:krigjo25/console-ConnectSimulator-cs.git

```
2.  **Åpne prosjektet**: Åpne prosjektet i et passende utviklingsmiljø (Visual Studio / Rider / Visual Studio Code).
3.  **Kjør prosjektet**: Bygg og kjør prosjektet via ditt valgte IDE.
4. Done!

### Nødvendige krav
For å kjøre prosjektet kreves følgende
* **IDE**: Visual Studio 2019 > / Rider 2020.3
* **.NET**: .NET Core 8.0  og AspNetCore 8.0 >
* **Testrammeverk**:  NUnit 4.3+, NUnit.Analyzer 4.7+, NUnit3TestAdapter 5.0+, .NetTestSdk 17.13+
* **Dokumentasjon**: Swasjbuckle.AspNetCore 6.6 >
* **Visual Studio Code**: For brukere som foretrekker VSC her er en [Anbefalt Arbeidsområde for VSC](https://vscode.dev/profile/github/4c4bde0a91b6c89df4bdfc6f5f022189)

## Oppsumering
<!--? Hva synes dere om denne implementasjonen av oppsumering?
Gjennom prosjektet har det vært utfordrende å forstå herakiet, og sette seg inn i hvordan fungerer koden. 
Vi løste det med å lage diagrammer som viser mappe herakiet, modellering av klassene, og deres ansvar ved bruk av klasse diagram.
I begynnelsen har det vært en utfordring  med team dynamikk, og tenke som en enhet. Dette løste vi med å ha struktur i koden og spille spill på fredager  30 min -1t,
der vi øver på kommunikasjon og team building. -->

##  Utvikler notater
Dette prosjektet er representert som et løsningsforslag for denne utfordringen.

Have a glorious day further,
[Kimser91](https://github.com/Kimser91), [krigjo25](https://github.com/krigjo25) & [Emsaso](https://github.com/emsaso)
