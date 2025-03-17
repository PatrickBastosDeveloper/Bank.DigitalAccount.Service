# DigitalAccount

📌 Visão Geral

Este projeto é um microserviço que busca reproduzir uma camada de cadastro de um cliente em um banco de dados. Foi desenvolvido utilizando a arquitetura Clean Code, garantindo um código modular, de fácil manutenção e escalabilidade. A solução é construída sobre .NET 8 e segue boas práticas de desenvolvimento.

🚀 Tecnologias e Ferramentas Utilizadas

📌 Backend

.NET 8 - Plataforma principal para desenvolvimento da aplicação.

Dapper - Micro ORM para acesso eficiente ao banco de dados.

FluentValidation - Biblioteca para validação de dados.

Swashbuckle.AspNetCore - Implementação do Swagger para documentação da API.

Extensions.FluentValidation.Br - Extensões do FluentValidation para o contexto brasileiro.

Microsoft.Extensions.Configuration - Biblioteca para gerenciar configurações da aplicação.

Microsoft.Data.SqlClient - Driver de conexão com SQL Server.

Microsoft.Data.Sqlite - Biblioteca para uso do SQLite.

📌 Banco de Dados

SQL Server 2019 (via Docker)

SQLite (para testes e cenários específicos)

📌 Testes

xUnit - Framework de testes unitários.

coverlet.collector - Geração de relatórios de cobertura de código.

Microsoft.NET.Test.Sdk - Suporte para execução de testes.

📌 Ferramentas Adicionais

Docker - Contêinerização do banco de dados SQL Server.

Swagger - Interface interativa para documentação e testes da API.

🏗️ Arquitetura do Projeto

O projeto adota a arquitetura Clean Code, estruturado nos seguintes módulos:

Domain: Camada responsável pelas regras de negócio, entidades e interfaces de repositório.

Application: Contém os casos de uso e serviços que interagem com a camada de domínio.

Infra.Repository: Implementação dos repositórios e acesso aos dados.

API: Exposição dos endpoints da aplicação.

Testes: Conjunto de testes unitários e de integração para garantir a confiabilidade da aplicação.

📦 Estrutura de Diretórios

📂 src
 ┣ 📂 Domain                 # Camada de domínio
 ┣ 📂 Application            # Casos de uso e serviços
 ┣ 📂 Infra.Repository       # Acesso a dados
 ┣ 📂 API                    # Camada de apresentação
📂 tests                     # Testes unitários e de integração
 ┣ 📂 Domain.Tests
 ┣ 📂 Application.Tests

🔧 Configuração e Execução

🐳 Subindo o Banco de Dados com Docker

docker-compose up -d

📌 Executando a Aplicação

dotnet run --project src/API

📌 Rodando os Testes

dotnet test tests/

📖 Considerações Finais

Este projeto segue princípios de Clean Code, garantindo um código limpo, testável e de fácil manutenção. Contribuições são bem-vindas! 🚀