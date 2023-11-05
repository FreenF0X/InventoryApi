using InventoryApi.Entityes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InventoryApi.Controllers
{
    [ApiController]
    [Route("providers")]
    public class ProvidersController: Controller
    {
        IRepository db;

        public ProvidersController(IRepository db)
        {
            this.db = db;
        }

        [HttpPost("{name}")]
        public IActionResult CreateNewProvider(string name)
        {
            var provider = new Provider { Name = name, Products = new List<Product>() };
            db.Create(provider);
            db.Dispose();
            return this.Ok("Поставщик добавлен.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProvider(int id)
        {
            db.Delete<Provider>(id);
            db.Dispose();
            return this.Ok("Поставщик удален");
        }

        [HttpPost("update/{id}")]
        public IActionResult UpdateProviderById(int id, string newName)
        {
            var provider = db.GetDataById<Provider>(id);
            provider.Name = newName;
            db.Update(id, provider);
            db.Dispose();
            return this.Ok("Поставщик изменен.");
        }

        [HttpGet]
        public IActionResult GetAllProviders()
        {
            var response = db.GetDataList<Provider, List<Product>>(provider => true, p => p.Products);
            db.Dispose();
            return this.Ok(response);
        }
    }
}
