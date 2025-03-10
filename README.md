# Documentação do Sistema - `bsg_crud_app`

## 1. Estrutura do Projeto

A estrutura do projeto segue um padrão modular e bem organizado para garantir escalabilidade e manutenção facilitada.

```
bsg_crud_app/
│── Source/
│   ├── bsg_crud_app/
│   │   ├── Dependencies/           # Gerenciamento de pacotes e dependências
│   │   ├── Properties/             # Configurações do projeto
│   │   ├── wwwroot/                # Arquivos estáticos (CSS, JS, imagens)
│   │   ├── Context/                # Configuração do banco de dados e DbContext
│   │   ├── Controllers/            # Controladores responsáveis pelas requisições HTTP
│   │   ├── Dtos/                   # Data Transfer Objects para comunicação de dados
│   │   ├── Exceptions/             # Tratamento de exceções customizadas
│   │   ├── Extensions/             # Métodos de extensão auxiliares
│   │   ├── Migrations/             # Scripts de migração do banco de dados
│   │   ├── Models/                 # Definição das entidades e modelos de dados
│   │   ├── Pages/                  # Páginas da aplicação (caso utilize Razor Pages)
│   │   ├── Repositories/           # Camada de repositório para interação com o banco
│   │   ├── Services/               # Camada de serviços (regras de negócio)
│   │   ├── Validators/             # Validação de dados de entrada
│   │   ├── Views/                  # Templates das views (MVC)
│   │   ├── appsettings.json        # Configuração do aplicativo
│   │   ├── appsettings.Development.json # Configuração específica para desenvolvimento
│   │   ├── Program.cs              # Arquivo principal de inicialização
│── Tests/
│   ├── Tests/                      # Projeto de testes unitários e de integração
│   │   ├── Dependencies/           # Dependências do projeto de testes
│   │   ├── Products/               # Testes relacionados ao módulo de produtos
```

---

## 2. Descrição das Camadas e Responsabilidades

### **Controllers**
- Responsáveis por receber e processar as requisições HTTP.
- Chamam os serviços adequados para tratar a lógica de negócio.
- Retornam respostas formatadas (JSON, views, etc.).

### **Services**
- Contêm a lógica de negócio do sistema.
- Mantêm a separação entre os controladores e os repositórios.

### **Repositories**
- Responsáveis por acessar e manipular os dados no banco.
- Implementam operações de CRUD.
- Utilizam `DbContext` para interagir com o banco de dados.

### **Models**
- Representam as entidades do banco de dados.
- Definem propriedades e relacionamentos entre tabelas.

### **DTOs (Data Transfer Objects)**
- Criam objetos intermediários para transferência de dados entre camadas.
- Evitam exposição direta dos modelos de banco de dados.

### **Validators**
- Aplicam validações de entrada para garantir integridade dos dados.

### **Exceptions**
- Gerenciam exceções personalizadas.
- Centralizam o tratamento de erros para evitar duplicação de código.
- Middleware de tratativa de exceptions.

### **Migrations**
- Contém os scripts de migração do banco de dados.
- Gerencia atualizações da estrutura do banco.

### **wwwroot**
- Armazena arquivos estáticos, como CSS, JS e imagens.

---

## 3. Escolha de Tecnologias e Padrões de Projeto

### **Tecnologias Utilizadas**
- **Linguagem:** C# com .NET Core
- **Framework Web:** ASP.NET Core
- **Banco de Dados:** PostgreSQL
- **ORM:** Entity Framework Core
- **Testes:** xUnit
- **Lib de Validação**: FluentValidator
- **Lib para Migrations**: FluentMigrator

### **Padrões de Projeto**
- **MVC (Model-View-Controller):** Para separação de responsabilidades.
- **Repository Pattern:** Para abstração da camada de persistência.

---

## 4. Desafios Encontrados e Soluções

### **Implementação de Testes Unitários**
**Desafio:** Necessidade de aprendizagem para implementar (xUnit).  
**Solução:** Estudos e implementação de teste unitários para camada de validation e de repositories.

### **Implementação de Interface Visual via Razor Pages**
**Desafio:** Necessidade de aprendizagem para implementar (UI).  
**Solução:** Estudos e implementação básica da interface.

---

## 5. Plano de Testes

### **Objetivo**
Garantir a estabilidade do sistema e prevenir regressões.

### **Tipos de Testes**
- **Testes Unitários:** Validam métodos e serviços isoladamente.

### **Cenários Cobertos**
1. **Operações CRUD do Repository**
   - Criar, ler, atualizar e excluir registros no banco.

2. **Validações no input de dados**
   - Validação de nomes vazios, nomes duplicados, grandes e preços errados.

