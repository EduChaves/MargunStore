namespace MargunStore.CrossCutting.Configuration.Entities
{
    public class Address : EntityBase
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Complement { get; set; }
        public string Cep { get; set; }
        public bool Active { get; set; }
    }
}
