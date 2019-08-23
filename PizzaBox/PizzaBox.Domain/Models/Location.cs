using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Data.Entities;

namespace PizzaBox.Domain.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public Address StoreAddress{ get; set; }
        public Inventory StoreInventory{ get; set; }
        public List<Order> OrderHistory { get; set; }
        public List<Order> CurrentOrders { get; set; }

        //private static List<Location> LocationList{ get; set; }

        private readonly project0dbContext _db = new project0dbContext();

        public List<Data.Entities.Location> GetLocationList()
        {
           /* if(LocationList == null)
            {
                LocationList = _db.Location.ToList();
            }
            return LocationList;*/
            return _db.Location.Include("Address").ToList();
        }

        public void RecieveOrder(Order orderToAdd)
        {
            CurrentOrders.Add(orderToAdd);
            OrderHistory.Add(orderToAdd);
        }

        //returns true if the given order was in 'CurrentOrders' and was properly removed
        //otherwise, returns false
        public bool CompleteOrder(Order completedOrder)
        {
            if(CurrentOrders.Contains(completedOrder))
            {
                return CurrentOrders.Remove(completedOrder);
            }
            else return false;
        }
    }
}