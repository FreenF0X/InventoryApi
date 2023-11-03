using System.Collections.Generic;
using System.Data.Common;

namespace InventoryApi.Entityes
{
    public class Element
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public List<Provider> Providers { get; set; }
    }
}
