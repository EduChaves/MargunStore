using System;

namespace MargunStore.CrossCutting.Configuration.Entities
{
    public class Sale : EntityBase
    {
        public Client Client { get; set; }
        public DateTime SaleDate { get; set; }
        public string Payment { get; set; }
    }
}
