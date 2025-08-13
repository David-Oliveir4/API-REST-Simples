using Produtos.Api.Domain;

namespace Produtos.Api.Application.Interfaces;
// Define os m�todos que o reposit�rio de produtos deve implementar


public interface IProductRepository  // Interface que define opera��es de persist�ncia para produtos
{
    // Adiciona um novo produto de forma ass�ncrona
    Task<Product> AddAsync(Product product);
    // Recupera todos os produtos de forma ass�ncrona
    Task<List<Product>> GetAllAsync();
}
