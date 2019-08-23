using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Crust : AOrderable
    {   
        public Crust(string crustName, decimal crustPrice) : base(crustName, crustPrice){}
    }
}