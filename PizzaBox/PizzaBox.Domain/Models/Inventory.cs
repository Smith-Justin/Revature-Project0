using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class Inventory{
        public Dictionary<string, int> InventoryCount{ get; }

        public Inventory()
        {
            InventoryCount = new Dictionary<string, int>();
            UpdateInventory();

        }


        public void AddToInventory(Tuple<string, int> newInventory)
        {
            if(InventoryCount.ContainsKey(newInventory.Item1)) InventoryCount[newInventory.Item1] += newInventory.Item2;
            else InventoryCount[newInventory.Item1] = newInventory.Item2;
        }


        public bool RemoveFromInventory(Tuple<string, int> oldInventory)
        {
            if(InventoryCount.ContainsKey(oldInventory.Item1))
            {
                if(InventoryCount[oldInventory.Item1] - oldInventory.Item2 < 0) return false;
                else
                {
                    InventoryCount[oldInventory.Item1] -= oldInventory.Item2;
                    return true;
                }
            }
            else return false;

        }

        //TODO: set UpdateInventory to write/read to/from database
        public bool UpdateInventory()
        {
            return false;
        }
    }
}