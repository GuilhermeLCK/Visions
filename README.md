# Visions Library API

API REST para gerenciamento de acervo e empréstimos de uma biblioteca universitária.

## Tecnologias Utilizadas

- ASP.NET Core (.NET 8)
- Entity Framework Core
- SQL Server

## Funcionalidades

- Cadastro, busca e listagem de livros
- Cadastro e consulta de alunos
- Registro e devolução de empréstimos
- Relatórios: livros mais emprestados, empréstimos em atraso e histórico por período

## Como Executar

1. **Clone o repositório:**

   
2. **Acesse a pasta do projeto:**
   
2. **Acesse a pasta do projeto:**
   
3. **Configure a string de conexão do banco de dados:**

   - Abra o arquivo `appsettings.json` na pasta `src/Visions.API/`.
   - Localize a seção `"ConnectionStrings"` e altere o valor de `"DefaultConnection"` conforme seu ambiente SQL Server:

4. **Execute a API (as migrations já iram executar):**
   
6. **Acesse a documentação Swagger:**
   - Acesse `http://localhost:5000/swagger` (ou a porta configurada) para visualizar os endpoints.

## Observações

- Certifique-se de que o SQL Server está em execução e acessível.
- Altere as configurações conforme necessário para seu ambiente.
---
Pronto! Com este documento, qualquer pessoa consegue rodar e configurar a API rapidamente.
