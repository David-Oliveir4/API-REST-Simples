using Produtos.Api.Domain;

namespace Produtos.Api.Application.Interfaces;
// Define os métodos que o repositório de produtos deve implementar


public interface IProductRepository  // Interface que define operações de persistência para produtos
{
    // Adiciona um novo produto de forma assíncrona
    Task<Product> AddAsync(Product product);
    // Recupera todos os produtos de forma assíncrona
    Task<List<Product>> GetAllAsync();
}
