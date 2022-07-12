using MargunStore.CrossCutting.Configuration.Entities;
using System.Collections.Generic;

namespace MargunStore.Infrastructure.Data.Query.Queries.v1.Product.GetProducts
{
    public class GetProductQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Length { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
        public bool Active { get; set; }
        public int CategoryId { get; set; }
        public CrossCutting.Configuration.Entities.Category Category { get; set; }
        public virtual IEnumerable<ProductImages> Images { get; set; }
    }
}
