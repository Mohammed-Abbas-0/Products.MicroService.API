using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoriesContracts;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories;

public class ProductsRepository : IProductsRepository
{
    private readonly AppDbContext _dbContext;

    public ProductsRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Product> AddProduct(Product product)
    {
        _dbContext.Products.Add(product);
        await  _dbContext.SaveChangesAsync();
        return product;
    }

    public async Task<bool> DeleteProduct(Guid productId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> GetAllProductsByConditionAsync(Expression<Func<Product, bool>> conditionExpression, Func<IQueryable<Product>, IQueryable<Product>>? include = null, bool asNoTracking = false)
    {
        throw new NotImplementedException();
    }

    public async Task<Product> GetProductByConditionAsync(Expression<Func<Product, bool>> conditionExpression, Func<IQueryable<Product>, IQueryable<Product>>? include = null, bool asNoTracking = false)
    {
        throw new NotImplementedException();
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }
}

