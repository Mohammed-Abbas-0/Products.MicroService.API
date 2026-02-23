using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoriesContracts;
using DataLogicLayer.DTO;
using DataLogicLayer.ServiceContracts;
using FluentValidation;
using System.Linq.Expressions;

namespace DataLogicLayer.Services;
internal class ProductService : IProductService
{
    private readonly IValidator<ProductAddRequest> _addValidator;
    private readonly IValidator<ProductUpdateRequest> _updateValidator;
    private readonly IMapper _mapper;
    private readonly IProductsRepository _productsRepository;
    public ProductService(IValidator<ProductAddRequest> addValidator, IValidator<ProductUpdateRequest> updateValidator, IMapper mapper, IProductsRepository productsRepository)
    {
        _addValidator = addValidator;
        _updateValidator = updateValidator;
        _mapper = mapper;
        _productsRepository = productsRepository;
    }

    public async Task<ProductResponse> AddProduct(ProductAddRequest productAddRequest)
    {
        if (productAddRequest is null)
        {
            throw new ArgumentNullException(nameof(productAddRequest));
        }
        // Validate the request
        ValidationResult validationResult =  await _addValidator.ValidateAsync(productAddRequest);
        
        //if
    
    }

    public async Task<bool> DeleteProduct(Guid id)
    {

    }

    public async Task<ProductResponse> GetProductByCondition(Expression<Func<Product, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ProductResponse>> GetProducts()
    {
        throw new NotImplementedException();
    }

    public async Task<List<ProductResponse>> GetProductsByCondition(Expression<Func<Product, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<ProductResponse> UpdateProduct(ProductUpdateRequest productAddRequest)
    {
        throw new NotImplementedException();
    }
}
