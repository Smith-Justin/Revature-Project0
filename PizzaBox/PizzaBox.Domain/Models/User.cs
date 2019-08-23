using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Data.Entities;

namespace PizzaBox.Domain.Models
{
    public class User{
        public int Id{ get; set; }
        public Name Name{ get; set; }
        public List<Order> OrderHistory{ get; set; }
        public Order CurrentOrder{ get; set; }
        public Location PreferredLocation{ get; set; }

        private readonly project0dbContext _db = new project0dbContext();

        public User()
        {
            OrderHistory = new List<Order>();
        }

        public void changeName(Name newName)
        {
            Name = newName;
        }

        public void CreateOrder()
        {
            CurrentOrder = new Order(this, 5000, 10);
        }

        public void SendOrder(Location locationToSend)
        {
            locationToSend.RecieveOrder(CurrentOrder);
            OrderHistory.Add(CurrentOrder);
            CurrentOrder=null;
        }

        public List<Data.Entities.User> GetUserList()
        {
            return _db.User.Include("Name").ToList();
        }
    }
}