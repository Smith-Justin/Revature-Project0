using System.Collections.Generic;
using PizzaBox.Data.Entities;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Recipes
{
    public class Chicago : APizzaFactory
    {
        project0dbContext _db = new project0dbContext();
        public override Models.Pizza Make(Models.Size s, List<Models.Topping> t)
        {
            Data.Entities.Crust chicagoCrustDB = _db.Crust.Find(3);
            Models.Crust chicagoCrustModel = new Models.Crust(chicagoCrustDB.Name, chicagoCrustDB.Price){Id = chicagoCrustDB.CrustId};
            Models.Pizza pizza = new Models.Pizza()
            {
                Size = s,
                Crust = chicagoCrustModel
            };
            foreach(Models.Topping topping in t)
            {
                pizza.AddTopping(topping);
            }
            
            return pizza;
        }
    }
}