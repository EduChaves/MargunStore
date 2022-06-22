namespace MargunStore.Domain.Entities
{
    public class Client : EntityBase
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int BagId { get; set; }
        public Bag Bag { get; set; }
        public bool Active { get; set; }
    }
}
