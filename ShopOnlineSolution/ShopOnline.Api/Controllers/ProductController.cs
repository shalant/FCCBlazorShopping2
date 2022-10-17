using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Extensions;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var products = await this.productRepository.GetItems();
                var productCategories = await this.productRepository.GetCategories();
                //var products = await ShopOnlineDbContext.Products
                //    .Include(p => p.ProductCategory).ToListAsync();
                //return products;

                if (products == null || productCategories == null)
                {
                    return NotFound();
                }
                else
                {
                    //this original code was fixed by my crazy computer to the next line
                    //var productDtos = products.ConvertToDto(productCategories);
                    var productDtos = products.ConvertToDto((IEnumerable<Entities.ProductCategory>)productCategories);

                    return Ok(productDtos);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from DB");
            }
        }
    }
}
