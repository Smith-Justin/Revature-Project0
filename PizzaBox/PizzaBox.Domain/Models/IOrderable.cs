namespace PizzaBox.Domain.Models
{
    public interface IOrderable
    {
        int Id{ get; }
        string Name{ get; }
        double Price{ get; }
    }
}