using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class Inventory{
        public Dictionary<IOrderable, int> InventoryCount{ get; }

        public Inventory()
        {
            InventoryCount = new Dictionary<IOrderable, int>();
        }


        public void AddToInventory(Tuple<IOrderable, int> newInventory)
        {
            if(InventoryCount.ContainsKey(newInventory.Item1)) InventoryCount[newInventory.Item1] += newInventory.Item2;
            else InventoryCount[newInventory.Item1] = newInventory.Item2;
        }


        public bool RemoveFromInventory(Tuple<IOrderable, int> oldInventory)
        {
            if(InventoryCount.ContainsKey(oldInventory.Item1))
            {
                InventoryCount[oldInventory.Item1] -= oldInventory.Item2;
                if(InventoryCount[oldInventory.Item1] < 0) InventoryCount[oldInventory.Item1] = 0;

                return true;
            }
            else return false;

        }
    }
}