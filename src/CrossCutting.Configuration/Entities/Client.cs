using System.Collections.Generic;

namespace MargunStore.CrossCutting.Configuration.Entities
{
    public class Client : EntityBase
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public Bag Bag { get; set; }
        public bool Active { get; set; }
        public virtual IEnumerable<Address> Addresses { get; set; }
    }
}
