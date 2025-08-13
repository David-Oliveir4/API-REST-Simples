namespace Produtos.Api.Application.DTOs;

// Usado nas respostas da API (GET /produtos)
public record ProductDto(int Id, string Name, decimal Price, string Category);

