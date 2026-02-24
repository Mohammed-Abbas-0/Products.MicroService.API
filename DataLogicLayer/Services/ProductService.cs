using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoriesContracts;
using DataLogicLayer.DTO;
using DataLogicLayer.ServiceContracts;
using FluentValidation;
using System.Linq.Expressions;
using FValidationResult = FluentValidation.Results.ValidationResult;


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
        FValidationResult validationResult =  await _addValidator.ValidateAsync(productAddRequest);

        if (!validationResult.IsValid)
        {
            string errors = string.Join(", ", validationResult.Errors.Select(idx=>idx.ErrorMessage));
            throw new ArgumentException(errors);
        }
        Product product = _mapper.Map<Product>(productAddRequest);
        await _productsRepository.AddProduct(product);

        var response = _mapper.Map<ProductResponse>(product);
        return response;
    }

    public async Task<bool> DeleteProduct(Guid id)
    {
        var product = await _productsRepository.GetProductByConditionAsync(p => p.ProductId == id);
        if (product is null)
        {
            throw new ArgumentException($"Product with id {id} does not exist.");
        }
        return await _productsRepository.DeleteProduct(id);
    }

    public async Task<ProductResponse> GetProductByCondition(Expression<Func<Product, bool>> expression)
    {
        Product product = await _productsRepository.GetProductByConditionAsync(expression);
        if (product is null)
            return new ProductResponse();
        var response = _mapper.Map<ProductResponse>(product);
        return response;
    }

    public async Task<List<ProductResponse>> GetProducts()
    {
        var products = await _productsRepository.GetAllProductsAsync();
        if (products is null || !products.Any())
        {
            return new List<ProductResponse>();
        }

        IEnumerable<ProductResponse> productResponses = _mapper.Map<IEnumerable<ProductResponse>>(products);
        return productResponses.ToList();
    }

    public async Task<List<ProductResponse>> GetProductsByCondition(Expression<Func<Product, bool>> expression)
    {
        var products = await _productsRepository.GetAllProductsByConditionAsync(expression);
        if (products is null || !products.Any())
        {
            return new List<ProductResponse>();
        }
        var responses = _mapper.Map<IEnumerable<ProductResponse>>(products);
        return responses.ToList();
    }

    public async Task<ProductResponse> UpdateProduct(ProductUpdateRequest productUpdateRequest)
    {
        if (productUpdateRequest is null)
        {
            throw new ArgumentNullException(nameof(productUpdateRequest));
        }
        var existingProduct = await _productsRepository.GetProductByConditionAsync(p => p.ProductId == productUpdateRequest.ProductId);
        if (existingProduct is null)
        {
            throw new ArgumentException($"Product with id {productUpdateRequest.ProductId} does not exist.");
        }
        // Validate the request
        FValidationResult validationResult = await _updateValidator.ValidateAsync(productUpdateRequest);

        if (!validationResult.IsValid)
        {
            string errors = string.Join(", ", validationResult.Errors.Select(idx => idx.ErrorMessage));
            throw new ArgumentException(errors);
        }
        Product product = _mapper.Map<Product>(productUpdateRequest);
        await _productsRepository.UpdateProduct(product);

        var response = _mapper.Map<ProductResponse>(product);
        return response;
    }
}
