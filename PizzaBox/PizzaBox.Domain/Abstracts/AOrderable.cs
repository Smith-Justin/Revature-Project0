namespace PizzaBox.Domain.Abstracts
{
    public abstract class AOrderable
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public decimal Price{ get; set; }

        public AOrderable(string sizeName, decimal sizePrice)
        {
            Name = sizeName;
            Price = sizePrice;
        }
    }
}