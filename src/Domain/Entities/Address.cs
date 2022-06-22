namespace MargunStore.Domain.Entities
{
    public class Address : EntityBase
    {
        public string Stret { get; set; }
        public int Number { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Complement { get; set; }
        public int Cep { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
