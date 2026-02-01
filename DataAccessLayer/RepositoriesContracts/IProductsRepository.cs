using DataAccessLayer.Entities;
using System.Linq.Expressions;

namespace DataAccessLayer.RepositoriesContracts;

/// <summary>
/// Presents the contract for product data operations.
/// </summary>

public interface IProductsRepository
{
    /// <summary>
    /// Provides all products from the data source.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Product>> GetAllProductsAsync();

    /// <summary>
    /// Provides products based on a specified condition.
    /// Supports optional inclusion of related entities and tracking behavior.
    /// Tracking is disabled by default for read-only operations.
    /// </summary>
    /// <param name="conditionExpression"></param>
    /// <param name="include"></param>
    /// <param name="asNoTracking"></param>
    /// <returns></returns>
    Task<IEnumerable<Product>> GetAllProductsByConditionAsync(
        Expression<Func<Product, bool>> conditionExpression,
        Func<IQueryable<Product>, IQueryable<Product>>? include = null,
        bool asNoTracking = false
    );

    /// <summary>
    /// provides products based on a specified condition.
    /// Supports optional inclusion of related entities and tracking behavior.
    /// Tracking is disabled by default for read-only operations.
    /// </summary>
    /// <param name="conditionExpression"></param>
    /// <param name="include"></param>
    /// <param name="asNoTracking"></param>
    /// <returns> 
    /// The product that matches the specified condition and includes related entities if specified.
    /// </returns>
    Task<Product> GetProductByConditionAsync(
        Expression<Func<Product, bool>> conditionExpression,
        Func<IQueryable<Product>, IQueryable<Product>>? include = null,
        bool asNoTracking = false
    );

    Task<Product> AddProduct(Product product);
    Task<Product> UpdateProduct(Product product);
    Task<bool> DeleteProduct(Guid productId);

}

