using DataAccessLayer.Entities;
using DataLogicLayer.DTO;
using System.Linq.Expressions;

namespace DataLogicLayer.ServiceContracts;
public interface IProductService
{
    Task<List<ProductResponse>> GetProducts();
    Task<List<ProductResponse>> GetProductsByCondition(Expression<Func<Product, bool>> expression);
    Task<ProductResponse> GetProductByCondition(Expression<Func<Product, bool>> expression);
    Task<ProductResponse> AddProduct(ProductAddRequest productAddRequest);
    Task<ProductResponse> UpdateProduct(ProductUpdateRequest productAddRequest);
    Task<bool> DeleteProduct(Guid id);
}
