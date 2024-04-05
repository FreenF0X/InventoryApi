using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using BuisnessLogic;
using Domain.DtoModels;

namespace TMS.Operations.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : Controller
    {
        private readonly ProductLogic logic;

        public ProductController(ProductLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                return Ok(await logic.GetAllProductsAsync());
            }
            catch (Exception ex)
            {
                return this.Problem(ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                return this.Ok(await logic.GetProductByIdAsync(id));
            }
            catch (Exception ex)
            {
                return this.Problem(ex.ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewProduct(DtoProduct product)
        {
            try
            {
                return this.Ok(await logic.CreateNewProductAsync(product));
            }
            catch (Exception ex)
            {
                return this.Problem(ex.ToString());
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                return this.Ok(await logic.DeleteProductAsync(id));
            }
            catch (Exception ex)
            {
                return this.Problem(ex.ToString());
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateProductById(DtoProduct Product)
        {
            try
            {
                return this.Ok(await logic.UpdateProductAsync(Product));
            }
            catch (Exception ex)
            {
                return this.Problem(ex.ToString());
            }
        }
    }
}
