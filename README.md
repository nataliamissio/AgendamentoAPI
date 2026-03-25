# AgendamentoAPI

Sistema de agendamento para clínicas ou salões, desenvolvido com **C# .NET 8 Web API** e **PostgreSQL**.  
Permite gerenciar clientes e seus agendamentos de forma prática, com API RESTful documentada pelo **Swagger**.

---

## Tecnologias Utilizadas

- **Backend:** C# .NET 8 Web API  
- **Banco de Dados:** PostgreSQL  
- **ORM:** Entity Framework Core 8  
- **Swagger:** Para documentação e testes da API  
- **Pacotes adicionais:** Npgsql, AutoMapper  

---

## Estrutura do Projeto

- **AgendamentoAPI/**: Pasta raiz do projeto  
  - **Controllers/**: Contém os controllers da API (Clientes, Agendamentos)  
  - **Data/**: Contém o `AppDbContext` e configuração do EF Core  
  - **Models/**: Classes de domínio (Cliente, Agendamento)  
  - **DTOs/**: Objetos de transferência de dados  
  - **Repositories/**: Responsáveis pela persistência (futuro)  
  - **Services/**: Lógica de negócio (futuro)  
  - **Program.cs**: Configuração principal da aplicação  

---

## Pré-requisitos

Antes de rodar o projeto, você precisa ter instalado:

- [.NET SDK 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  
- [PostgreSQL](https://www.postgresql.org/download/)  
- (Opcional) Editor: Visual Studio ou VS Code  

---

## Configuração do Banco de Dados

1. Crie um banco de dados no PostgreSQL, por exemplo: `agendaappdb`.  
2. Atualize a **connection string** no `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=agendaappdb;Username=seu_usuario;Password=sua_senha"
}
