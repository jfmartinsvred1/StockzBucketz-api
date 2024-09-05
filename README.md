# StockzBucketz API

Esta é a API do projeto StockzBucketz, desenvolvida em .NET 8, para gerenciar portfólios de ações. A API é responsável por fornecer dados para o frontend em React e integrar-se com bancos de dados SQL Server ou MySQL.

## Pré-requisitos

Antes de iniciar, certifique-se de ter as seguintes ferramentas instaladas em sua máquina:

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) ou [MySQL](https://dev.mysql.com/downloads/installer/)
- [Docker](https://www.docker.com/) (opcional)

## Tecnologias Utilizadas

- .NET 8
- Entity Framework Core
- SQL Server / MySQL
- Docker (opcional)

## Instalação

Siga as etapas abaixo para configurar e executar a API:

### 1. Clone o repositório:

    git clone https://github.com/jfmartinsvred1/StockzBucketz.git
    cd StockzBucketz/StockzBucketz.Api
2. Configure o banco de dados:
Certifique-se de que um banco de dados SQL Server ou MySQL esteja rodando em sua máquina. Atualize a string de conexão no arquivo appsettings.json com as configurações do seu banco de dados.

Exemplo de configuração para SQL Server:

    "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=StockBucketDb;User Id=seu_usuario;Password=sua_senha;"
    }
Exemplo de configuração para MySQL:

    "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=StockBucketDb;User=seu_usuario;Password=sua_senha;"
    }
3. Atualize o banco de dados:
Execute as migrações para configurar o banco de dados:

        dotnet ef database update
4. Execute a API:
Para iniciar a API, use o seguinte comando:

        dotnet run
        A API estará rodando no endereço padrão: https://localhost:7142 (ou a porta configurada).

5. Verifique as URLs da API:

        Certifique-se de que as URLs da API no frontend estejam apontando para a URL onde o backend está rodando.

        Executando com Docker
        Caso queira rodar a aplicação utilizando Docker, siga as etapas abaixo:

1. Configure o Docker:
          Certifique-se de que o Docker esteja instalado e em execução na sua máquina.

2. Construa e rode o contêiner:
   
          docker-compose up
Isso iniciará o contêiner com a API .NET 8 e o banco de dados configurado.

Scripts Úteis
Para compilar a aplicação:

    dotnet build
    
Para rodar os testes:

      dotnet test
Para aplicar novas migrações:

    dotnet ef migrations add NomeDaMigracao
    dotnet ef database update

.Observações
      Certifique-se de que o banco de dados esteja rodando e acessível.
Verifique se as variáveis de ambiente e a string de conexão estão corretamente configuradas.
