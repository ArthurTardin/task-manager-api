# TaskManager

API de gerenciamento de tarefas desenvolvida com ASP.NET Core.

## Tecnologias

- C#
- .NET
- ASP.NET Core
- Entity Framework Core
- PostgreSQL

## Status

Em desenvolvimento.

---

## Como executar

### 1. Subir o PostgreSQL

Na raiz do projeto:

```bash
docker compose up -d
```

### 2. Configurar a conexão da API

A API utiliza User Secrets para armazenar a string de conexão sem colocá-la no código versionado.

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=taskmanager;Username=postgres;Password=SUA_SENHA" --project src/TaskManager.API
```

### 3. Aplicar as migrations

```bash
dotnet ef database update --project src/TaskManager.Infrastructure --startup-project src/TaskManager.API
```

### 4. Executar a API

```bash
dotnet run --project src/TaskManager.API
```
