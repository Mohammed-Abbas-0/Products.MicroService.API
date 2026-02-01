using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace Products.MicroService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public ProductsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var allProducts = _dbContext.Products.ToList();
            return Ok(allProducts);
        }
    }
}
