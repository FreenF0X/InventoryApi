using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace InventoryApi.Controllers
{
    [ApiController]
    [Route("Product")]
    public class ProductController: Controller
    {
        IRepository db;

        public ProductController(IRepository db)
        {
            this.db = db;
        }

        [HttpPost("{name}")]
        public IActionResult CreateNewProduct(string name, int quantity, int providerId)
        {
            var product = new Product { Name = name, Quantity = quantity, Providers = new List<Provider>() };
            var provider = db.GetDataById<Provider>(providerId);
            if (provider.Products == null)
                provider.Products = new List<Product>();
            provider.Products.Add(product);
            product.Providers.Add(provider);
            db.Create(product);
            db.Dispose();
            return this.Ok("Продукт добавлен.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            db.Delete<Product>(id);
            db.Dispose();
            return this.Ok("Продукт удален");
        }

        [HttpPost("update/{id}")]
        public IActionResult UpdateProductById(int id, string newName, int newQuantity)
        {
            var product = db.GetDataById<Product>(id);
            product.Name = newName;
            product.Quantity = newQuantity;
            db.Update(id, product);
            db.Dispose();
            return this.Ok("Продукт изменен.");
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            //var prop = p => p.Products;
            var response = db.GetDataList<Product,List<Provider>>(product => true,p => p.Providers);
            db.Dispose();
            return this.Ok(response);
        }

        [HttpGet("byprovider/{providerid}")]
        public IActionResult GetAllProductsByProvider(int providerid)
        {
            var response = db.GetDataList<Product, List<Provider>>(product => product.Providers.SingleOrDefault(provider => provider.Id == providerid) != null, p => p.Providers);
            db.Dispose();
            return this.Ok(response);
        }
    }
}
