namespace PizzaBox.Domain.Models{
    public class Location
    {
        public int Id{ get; }
        public string Name{ get; }
        public string Address{ get; }
        public Inventory StoreInventory{ get; }

        public Location(int locationId, string locationName, string locationAddress, Inventory locationInventory=null)
        {
            Id = locationId;
            Name = locationName;
            Address = locationAddress;
            
            if(locationInventory == null) StoreInventory = new Inventory();
            else StoreInventory = locationInventory;
        }
    }
}