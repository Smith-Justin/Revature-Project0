namespace PizzaBox.Domain.Models
{
    public class Topping : IOrderable
    {
        public int Id{ get; }
        public string Name{ get; }
        public double Price{ get; }

        public Topping(int toppingId, double toppingPrice, string toppingName)
        {
            Id = toppingId;
            Price = toppingPrice;
            Name = toppingName;
        }
    }
}