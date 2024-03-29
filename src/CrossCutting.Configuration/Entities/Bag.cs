﻿using System.Collections.Generic;

namespace MargunStore.CrossCutting.Configuration.Entities
{
    public class Bag : EntityBase
    {
        public int Quantity { get; set; }
        public double TotalVale { get; set; }
        public bool Active { get; set; }
        public virtual IEnumerable<ItemBag> ItemsBag { get; set; }
    }
}
