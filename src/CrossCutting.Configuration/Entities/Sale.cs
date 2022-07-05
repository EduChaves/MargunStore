using System;

namespace MargunStore.CrossCutting.Configuration.Entities
{
    public class Sale : EntityBase
    {
        public int BagId { get; set; }
        public Bag Bag { get; set; }
        public DateTime SaleDate { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public string Payment { get; set; }
    }
}
