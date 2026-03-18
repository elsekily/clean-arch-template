# Elsekily Clean Architecture Template

**Author:** Youssef Elsekily  
**Short name:** `elsekily-api`  
**Framework:** .NET 8 / ASP.NET Core 8

## What's Included

| Layer | Key Packages |
|---|---|
| **Domain** | Zero dependencies — `BaseEntity`, `BaseAuditableEntity`, `AppUser` |
| **Application** | FluentValidation, `Result<T>`, `PaginatedResult<T>`, CQRS skeleton |
| **Common** | Serilog, JWT Bearer, `IUserService` contract |
| **Infrastructure** | Quartz.NET, named HttpClients |
| **Persistence** | EF Core 8 (SQL Server), `BaseRepository<T>`, `AppDbContext` |
| **API** | JWT auth, Serilog, rate limiting, 3 middlewares, Swagger |

## Quick Start

```bash
# Install the template
dotnet new install .

# Scaffold a new project
dotnet new elsekily-api -n MyCompany.MyProject

# Restore & run
cd MyCompany.MyProject/src/API
dotnet run
```

## Customization

- Update connection string in `src/API/appsettings.json`
- Change `Jwt:Key`, `Jwt:Issuer`, `Jwt:Audience`
- Add entities in `src/Domain/Entities/`
- Add features in `src/Application/Features/`
- Register repositories in `src/Persistence/DependencyInjection.cs`
- Register services in `src/Application/DependencyInjection.cs`
