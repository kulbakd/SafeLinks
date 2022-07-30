# SafeLinks

---

SafeLinks is a simple URL shortener built on .NET 6 with using Blazor framework for front-end.

For demo visit: [SafeLinks.sk](https://safelinks.sk)

## Run SafeLinks locally

### Prerequisites

[.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

[.NET Core CLI tools](https://docs.microsoft.com/en-us/ef/core/get-started/overview/install#get-the-net-core-cli-tools)

### Building and running

```shell
dotnet ef database update --project src/SafeLinks.Infrastructure --startup-project src/SafeLinks.Web.Client
dotnet build
dotnet run --project src/SafeLinks.Web.Client
```