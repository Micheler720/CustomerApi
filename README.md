# Customer Api
## Introdução
- Descrição: Aplicação criada para demonstrar a criação de CRUD utilizando o .Net 7
## Funcionalidades
:white_check_mark: 1. Customers
1. Listagem de clientes - GET /customers
1. Cadastro de clientes - POST /customers 
1. Remoção de clientes - DELETE /customers/{id}
1. Obter cliente por Id - GET /customers/{id} 
1. Atualização de cliente por id - PUT /customers/{id}

## Tecnologias
1. .Net7
1. EntityFramework  
1. Pattern Repository  
1. Injeção de dependencia
1. SQLite 

## Dependencias
1. .Net7
1. EntityFramework  
    ```dotnet tool install --global dotnet-ef```

## Como executar
1. Instalar as dependências da aplicação, sendo o .Net7 SDK.
1. Executar Migrations. 
    ```dotnet ef database update ```
1. Executar o comando ```dotnet run``` para executar o projeto

1. Executar o projeto no Visual Studio Code: Execute através do F5
    

