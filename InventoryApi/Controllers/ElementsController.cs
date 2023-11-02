using Microsoft.AspNetCore.Mvc;

namespace InventoryApi.Controllers
{
    public class ElementsController
    {
        [HttpPost]
        public ResponseBody CreateNewElement()
        {
            return new ResponseBody { };
        }

        [HttpDelete("{id}")]
        public ResponseBody DeleteElement(int id)
        {
            return new ResponseBody { };
        }

        [HttpGet]
        public ResponseBody GetAllElements()
        {
            return new ResponseBody { };
        }

        [HttpGet("byprovider")]
        public ResponseBody GetAllElementsByProvider(int providerId)
        {
            return new ResponseBody { };
        }
    }
}
