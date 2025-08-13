using Produtos.Api.Application.DTOs;

namespace Produtos.Api.Application.Interfaces;

public interface IProductService
{
    Task<ProductDto> CreateAsync(CreateProductDto dto);
    Task<List<ProductDto>> GetAllAsync();
}
