using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Recipes;

namespace PizzaBox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            UserConsole userConsole = new UserConsole();
            userConsole.TakeInput();
        }

        public void MakeNewYork()
        {
            var ny = new NewYork();

            ny.Make(
                new Size("Small", 5),

                new List<Topping>
                {
                    new Topping("Pepperoni", 2),
                    new Topping("Sausage", 2)
                }
            );
        }
    }
}
