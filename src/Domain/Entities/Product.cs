namespace MargunStore.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Length { get; set; }
        //public string Image { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
        public bool Active { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
