using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class Pizza
    {
        public int ToppingLimit{ get; }

        public int Id{ get; }
        public string Name{ get; private set; }

        public double Price{ get; private set; }

        public List<Topping> ToppingList{ get; private set; }

        public Size size;
        public Crust crust;


        public Pizza(int pizzaId, Size pizzaSize, Crust pizzaCrust, string pizzaName="Pizza", List<Topping> toppingsToAdd=null, int limit=5)
        {
            Id = pizzaId;
            Name = pizzaName;

            size = pizzaSize;
            crust = pizzaCrust;
            ToppingList = new List<Topping>();
            ToppingList.AddRange(toppingsToAdd);
            ToppingLimit = limit;

            CalculatePrice();
        }

        public void CalculatePrice()
        {
            Price = 0.0;
            Price += size.Price + crust.Price;
            foreach(Topping topping in ToppingList)
            {
                Price += topping.Price;
            }
        }

        public void ChangeName(string newName)
        {
            Name = newName;
        }

        public void AddTopping(Topping topping)
        {
            ToppingList.Add(topping);
        }

        //returns true if 'topping' is successfully removed from 'toppingList'
        public bool RemoveTopping(Topping topping)
        {
            return ToppingList.Remove(topping);
        }
    }
}