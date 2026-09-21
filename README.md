# SupportWebApp

SupportWebApp er en Blazor Web App udviklet i .NET.

Applikationen gør det muligt for en bruger at oprette supporthenvendelser og gemme dem i Azure Cosmos DB. Det er også muligt at hente og vise tidligere indsendte supporthenvendelser.

## Funktioner

Applikationen indeholder:

- Formular til oprettelse af supporthenvendelser
- Validering med Data Annotations
- Lagring af supporthenvendelser i Azure Cosmos DB
- Oversigt over tidligere supporthenvendelser
- Navigation mellem forsiden, formularen og oversigten

## Teknologier

Projektet er udviklet med:

- .NET 10
- Blazor Web App
- C#
- Azure Cosmos DB
- Microsoft.Azure.Cosmos
- Newtonsoft.Json

## Projektstruktur

De vigtigste dele af projektet er:

- `Models/SupportMessage.cs` - model for en supporthenvendelse
- `Services/CosmosDbService.cs` - kommunikation med Azure Cosmos DB
- `Components/Pages/CreateSupport.razor` - formular til nye supporthenvendelser
- `Components/Pages/SupportList.razor` - viser gemte supporthenvendelser
- `Components/Layout/NavMenu.razor` - navigation i applikationen
- `Program.cs` - konfiguration af Blazor og Cosmos DB

## Azure Cosmos DB

Applikationen bruger følgende Cosmos DB-struktur:

- Database: `IBasSupportDB`
- Container: `ibassupport`
- Partition key: `/category`

Alle supporthenvendelser gemmes med kategorien `support`.

## Validering

Formularen anvender Data Annotations til validering.

Følgende felter skal udfyldes:

- Navn
- Email
- Emne
- Besked

Email-feltet kontrolleres desuden for et gyldigt email-format.

## Sikker konfiguration

Cosmos DB connection string gemmes med .NET User Secrets og er derfor ikke gemt direkte i projektets kildekode.

For at konfigurere projektet lokalt kan User Secrets initialiseres med:

```bash
dotnet user-secrets init
```

Connection string kan derefter konfigureres med:

```bash
dotnet user-secrets set "CosmosDb:ConnectionString" "<DIN_CONNECTION_STRING>"
```

Den rigtige connection string skal aldrig gemmes i Git eller publiceres på GitHub.

## Kør projektet

Installer projektets dependencies og byg projektet:

```bash
dotnet restore
dotnet build
```

Start derefter applikationen:

```bash
dotnet run
```

Åbn den lokale adresse, som vises i terminalen.

## Sider

Applikationen indeholder følgende sider:

- `/` - Forside
- `/support/create` - Opret en supporthenvendelse
- `/support` - Se alle supporthenvendelser
