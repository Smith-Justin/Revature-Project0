using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Size : AOrderable
    {
        public Size(string sizeName, decimal sizePrice) : base(sizeName, sizePrice){}
    }
}