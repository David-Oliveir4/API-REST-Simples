using Produtos.Api.Application.DTOs;
using Produtos.Api.Application.Interfaces;
using Produtos.Api.Domain;

namespace Produtos.Api.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;
    public ProductService(IProductRepository repo) => _repo = repo;

    public async Task<ProductDto> CreateAsync(CreateProductDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new ArgumentException("Nome é obrigatório");
        if (dto.Price < 0)
            throw new ArgumentException("Preço não pode ser negativo");
        if (string.IsNullOrWhiteSpace(dto.Category))
            throw new ArgumentException("Categoria é obrigatória");

        var product = new Product
        {
            Name = dto.Name.Trim(),
            Price = dto.Price,
            Category = dto.Category.Trim()
        };

        var created = await _repo.AddAsync(product);
        return new ProductDto(created.Id, created.Name, created.Price, created.Category);
    }

    public async Task<List<ProductDto>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();
        return list.Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Category)).ToList();
    }
}
