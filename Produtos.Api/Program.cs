using Microsoft.EntityFrameworkCore;
using Produtos.Api.Application.DTOs;
using Produtos.Api.Application.Interfaces;
using Produtos.Api.Application.Services;
using Produtos.Api.Infrastructure.Data;
using Produtos.Api.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args); // Cria o builder da aplicação, ponto inicial para configurar serviços e middlewares

// Configura o Entity Framework Core com banco de dados em memória
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("ProdutosDb")); // Usa um banco em memória chamado "ProdutosDb", ideal para testes

// Configura a injeção de dependência (DIP - Dependency Inversion Principle)
builder.Services.AddScoped<IProductRepository, ProductRepository>(); // Registra o repositório como serviço Scoped
builder.Services.AddScoped<IProductService, ProductService>();       // Registra o serviço de produto como Scoped

// Adiciona suporte ao Swagger para documentação da API
builder.Services.AddEndpointsApiExplorer(); // Permite que os endpoints sejam explorados pelo Swagger
builder.Services.AddSwaggerGen();           // Gera a interface Swagger para testes e documentação

// Configura CORS para permitir chamadas do front-end (por padrão, Vite usa a porta 5173)
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("frontend", p =>
        p.WithOrigins("http://localhost:5173") // Permite requisições vindas do front-end local
         .AllowAnyHeader()                     // Permite qualquer cabeçalho
         .AllowAnyMethod());                   // Permite qualquer método HTTP (GET, POST, etc.)
});

var app = builder.Build(); // Constrói a aplicação com as configurações definidas acima

app.UseCors("frontend"); // Aplica a política de CORS chamada "frontend"

if (app.Environment.IsDevelopment()) // Verifica se está em ambiente de desenvolvimento
{
    app.UseSwagger();    // Ativa o Swagger para gerar a documentação
    app.UseSwaggerUI();  // Ativa a interface gráfica do Swagger
}

// Define o endpoint POST para criar um produto
app.MapPost("/produto", async (CreateProductDto dto, IProductService service) =>
{
    try
    {
        var created = await service.CreateAsync(dto); // Cria o produto usando o serviço
        return Results.Created($"/produto/{created.Id}", created); // Retorna 201 Created com o produto criado
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message }); // Retorna 400 Bad Request com mensagem de erro
    }
});

// Define o endpoint GET para listar todos os produtos
app.MapGet("/produto", async (IProductService service) =>
{
    var items = await service.GetAllAsync(); // Busca todos os produtos usando o serviço
    return Results.Ok(items);                // Retorna 200 OK com a lista de produtos
});

app.Run(); // Inicia a aplicação
