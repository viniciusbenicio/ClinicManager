# ClinicManager

API para gerenciar empréstimos de livros, incluindo operações com usuários e livros, utilizando Clean Architecture, o padrão de repositório e CQRS.
API para gerenciar uma clinica (cadastro de Atendimento/Serviços), utilizando Clean Architecture. 

## Índice

- [Sobre o Projeto](#sobre-o-projeto)
- [Arquitetura](#arquitetura)
  - [Clean Architecture](#clean-architecture)
  - [Padrão Repository](#padrão-repository)
  - [CQRS](#cqrs)

- [Autenticação](#autenticação)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Instalação](#instalação)
- [Como Usar](#como-usar)
- [Saiba Mais - Next Wave Education](#saiba-mais)
- [Contato](#contato)

## Sobre o Projeto


O ClinicManager é uma aplicação para gerenciar atendimentos médico, permitindo cadastro de Médicos, Atendimento, Serviços e paciente. Utiliza Clean Architecture para garantir manutenibilidade e testabilidade, o padrão de repositório para abstração de dados e CQRS para separação de comandos e consultas.

## Arquitetura

### Clean Architecture

A Clean Architecture, ou Arquitetura Limpa, é uma abordagem que permite criar sistemas com baixo acoplamento e alta coesão. A estrutura do projeto segue o princípio de divisão de responsabilidades em camadas:

- **Camada de Core**: Contém a lógica de negócios e entidades do domínio.
- **Camada de Application**: Inclui casos de uso e serviços que orquestram a lógica de negócios.
- **Camada de Infrastructure**: Implementa detalhes técnicos como acesso a dados, serviços externos, etc.

### Padrão Repository

O padrão de repositório é utilizado para criar uma abstração entre a camada de aplicação e a camada de dados. Ele facilita a troca de fontes de dados (ex.: de um banco de dados SQL para um NoSQL) sem alterar a lógica de negócios.

### CQRS

CQRS (Command Query Responsibility Segregation) é um padrão que separa a leitura e escrita de dados. Isso significa que comandos (operações de escrita) e consultas (operações de leitura) são tratados por modelos diferentes. Isso melhora a escalabilidade e facilita a manutenção do código.

## Autenticação

A API utiliza autenticação JWT para proteger os endpoints. Para acessar os endpoints protegidos, você precisa incluir o token JWT no cabeçalho da solicitação.



No projeto GerenciadorLivro, implementamos um controlador para gerenciar operações de livros, empréstimos e usuários com autenticação e autorização adequadas. Confira:

#### 📖 Operações com Atendimento

1. GET /api/cares: Retorna todos os Atendimento. 
2. GET /api/cares/{id}: Retorna um Atendimento pelo ID. 
3. POST /api/cares: Cria um novo Atendimento. 
4. PUT /api/cares/{id}: Atualiza um Atendimento. 
5. DELETE /api/cares/{id}: Remove um Atendimento. 

#### 📅 Operações com Médicos

1. GET /api/doctors: Retorna todos os médicos. 
2. GET /api/doctors/{id}: Retorna um médico pelo ID. 
3. POST /api/doctors: Cria um novo médico. 
4. PUT /api/doctors/{id}: Atualiza um médico. 
5. DELETE /api/doctors/{id}: Remove um médico. 

#### 👤 Operações com Pacientes

1. GET /api/patients: Retorna todos os Pacientes. 
2. GET /api/patients/{id}: Retorna um Paciente pelo ID.
3. POST /api/patients: Cria um novo Paciente. 
4. PUT /api/patients/{id}: Atualiza um Paciente.
5. DELETE /api/patients/{id}: Remove um Paciente. 

## Tecnologias Utilizadas

- [.NET Core](https://dotnet.microsoft.com/)
- [Entity Framework Core](https://docs.microsoft.com/ef/core/)
- [ASP.NET Core](https://docs.microsoft.com/aspnet/core/)
- [Swagger](https://swagger.io/)

## Instalação

Instruções para instalar e rodar o projeto localmente.

```bash
# Clone o repositório
git clone https://github.com/viniciusbenicio/ClinicManager.git

# Navegue até o diretório do projeto
cd ClinicManager

# Restaure as dependências
dotnet restore

# Compile o projeto
dotnet build

# Execute a aplicação
dotnet run
```

## Como Usar

Explique como utilizar o projeto, com exemplos de código, comandos ou capturas de tela.

```bash
# Execute a aplicação
dotnet run
```

Acesse em seu navegador: `http://localhost:44380`.

## Saiba Mais - Next Wave Education

- Com o Método .NET do Luis Felipe [@luisLinkedin](https://www.linkedin.com/in/luisdeol/), enfrentamos constantes desafios na plataforma, estimulando-nos a praticar o que aprendemos. Um desses desafios consistiu no desenvolvimento do Projeto 1: Gerenciador de Biblioteca.
- Além do desenvolvimento básico, foram propostos desafios extras para impulsionar nosso aprendizado, como:
- Agendamento enviado por E-mail e Calendário. (Feito)
- Background Service notificação. (Em Desenvolvimento)
- Autenticação e Autorização. (Em Desenvolvimento)
- Anexo de Atestado etc. (Em Desenvolvimento)

## Contato

LinkedIn - [@ViniciusBenicio](https://www.linkedin.com/in/viniciusbenicio/)
