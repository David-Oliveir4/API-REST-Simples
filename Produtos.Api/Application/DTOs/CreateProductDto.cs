namespace Produtos.Api.Application.DTOs;

// Este DTO representa os dados necess�rios para criar um novo produto na aplica��o.

public record CreateProductDto(string Name, decimal Price, string Category);
