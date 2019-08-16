namespace PizzaBox.Domain.Models
{
    public class Size : IOrderable
    {
        public int Id{get;}
        public string Name{get;}
        public double Price{get;}

        public Size(int sizeId, string sizeName, double sizePrice)
        {
            Id = sizeId;
            Name = sizeName;
            Price = sizePrice;
        }
    }
}