using System.Collections.Generic;

namespace MargunStore.CrossCutting.Configuration.Entities
{
    public class ItemBag : EntityBase
    {
        public int Quantity { get; set; }
        public bool Active { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
