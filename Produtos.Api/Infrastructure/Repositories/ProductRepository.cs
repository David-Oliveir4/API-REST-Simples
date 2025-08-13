using Microsoft.EntityFrameworkCore;
using Produtos.Api.Application.Interfaces;
using Produtos.Api.Domain;
using Produtos.Api.Infrastructure.Data;

namespace Produtos.Api.Infrastructure.Repositories;

// Implementa a interface IProductRepository, seguindo o padr�o Repository
public class ProductRepository : IProductRepository
{
    // Injeta o contexto do banco de dados via construtor (inje��o de depend�ncia)
    private readonly AppDbContext _db;

    // Construtor que recebe o contexto e o armazena em uma vari�vel privada
    public ProductRepository(AppDbContext db) => _db = db;

    // M�todo ass�ncrono para adicionar um novo produto ao banco
    public async Task<Product> AddAsync(Product product)
    {
        // Valida��o simples: garante que o nome do produto n�o seja nulo ou vazio
        if (string.IsNullOrWhiteSpace(product.Name))
            throw new ArgumentException("O nome do produto � obrigat�rio.");

        try
        {
            // Adiciona o produto ao DbSet e salva as altera��es no banco
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }
        catch (Exception ex)
        {
            // Em caso de erro, lan�a uma exce��o mais espec�fica com mensagem customizada
            // Aqui tamb�m seria poss�vel adicionar um log para registrar o erro
            throw new InvalidOperationException("Erro ao adicionar o produto.", ex);
        }
    }

    // M�todo ass�ncrono para buscar todos os produtos do banco
    public async Task<List<Product>> GetAllAsync()
    {
        try
        {
            // Retorna todos os produtos sem rastreamento (melhor performance para leitura)
            return await _db.Products.AsNoTracking().ToListAsync();
        }
        catch (Exception ex)
        {
            // Em caso de erro, lan�a uma exce��o com mensagem customizada
            throw new InvalidOperationException("Erro ao buscar os produtos.", ex);
        }
    }
}