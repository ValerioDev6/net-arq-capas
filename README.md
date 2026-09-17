# Galasy.Pedidos

Solución Blazor Web App con arquitectura en capas.

## Estructura

| Capa         | Proyecto                                       | Responsabilidad                                      |
| ------------ | ---------------------------------------------- | ---------------------------------------------------- |
| Presentation | `src/Presentation/Galasy.Pedidos.Presentation` | Blazor Web App (UI).                                 |
| Business     | `src/Business/Galasy.Pedidos.Business`         | Lógica de negocio / casos de uso.                    |
| Repositories | `src/Repositories/Galasy.Pedidos.Repositories` | Acceso a datos vía repositorios.                     |
| DataAccess   | `src/DataAccess/Galasy.Pedidos.DataAccess`     | DbContext, configuraciones EF Core, extensions (DI). |
| Entities     | `src/DataAccess/Galasy.Pedidos.Entities`       | Entidades de dominio/persistencia.                   |
| Common       | `src/Common/Galasy.Pedidos.Common`             | Utilidades y tipos compartidos.                      |
| DTO          | `src/Common/Galasy.Pedidos.DTO`                | Contratos de entrada/salida (Request/Response).      |
| Database     | `src/Database/Galasy.Pedidos.Database`         | Proyecto de base de datos SQL Server (`.sqlproj`).   |

## Dependencias por capa

### DataAccess — `Galasy.Pedidos.DataAccess`

```bash
dotnet add src/DataAccess/Galasy.Pedidos.DataAccess package Microsoft.EntityFrameworkCore
dotnet add src/DataAccess/Galasy.Pedidos.DataAccess package Microsoft.EntityFrameworkCore.Design
dotnet add src/DataAccess/Galasy.Pedidos.DataAccess package Microsoft.EntityFrameworkCore.SqlServer
```

Scaffolding del `DbContext` a partir de una base de datos existente (correr dentro de `src/DataAccess/Galasy.Pedidos.DataAccess`):

```bash
dotnet ef dbcontext scaffold "Server=localhost;Database=db_arq_capas;User Id=sa;Password=Pass123word#;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o DbContext
```

> Requiere la herramienta global `dotnet-ef` instalada:
>
> ```bash
> dotnet tool install --global dotnet-ef
> ```

### Business — `Galasy.Pedidos.Business`

```bash
dotnet add src/Business/Galasy.Pedidos.Business package Mapster
```

### Presentation — `Galasy.Pedidos.Presentation`

```bash
dotnet add src/Presentation/Galasy.Pedidos.Presentation package MudBlazor
```

## Comandos útiles

```bash
dotnet build
dotnet run --project src/Presentation/Galasy.Pedidos.Presentation
dotnet sln list
```
