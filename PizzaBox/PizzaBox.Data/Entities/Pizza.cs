using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class Pizza
    {
        public int PizzaId { get; set; }
        public int CrustId { get; set; }
        public int SizeId { get; set; }
        public int? ToppingId1 { get; set; }
        public int? ToppingId2 { get; set; }
        public int? ToppingId3 { get; set; }
        public int? ToppingId4 { get; set; }
        public int? ToppingId5 { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }

        public virtual Crust Crust { get; set; }
        public virtual Order Order { get; set; }
        public virtual Size Size { get; set; }
        public virtual Topping ToppingId1Navigation { get; set; }
        public virtual Topping ToppingId2Navigation { get; set; }
        public virtual Topping ToppingId3Navigation { get; set; }
        public virtual Topping ToppingId4Navigation { get; set; }
        public virtual Topping ToppingId5Navigation { get; set; }
    }
}
