namespace PizzaBox.Domain.Models
{
    public class Crust : IOrderable
    {
        public int Id{ get; }
        public string Name{ get; }
        public double Price{ get; }
        
        public Crust(int crustId, string crustName, double crustPrice)
        {
            Id = crustId;
            Name = crustName;
            Price = crustPrice;
        }
    }
}