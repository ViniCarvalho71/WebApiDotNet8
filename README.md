# Documentação da API - WebApiDotNet8

## Visão Geral

Esta é uma API RESTful desenvolvida com .NET 8. O projeto tem como objetivo fornecer um conjunto de serviços para gerenciar a relação entre tatuadores e seu clientes, permitindo operações como criar, deletar, atualizar e vizualizar, e conta com um sistema de login utilizando cookies.

A API foi projetada para ser segura, escalável e eficiente, utilizando as melhores práticas de desenvolvimento de APIs RESTful e os recursos mais recentes do .NET 8.

---

## Tecnologias Utilizadas

- **.NET 8** - Plataforma de desenvolvimento para construir a API.
- **C#** - Linguagem de programação principal.
- **Entity Framework Core** - ORM utilizado para interagir com o banco de dados.
- **SQL Server / PostgreSQL** - Banco de dados relacional (especificar qual foi usado).
- **Swagger** - Para documentação interativa da API.
- **Identity** - Para autênticação
---

## Estrutura do Projeto

### Diretórios

- **Controllers**: Contém os controladores da API, responsáveis por gerenciar as requisições HTTP.
- **Models**: Contém os modelos de dados utilizados na aplicação.
- **Services**: Contém a lógica de negócios da aplicação.
- **Data**: Contém a configuração do banco de dados e contexto do Entity Framework.
- **Dtos**: Contém os objetos de transferência de dados (Data Transfer Objects).
- **Migrations**: Contém as migrações do banco de dados.

---

## Como Rodar o Projeto Localmente

### Pré-requisitos

1. **.NET 8 SDK** - Baixe e instale o SDK mais recente do .NET 8 em [dotnet.microsoft.com](https://dotnet.microsoft.com/download).
2. **Banco de Dados** - Configure o banco de dados de sua preferência, por exemplo, SQL Server ou PostgreSQL.
3. **Ferramentas de Desenvolvimento**:
   - **Visual Studio 2022 ou Visual Studio Code**.
   - **Postman ou qualquer outra ferramenta de teste de API** (opcional, mas recomendado).

### Passos para Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/ViniCarvalho71/WebApiDotNet8
   cd projeto-api-dotnet8
   ```

2. Restaure as dependências
    ```bash
   dotnet restore
   ```
3. Crie e aplique as migrações
    ```bash
   dotnet ef database update
   ```
4. Execute o projeto:
   ```bash
   dotnet run
   ```
   
