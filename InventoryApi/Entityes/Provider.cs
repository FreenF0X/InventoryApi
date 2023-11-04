using System.Collections.Generic;

namespace InventoryApi.Entityes
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
