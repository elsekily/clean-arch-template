# Elsekily Clean Architecture Template

**Author:** Youssef Elsekily  
**Short name:** `elsekily-api`  
**Framework:** .NET 10 / ASP.NET Core 10 (with .NET 8 support)

## What's Included

| Layer | Key Packages |
|---|---|
| **Domain** | Zero dependencies — `BaseEntity`, `BaseAuditableEntity`, `ISoftDelete`, `AppUser` |
| **Application** | FluentValidation, `Result<T>`, `PaginatedResult<T>`, CQRS skeleton, `IUserService` |
| **Infrastructure** | Quartz.NET, named HttpClients, `UserService` (HttpContext) |
| **Persistence** | EF Core 10 (SQL Server), `BaseRepository<T>`, `AppDbContext`, **Unit of Work (Transactions)**, **Auditing Interceptor**, **Global Soft Delete** |
| **API** | JWT auth, Serilog, rate limiting, AR/EN Localization, `IsAlive` Health Check, 3 middlewares, Swagger |

## Quick Start

```bash
# Install the template
dotnet new install .

# Scaffold a new project
dotnet new elsekily-api -n MyCompany.MyProject
```

## Key Features

- **Auditable Entities**: Inherit from `BaseAuditableEntity` to automatically track `CreatedAt`, `CreatedBy`, `LastModifiedAt`, and `LastModifiedBy`.
- **Soft Delete**: Implement `ISoftDelete` interface for automatic soft delete and global query filtering.
- **Unit of Work**: Use `IAppUnitOfWork` for transaction management across multiple repositories.
- **Current User**: `IUserService` implementation to easily access current user ID from `HttpContext`.
- **Localization**: Multi-language support (AR/EN) pre-configured in the API.
- **Health Check**: Simple `IsAlive` endpoint to verify service availability.

## Customization

- Update connection string in `src/API/appsettings.json`
- Change `Jwt:Key`, `Jwt:Issuer`, `Jwt:Audience`
- Add entities in `src/Domain/Entities/`
- Add features in `src/Application/Features/`
- Register repositories in `src/Persistence/DependencyInjection.cs`
- Register services in `src/Application/DependencyInjection.cs`
