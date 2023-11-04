using System.Collections.Generic;
using System.Data.Common;

namespace InventoryApi.Entityes
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public List<Provider> Providers { get; set; }
    }
}
