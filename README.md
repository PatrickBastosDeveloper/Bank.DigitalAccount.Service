# DigitalAccount

## 📌 Overview

This project is a microservice designed to implement a customer registration layer in a database. It follows the Clean Code architecture, ensuring a modular, maintainable, and scalable codebase. The solution is built on .NET 8 and adheres to best development practices.

## 🚀 Technologies and Tools Used

### 📌 Backend

- **.NET 8** - Main platform for application development.
- **Dapper** - Lightweight ORM for efficient database access.
- **FluentValidation** - Library for data validation.
- **Swashbuckle.AspNetCore** - Swagger implementation for API documentation.
- **Extensions.FluentValidation.Br** - FluentValidation extensions for the Brazilian context.
- **Microsoft.Extensions.Configuration** - Library for managing application configurations.
- **Microsoft.Data.SqlClient** - SQL Server connection driver.
- **Microsoft.Data.Sqlite** - Library for using SQLite.

### 📌 Database

- **SQL Server 2019** (with Docker)
- **SQLite** (for testing and specific scenarios)

### 📌 Testing

- **xUnit** - Unit testing framework.
- **coverlet.collector** - Code coverage report generation.
- **Microsoft.NET.Test.Sdk** - Support for test execution.

### 📌 Additional Tools

- **Docker** - Containerization for SQL Server database.
- **Swagger** - Interactive interface for API documentation and testing.

## 🏗️ Project Architecture

The project follows the Clean Code architecture, structured into the following modules:

- **Domain**: Contains business rules, entities, and repository interfaces.
- **Application**: Includes use cases and services that interact with the domain layer.
- **Infra.Repository**: Implements repositories and data access.
- **API**: Exposes application endpoints.
- **Testes**: Unit and integration tests to ensure application reliability.

## 📦 Directory Structure

```
📂 src
 ┣ 📂 Domain                 # Camada de domínio
 ┣ 📂 Application            # Casos de uso e serviços
 ┣ 📂 Infra.Repository       # Acesso a dados
 ┣ 📂 API                    # Camada de apresentação
📂 tests                     # Testes unitários e de integração
 ┣ 📂 Domain.Tests
 ┣ 📂 Application.Tests
```
## 🔄 Git flow

feat/new-changes -> develop -> main 

## 🔧 Setup and Execution

### 🐳 Running the Database with Docker

```
docker-compose up -d
```

### 📌 Running the Application
```
dotnet run --project src/API
```

### 📌 Running Tests

```
dotnet test tests/
```

## 🔗 How to Fork and Install the Project

### 🔀 Creating a Fork

1. Go to the GitHub repository.

2. Click the Fork button in the top right corner.

3. Choose your account to create a copy of the repository.

### 📥 Cloning the Repository

After creating the fork, clone the repository locally using the following command:

```
git clone https://github.com/seu-usuario/nome-do-repositorio.git
```

### 📌 Installing Dependencies

Navigate to the project directory and restore dependencies:

```
cd nome-do-repositorio

dotnet restore
```

### 🔄 Creating a New Branch

```
git checkout -b minha-feature
```

Now you can make your changes and contribute to the project!

### Author

---

<a href="https://github.com/PatrickBastosDeveloper">
 <img style="border-radius: 50%;" src="https://avatars3.githubusercontent.com/patrickbastosdeveloper" width="100px;" alt="foto autor"/>
 <br />
 <sub><b>Patrick Bastos</b></sub></a> <a href="https://github.com/PatrickBastosDeveloper" title="my-portfolio">🚀</a>

Made by Patrick Bastos
👋🏽 Get in touch!

[![Twitter Badge](https://img.shields.io/badge/-@PatrickBastosC-1ca0f1?style=flat-square&labelColor=1ca0f1&logo=twitter&logoColor=white&link=https://twitter.com/patrickbastosc)]()
[![Linkedin Badge](https://img.shields.io/badge/-PatrickBastosDeveloper-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/patrickbastosdeveloper/)](https://www.linkedin.com/in/patrickbastosdeveloper/)
[![Gmail Badge](https://img.shields.io/badge/-patrickbastosc@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:patrickbastosc@gmail.com)](https://mail.google.com/mail/u/0/?tab=rm&ogbl#inbox)
