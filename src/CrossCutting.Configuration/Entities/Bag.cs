using System.Collections.Generic;

namespace MargunStore.CrossCutting.Configuration.Entities
{
    public class Bag : EntityBase
    {
        public int ProductId { get; set; }
        public double TotalVale { get; set; }
        public virtual Sale Sale { get; set; }
        public bool Active { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
