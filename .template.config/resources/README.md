# Elsekily Clean Architecture

## Migrations

To add a new migration:
```bash
dotnet ef migrations add Initial --project src/Persistence --startup-project src/API --context AppDbContext --output-dir Contexts/AppDir/Migrations
```

To update the database:
```bash
dotnet ef database update --project src/Persistence --startup-project src/API --context AppDbContext
```
