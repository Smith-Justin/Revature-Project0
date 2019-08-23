using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class Topping
    {
        public Topping()
        {
            PizzaToppingId1Navigation = new HashSet<Pizza>();
            PizzaToppingId2Navigation = new HashSet<Pizza>();
            PizzaToppingId3Navigation = new HashSet<Pizza>();
            PizzaToppingId4Navigation = new HashSet<Pizza>();
            PizzaToppingId5Navigation = new HashSet<Pizza>();
        }

        public int ToppingId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Pizza> PizzaToppingId1Navigation { get; set; }
        public virtual ICollection<Pizza> PizzaToppingId2Navigation { get; set; }
        public virtual ICollection<Pizza> PizzaToppingId3Navigation { get; set; }
        public virtual ICollection<Pizza> PizzaToppingId4Navigation { get; set; }
        public virtual ICollection<Pizza> PizzaToppingId5Navigation { get; set; }
    }
}
