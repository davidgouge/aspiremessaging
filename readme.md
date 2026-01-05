# Aspire Messaging

A small solution containing an HTTP API, an Azure Functions ServiceBus trigger, and shared host/app code used by the services.

This repository is organized to make local development and debugging easy. The main projects are:

# Aspire Messaging 🚀

Welcome — this little solution brings together an HTTP API, an Azure Functions ServiceBus trigger, and a shared host to make development easy and fun. 🎉

Main projects:

- `api/` — HTTP API (ASP.NET)
- `function/` — Azure Functions (ServiceBus queue trigger)
- `aspire/` — shared host and service-defaults used by the services (the AppHost)

## Repository layout 📁

- [api](api): API project and configuration (appsettings.json, launch settings).
- [function](function): Azure Functions project (ServiceBus trigger).
- [aspire](aspire): shared host and defaults used across services.

## Prerequisites ✅

- .NET SDK 10 (for `net10.0` targets)
- Azure Functions Core Tools (for local Functions host)
- Git (to clone the repo)
- Optional: Visual Studio, Rider, or VS Code for a nicer development experience

Note: This project targets `net10.0` in places; make sure your installed SDK supports that.

> Service Bus configuration is handled by the shared `aspire/` AppHost — you don't need to wire up a separate Service Bus namespace just to run locally. 😌

## Local configuration 🔧

Before running locally, copy and edit `function/local.settings.json` with any required values (do NOT commit secrets).

At minimum, set:

- `AzureWebJobsStorage` — storage account connection string used by Functions (required by the Functions host).

Also glance at `appsettings.Development.json` / `appsettings.json` in `api/` and `aspire/` for additional settings.

## Build & run ▶️

Build the whole solution:

```bash
dotnet build aspiremessaging.slnx
```

Start the Aspire AppHost (this will spin up the API and Functions together):

```bash
dotnet run --project aspire/apphost
```

Notes:

- Ensure `function/local.settings.json` contains `AzureWebJobsStorage` before starting.
- There's a VS Code task available if you prefer launching from the editor.

## Development tips 🛠️

- Attach your IDE debugger to the running AppHost for step-through debugging.
- When you edit shared code in `aspire/`, rebuild so changes are picked up by the host.

## Deployment 🚀

- Use `dotnet publish` or your CI/CD pipeline to publish the API and Functions projects.
- For Azure deployments, configure the same environment variables (Application Settings) used locally.

Example publish commands:

```bash
dotnet publish api -c Release -o ./publish/api
dotnet publish function -c Release -o ./publish/function
```

## Contributing 🤝

- Fork, create a feature branch, and open a pull request.
- Add clear reproduction steps and any required config changes for reviewers.

## Where to look next 🔎

- `api/Program.cs` — API entrypoint
- `function/ServiceBusQueueTrigger.cs` — Functions trigger
- `aspire/apphost/AppHost.cs` — shared AppHost
