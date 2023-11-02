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
            return new ResponseBody { };
        }

        [HttpDelete("{id}")]
        public ResponseBody DeleteProvider(int id)
        {
            return new ResponseBody { };
        }

        [HttpGet]
        public ResponseBody GetAllProviders()
        {
            return new ResponseBody { };
        }
    }
}
