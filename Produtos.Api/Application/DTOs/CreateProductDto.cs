namespace Produtos.Api.Application.DTOs;

// Este DTO representa os dados necessários para criar um novo produto na aplicação.

public record CreateProductDto(string Name, decimal Price, string Category);
