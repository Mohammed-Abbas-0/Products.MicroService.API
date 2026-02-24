using DataLogicLayer.DTO;
using DataLogicLayer.ServiceContracts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Products.MicroService.API.APIEndPoint;

public static class ProductAPIEndPoint
{
    public static IEndpointRouteBuilder MapProductAPIEndPoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/products/", async (IProductService productservice) =>
        {
            List<ProductResponse> productResponses = await productservice.GetProducts();
            return Results.Ok(productResponses);
        });

        endpoints.MapGet("/api/products/search/{ProductId:guid}", async (IProductService productservice, Guid ProductId) =>
        {
            ProductResponse productResponses = await productservice.GetProductByCondition(idx=> idx.ProductId == ProductId);
            return Results.Ok(productResponses);
        });

        endpoints.MapGet("/api/products/{SearchText}", async (IProductService productservice, string SearchText) =>
        {
            List<ProductResponse> productsByName = await productservice.GetProductsByCondition(idx=> 
                            !string.IsNullOrEmpty(idx.ProductName)
                            && EF.Functions.Like(idx.ProductName, $"%{SearchText}%"));

            List<ProductResponse> productsByCategory = await productservice.GetProductsByCondition(idx=> 
                            !string.IsNullOrEmpty(idx.Category) 
                            && EF.Functions.Like(idx.ProductName, $"%{SearchText}%"));

            var products = productsByName.Union(productsByCategory);
            return Results.Ok(products);
        });

        // POST
        endpoints.MapPost("/api/products", async (IProductService productservice,IValidator<ProductAddRequest> validator, ProductAddRequest productAddRequest) =>
        {
            var validProduct =  await validator.ValidateAsync(productAddRequest);
            if(!validProduct.IsValid)
            {
                var errors = validProduct.Errors
                                        .GroupBy(idx => idx.PropertyName)
                                        .ToDictionary(grp => grp.Key, grp => grp.Select(err => err.ErrorMessage)
                                        .ToArray());
                return Results.ValidationProblem(errors);
            }
            var productResponse = await productservice.AddProduct(productAddRequest);
            if (productResponse is not null)
            {

                return Results.Created($"/api/products/search/product-id/{productResponse.ProductId}",productResponse);
            }
            return Results.Problem("Error in adding product");
        });

        // PUT
        endpoints.MapPut("/api/products", async (IProductService productservice,IValidator<ProductUpdateRequest> validator, ProductUpdateRequest productUpdateRequest) =>
        {
            var validProduct =  await validator.ValidateAsync(productUpdateRequest);
            if(!validProduct.IsValid)
            {
                var errors = validProduct.Errors
                                        .GroupBy(idx => idx.PropertyName)
                                        .ToDictionary(grp => grp.Key, grp => grp.Select(err => err.ErrorMessage)
                                        .ToArray());
                return Results.ValidationProblem(errors);
            }
            var productResponse = await productservice.UpdateProduct(productUpdateRequest);
            if (productResponse is not null)
            {

                return Results.Ok(productResponse);
            }
            return Results.Problem("Error in updating product");
        });

        // DELETE
        endpoints.MapDelete("/api/products/{ProductId:guid}", async (IProductService productservice,Guid ProductId) =>
        {
            var productResponse = await productservice.DeleteProduct(ProductId);
            if (productResponse)
            {
                return Results.Ok(true);
            }
            return Results.Problem("Error in deleting product");
        });

        return endpoints;
    }

}
