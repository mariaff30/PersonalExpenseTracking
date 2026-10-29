# Personal Finance API

API REST para controle e gerenciamento de finanças pessoais, desenvolvida com C# e .NET 10. O projeto tem como objetivo centralizar informações financeiras, permitindo acompanhar gastos, organizar despesas por categorias e cartões, monitorar investimentos e planejar objetivos financeiros.

Este projeto está sendo desenvolvido inicialmente com foco no backend, priorizando organização, manutenibilidade, segurança e boas práticas de desenvolvimento. O frontend será desenvolvido em uma etapa posterior, consumindo os endpoints disponibilizados pela API.

## Objetivos do projeto

- Centralizar o controle de receitas, despesas e investimentos.
- Acompanhar a evolução financeira em diferentes períodos.
- Organizar gastos por categorias e cartões.
- Definir limites de gastos e objetivos financeiros.
- Monitorar o saldo disponível e o valor restante no orçamento mensal.
- Aplicar boas práticas de desenvolvimento backend em um projeto prático.

## Funcionalidades

As funcionalidades serão implementadas de forma incremental, conforme a evolução do projeto.

### Usuários e autenticação
- Cadastro e gerenciamento de usuários.
- Autenticação e autorização de acesso.
- Proteção dos recursos associados a cada usuário.

### Controle de gastos
- Cadastro, consulta, atualização e exclusão de despesas.
- Organização de gastos por categorias e tipos.
- Consulta de despesas por período, incluindo visões semanais e mensais.
- Separação e acompanhamento de despesas por cartão.
- Consulta do histórico de movimentações financeiras.

### Planejamento financeiro
- Acompanhamento de receitas, despesas e saldo mensal.
- Cálculo do valor disponível após as despesas.
- Definição de limites de gastos por categoria ou período.
- Criação e acompanhamento de objetivos financeiros.

### Investimentos
- Registro e acompanhamento de investimentos.
- Organização dos investimentos por tipo.
- Visão consolidada dos valores investidos.

## Tecnologias

- **C#** — linguagem de programação.
- **.NET 10** — plataforma de desenvolvimento da API.
- **ASP.NET Core Web API** — construção dos endpoints REST.
- **Entity Framework Core** — mapeamento objeto-relacional e acesso aos dados.
- **SQL Server** — banco de dados relacional.
- **Git e GitHub** — versionamento e gerenciamento do código.

## Arquitetura e organização

A aplicação será estruturada para separar as responsabilidades, facilitar a manutenção e permitir a evolução do sistema.

A organização das camadas será definida de acordo com as necessidades do domínio, buscando manter as regras de negócio independentes dos detalhes de infraestrutura e comunicação HTTP.

Estrutura proposta:

```text
PersonalFinance/
├── src/
│   ├── PersonalFinance.API/
│   ├── PersonalFinance.Application/
│   ├── PersonalFinance.Domain/
│   └── PersonalFinance.Infrastructure/
├── tests/
│   ├── PersonalFinance.UnitTests/
│   └── PersonalFinance.IntegrationTests/
├── .gitignore
└── README.md
```

- **API:** endpoints, configuração HTTP, autenticação e composição da aplicação.
- **Application:** casos de uso e orquestração das operações.
- **Domain:** entidades, regras de negócio e conceitos centrais do domínio financeiro.
- **Infrastructure:** persistência com Entity Framework Core, integração com SQL Server e implementações técnicas.
- **UnitTests:** testes unitários das regras e comportamentos da aplicação.
- **IntegrationTests:** testes de integração entre os componentes da aplicação.

A estrutura apresentada é uma proposta inicial e poderá ser ajustada conforme a implementação evoluir.

## Banco de dados

O SQL Server será utilizado para persistir os dados financeiros e as informações dos usuários. O Entity Framework Core será responsável pelo mapeamento entre as entidades da aplicação e as tabelas do banco de dados.

O projeto prevê o uso de migrations para versionar e aplicar as alterações no esquema do banco de dados.

## Como executar o projeto

As instruções de configuração serão atualizadas conforme a implementação evoluir.

### Pré-requisitos

- .NET 10 SDK.
- SQL Server.
- Ferramenta de linha de comando do Entity Framework Core, quando necessária para executar migrations.

### Configuração

1. Clone o repositório.
2. Configure a conexão com o SQL Server por meio das configurações locais ou de variáveis de ambiente.
3. Restaure as dependências do projeto.
4. Aplique as migrations do Entity Framework Core, quando disponíveis.
5. Execute a API.

Os comandos definitivos e as configurações necessárias serão documentados quando a estrutura inicial estiver concluída.

**Importante:** não versione senhas, tokens, chaves ou outras credenciais no repositório.

## Testes

A estratégia de testes será desenvolvida para validar as regras de negócio e os principais fluxos da aplicação, incluindo cenários de sucesso, entradas inválidas e situações de erro.

Serão priorizados testes unitários e de integração para aumentar a confiabilidade das operações financeiras e facilitar futuras alterações.

## Próximas etapas

- [ ] Estruturar a solução e os projetos da aplicação.
- [ ] Modelar as entidades e regras de negócio do domínio financeiro.
- [ ] Configurar a persistência com Entity Framework Core e SQL Server.
- [ ] Implementar cadastro de usuários e autenticação.
- [ ] Implementar o gerenciamento de receitas e despesas.
- [ ] Desenvolver consultas e consolidações financeiras por período.
- [ ] Implementar categorias, cartões e limites de gastos.
- [ ] Desenvolver o controle de investimentos e objetivos financeiros.
- [ ] Criar testes unitários e de integração.
- [ ] Configurar documentação da API com OpenAPI/Swagger.
- [ ] Automatizar build e testes em um pipeline de CI.
- [ ] Desenvolver o frontend para consumir a API.

## Sobre o projeto

Este projeto é desenvolvido com o propósito de construir uma aplicação backend de controle financeiro pessoal, explorando conceitos de engenharia de software, modelagem de domínio, persistência de dados, segurança, testes automatizados e arquitetura de APIs REST.

O desenvolvimento é incremental, com foco em decisões técnicas justificadas, qualidade do código e evolução sustentável da aplicação.
