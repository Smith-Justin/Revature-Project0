using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class Order
    {
        public List<Pizza> shoppingCart{ get; private set; }

        public int Id{ get; }
        public double Price{ get; private set; }
        public Location StoreLocation{ get; private set; }

        private double maximumPrice;
        private double maximumPizzaCount;
        private User user;

        public Order(int orderId, User orderMaker, Location orderLocation, double orderMaximumPrice, int orderMaximumPizzaCount)
        {
            Id = orderId;
            user = orderMaker;
            StoreLocation = orderLocation;
            maximumPrice = orderMaximumPrice;
            maximumPizzaCount = orderMaximumPizzaCount;
        }

        //return true if successfully added 'pizzaToAdd' to 'shoppingCart'
        //otherwise, return false
        public bool AddToOrder(Pizza pizzaToAdd)
        {
            pizzaToAdd.CalculatePrice();
            if((this.Price + pizzaToAdd.Price) <= maximumPrice)
            {
                shoppingCart.Add(pizzaToAdd);
                return true;
            }
            else return false;
        }

        //return true if successfully removed 'pizzaToRemove' from 'shoppingCart'
        //otherwise, return false
        public bool RemoveFromOrder(Pizza pizzaToRemove)
        {
            return shoppingCart.Remove(pizzaToRemove);
        }
    }
}