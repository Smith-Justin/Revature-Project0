using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class Address
    {
        public Address()
        {
            Location = new HashSet<Location>();
        }

        public int AddressId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        public virtual ICollection<Location> Location { get; set; }
    }
}
