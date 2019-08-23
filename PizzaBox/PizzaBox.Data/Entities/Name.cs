using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class Name
    {
        public Name()
        {
            User = new HashSet<User>();
        }

        public int NameId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
