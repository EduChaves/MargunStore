namespace MargunStore.CrossCutting.Configuration.Entities
{
    public class ProductImages : EntityBase
    {
        public int ProductId { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }
    }
}
