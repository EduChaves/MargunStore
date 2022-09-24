namespace MargunStore.CrossCutting.Configuration.Entities
{
    public class ProductImages : EntityBase
    {
        public string Image { get; set; }
        public Product Product { get; set; }
        public bool Active { get; set; }
    }
}
