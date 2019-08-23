using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Topping : AOrderable
    {
        public Topping(string toppingName, decimal toppingPrice) : base(toppingName, toppingPrice){}
    }
}