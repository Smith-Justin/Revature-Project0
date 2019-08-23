using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class Pizza
    {
        public int ToppingLimit{ get; }

        public string Name{ get; set; }

        public decimal Price{ get; private set; }

        public List<Topping> ToppingList{ get; set; }

        public Size Size{ get; set; }
        public Crust Crust{ get; set; }


        public Pizza()
        {
            ToppingList = new List<Topping>();
        }

        /*public Pizza(Size pizzaSize, Crust pizzaCrust, string pizzaName="Pizza", List<Topping> toppingsToAdd=null, int limit=5)
        {
            Name = pizzaName;

            size = pizzaSize;
            crust = pizzaCrust;
            ToppingList = new List<Topping>();
            ToppingList.AddRange(toppingsToAdd);
            ToppingLimit = limit;

            CalculatePrice();
        }*/

        public void CalculatePrice()
        {
            Price = 0;
            Price += Size.Price + Crust.Price;
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