using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InventoryApi.Controllers
{
    [ApiController]
    [Route("providers")]
    public class ProvidersController
    {
        [HttpPost]
        public ResponseBody CreateNewProvider()
        {
            
        }

        [HttpDelete("{id}")]
        public ResponseBody DeleteProvider(int id)
        {
            
        }

        [HttpGet]
        public ResponseBody GetAllProviders()
        {
            
        }
    }
}
