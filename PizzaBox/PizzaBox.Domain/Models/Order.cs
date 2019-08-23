using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class Order
    {
        public List<Pizza> ShoppingCart{ get; private set; }

        public decimal Price{ get; private set; }

        private decimal maximumPrice;
        private double maximumPizzaCount;
        private User user;


        public Order(User orderMaker, decimal orderMaximumPrice = 5000, int orderMaximumPizzaCount = 5)
        {
            user = orderMaker;
            maximumPrice = orderMaximumPrice;
            maximumPizzaCount = orderMaximumPizzaCount;

            ShoppingCart = new List<Pizza>();
        }

        //return true if successfully added 'pizzaToAdd' to 'shoppingCart'
        //otherwise, return false
        public bool AddToOrder(Pizza pizzaToAdd)
        {
            pizzaToAdd.CalculatePrice();
            if((this.Price + pizzaToAdd.Price) <= maximumPrice)
            {
                ShoppingCart.Add(pizzaToAdd);
                return true;
            }
            else return false;
        }

        //return true if successfully removed 'pizzaToRemove' from 'shoppingCart'
        //otherwise, return false
        public bool RemoveFromOrder(Pizza pizzaToRemove)
        {
            return ShoppingCart.Remove(pizzaToRemove);
        }

        public void CalculatePrice()
        {
            Price = 0;
            foreach(Pizza p in ShoppingCart)
            {
                Price += p.Price;
            }
        }
    }
}