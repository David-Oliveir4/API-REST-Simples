# API REST de Produtos com Front-End React

## ✅ Objetivo
Criar uma API REST simples para cadastro de produtos e um front-end em React que consome essa API.

## 🛠 Tecnologias
- **Backend:** .NET 6+ (ex.: .NET 8), Entity Framework Core (InMemory), Swagger
- **Frontend:** React
- **Princípios de Projeto:** SOLID (SRP, DIP)
- **IDE / Editor:** Visual Studio (VS) e Visual Studio Code (VS Code)

## 📐 Princípios SOLID aplicados
- **SRP (Single Responsibility Principle):** separação clara entre camadas (Entidades, DTOs, Repositório, Serviço e API)
- **DIP (Dependency Inversion Principle):** API depende de interfaces; implementações reais são injetadas via DI

## 📁 Estrutura  do projeto
Produtos.Api/
├─ Domain/
│ └─ Product.cs
├─ Application/
│ ├─ DTOs/
│ │ ├─ CreateProductDto.cs
│ │ └─ ProductDto.cs
│ ├─ Interfaces/
│ │ ├─ IProductRepository.cs
│ │ └─ IProductService.cs
│ └─ Services/
│ └─ ProductService.cs
├─ Infrastructure/
│ ├─ Data/
│ │ └─ AppDbContext.cs
│ └─ Repositories/
│ └─ ProductRepository.cs
└─ Program.cs

## 🚀 Funcionalidades
- CRUD de produtos via API REST
- Documentação da API via Swagger
- Consumo da API pelo front-end em React

## ⚡ Como rodar o projeto

1. Clone o repositório:
```bash
git clone <https://github.com/David-Oliveir4/API-REST-Simples.git>

2. Acesse a pasta do projeto(Backend) e rode a API:

cd Produtos.Api
dotnet run // inicia o projeto program.cs

3. Acesse a documentação Swagger:

https://localhost:5001/swagger


4. Para o front-end React:

npm install // instala o que for necessario para o React.
npm start // inicia o projeto


