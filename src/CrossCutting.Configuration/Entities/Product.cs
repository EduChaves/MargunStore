using System.Collections.Generic;

namespace MargunStore.CrossCutting.Configuration.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Length { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
        public ItemBag ItemBag { get; set; }
        public bool Active { get; set; }
        public Category Category { get; set; }
        public virtual IEnumerable<ProductImages> Images { get; set; }
    }
}
