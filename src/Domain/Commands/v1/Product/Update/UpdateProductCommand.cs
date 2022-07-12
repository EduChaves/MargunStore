using MargunStore.CrossCutting.Configuration.Entities;
using MediatR;
using System.Collections.Generic;

namespace MargunStore.Domain.Commands.v1.Product.Update
{
    public class UpdateProductCommand : IRequest<UpdateProductCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Length { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
        public bool Active { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<ProductImages> Images { get; set; }
    }
}
