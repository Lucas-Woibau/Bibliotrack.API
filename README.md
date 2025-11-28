# 📚 Bibliotrack – Sistema de Empréstimos de Livros

O **Bibliotrack** é um sistema para gerenciamento de empréstimos de livros, desenvolvido com uma arquitetura baseada em **DDD (Domain-Driven Design)**, utilizando **MediatR**, **Entity Framework Core** e **ASP.NET Core Web API**.

Ele centraliza toda a lógica de negócio dentro das entidades do domínio, mantendo os handlers leves e focados apenas em orquestrar as operações.

---

## 🚀 Funcionalidades Principais

### 📖 Livros
- Cadastro de livros
- Controle de disponibilidade
- Atualização automática de status conforme a quantidade
- Gerenciamento de estoque (aumentar/diminuir)

### 🔄 Empréstimos
- Registrar empréstimos
- Registrar devoluções
- Prevenir devoluções duplicadas
- Alterar o estoque do livro automaticamente

---

## 🧩 Estrutura do Projeto

- **Domain**: entidades, enums e regras de negócio  
- **Application**: handlers, comandos e view models  
- **Infrastructure**: persistência, contextos e repositórios  
- **API**: controladores e configuração da aplicação  

---

## 🧰 Tecnologias Utilizadas

- .NET 9
- ASP.NET Core 
- Entity Framework Core  
- MediatR  
- SQL Server  
- Swagger para documentação  
