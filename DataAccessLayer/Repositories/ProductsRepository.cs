using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoriesContracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories;

public class ProductsRepository : IProductsRepository
{
    private readonly AppDbContext _dbContext;

    public ProductsRepository(AppDbContext dbContext) => _dbContext = dbContext;
    

    public async Task<Product> AddProduct(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }

    public async Task<bool> DeleteProduct(Guid productId)
    {
        var rowsAffected = await _dbContext.Products
            .Where(x => x.ProductId == productId)
            .ExecuteDeleteAsync();

        return rowsAffected > 0;
    }

    // 🔥 GET ALL
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _dbContext.Products
            .AsNoTracking()
            .ToListAsync();
    }

    // 🔥 GET ALL WITH CONDITION
    public async Task<IEnumerable<Product>> GetAllProductsByConditionAsync(
        Expression<Func<Product, bool>> conditionExpression,
        Func<IQueryable<Product>, IQueryable<Product>>? include = null,
        bool asNoTracking = false)
    {
        IQueryable<Product> query = _dbContext.Products;

        if (asNoTracking)
            query = query.AsNoTracking();

        if (include != null)
            query = include(query);

        return await query
            .Where(conditionExpression)
            .ToListAsync();
    }

    // 🔥 GET SINGLE
    public async Task<Product?> GetProductByConditionAsync(
        Expression<Func<Product, bool>> conditionExpression,
        Func<IQueryable<Product>, IQueryable<Product>>? include = null,
        bool asNoTracking = false)
    {
        IQueryable<Product> query = _dbContext.Products;

        if (asNoTracking)
            query = query.AsNoTracking();

        if (include != null)
            query = include(query);

        return await query
            .FirstOrDefaultAsync(conditionExpression);
    }

    // 🔥 UPDATE
    public async Task<Product> UpdateProduct(Product product)
    {
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }
}


