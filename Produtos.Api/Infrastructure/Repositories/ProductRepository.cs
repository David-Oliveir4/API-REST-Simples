using Microsoft.EntityFrameworkCore;
using Produtos.Api.Application.Interfaces;
using Produtos.Api.Domain;
using Produtos.Api.Infrastructure.Data;

namespace Produtos.Api.Infrastructure.Repositories;

// Implementa a interface IProductRepository, seguindo o padrão Repository
public class ProductRepository : IProductRepository
{
    // Injeta o contexto do banco de dados via construtor (injeção de dependência)
    private readonly AppDbContext _db;

    // Construtor que recebe o contexto e o armazena em uma variável privada
    public ProductRepository(AppDbContext db) => _db = db;

    // Método assíncrono para adicionar um novo produto ao banco
    public async Task<Product> AddAsync(Product product)
    {
        // Validação simples: garante que o nome do produto não seja nulo ou vazio
        if (string.IsNullOrWhiteSpace(product.Name))
            throw new ArgumentException("O nome do produto é obrigatório.");

        try
        {
            // Adiciona o produto ao DbSet e salva as alterações no banco
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }
        catch (Exception ex)
        {
            // Em caso de erro, lança uma exceção mais específica com mensagem customizada
            // Aqui também seria possível adicionar um log para registrar o erro
            throw new InvalidOperationException("Erro ao adicionar o produto.", ex);
        }
    }

    // Método assíncrono para buscar todos os produtos do banco
    public async Task<List<Product>> GetAllAsync()
    {
        try
        {
            // Retorna todos os produtos sem rastreamento (melhor performance para leitura)
            return await _db.Products.AsNoTracking().ToListAsync();
        }
        catch (Exception ex)
        {
            // Em caso de erro, lança uma exceção com mensagem customizada
            throw new InvalidOperationException("Erro ao buscar os produtos.", ex);
        }
    }
}