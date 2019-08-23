using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Data.Entities;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Recipes;

namespace PizzaBox.Domain.Models
{
    public class UserConsole
    {
        private User _user;

        private project0dbContext _db = new project0dbContext();
        public UserConsole(){}

        public void TakeInput()
        {
            bool isQuitting = false;
            while(!isQuitting)
            {
                System.Console.Write("enter command: ");
                string input = System.Console.ReadLine();
                string[] splitInput = input.Split(' ');

                switch(splitInput[0])
                {
                    case "create":
                        Create(splitInput[1]);
                        break;
                    
                    case "view":
                        View(splitInput[1]);
                        break;
                    
                    case "login":
                        Login();
                        break;
                    
                    case "logout":
                        Logout();
                        break;
                    
                    case "confirm":
                        ConfirmOrder();
                        break;
                    
                    case "quit":
                        System.Console.WriteLine("Quitting application...");
                        isQuitting = true;
                        break;
                }
            }
        }

        public void Create(string creation)
        {
            switch(creation)
            {
                case "location":
                    System.Console.WriteLine("Creating Location...");

                    System.Console.Write("Please enter the location name: ");
                    string locationName = System.Console.ReadLine();

                    System.Console.Write("Please enter the State: ");
                    string locationState = System.Console.ReadLine();

                    System.Console.Write("Please enter the City: ");
                    string locationCity = System.Console.ReadLine();

                    System.Console.Write("Please enter the Street Address: ");
                    string locationStreet = System.Console.ReadLine();


                    _db.Add(new Data.Entities.Location()
                    {
                        Name = locationName,
                        Address = new Data.Entities.Address()
                        {
                            State = locationState,
                            City = locationCity,
                            Street = locationStreet
                        }
                    });
                    _db.SaveChanges();
                    break;

                case "user":
                    System.Console.WriteLine("Creating User...");
                    
                    System.Console.Write("Please enter your first name: ");
                    string first = System.Console.ReadLine();

                    System.Console.Write("Please enter your last name: ");
                    string last = System.Console.ReadLine();

                    Name name = new Name()
                    {
                        First = first,
                        Last = last
                    };
                    _user = new User()
                    {
                        Name = name
                    };

                    Data.Entities.User dbUser = new Data.Entities.User()
                    {
                        Name = new Data.Entities.Name()
                        {
                            FirstName = first,
                            LastName = last
                        }
                    };
                    _db.Add(dbUser);
                    _db.SaveChanges();

                    _user.Id = dbUser.UserId;
                    System.Console.WriteLine(_user.Id);
                    break;
                
                case "order":
                    if(_user==null)
                    {
                        System.Console.WriteLine("To make an order, please sign in...");
                        break;
                    }
                    else
                    {
                        _user.CreateOrder();
                        break;
                    }
                
                case "pizza":
                    if(_user == null)
                    {
                        System.Console.WriteLine("To make a pizza, please sign in and make an order...");
                    }

                    else if(_user.CurrentOrder == null)
                    {
                        System.Console.WriteLine("To make a pizza, please create an order...");
                    }

                    else
                    {
                        System.Console.WriteLine("Creating pizza...");
                        CreatePizza();
                    }
                    break;
            }
        }

        public void CreatePizza()
        {
            System.Console.Write("What kind of pizza?: ");
            string pizzaType = System.Console.ReadLine();

            int sizeId, crustId, topping1Id, topping2Id;
            Data.Entities.Size pizzaSize;
            Data.Entities.Crust pizzaCrust;
            Data.Entities.Topping pizzaTopping1, pizzaTopping2;
            Pizza pizza;

            switch(pizzaType)
            {
                case "custom":

                    System.Console.WriteLine("Selecting size...");
                    foreach(Data.Entities.Size s in _db.Size.ToList())
                    {
                        System.Console.WriteLine($"{s.SizeId}: {s.Name} ${s.Price}");
                    }
                    System.Console.Write("Enter size id: ");
                    sizeId = System.Convert.ToInt32(System.Console.ReadLine());
                    pizzaSize = _db.Size.Find(sizeId);
                    if(pizzaSize == null)
                    {
                        System.Console.WriteLine("Please enter a valid id and try again...");
                        return;
                    }

                    System.Console.WriteLine("Selecting crust...");
                    foreach(Data.Entities.Crust c in _db.Crust.ToList())
                    {
                        System.Console.WriteLine($"{c.CrustId}: {c.Name} ${c.Price}");
                    }

                    System.Console.Write("Enter crust id: ");
                    crustId = System.Convert.ToInt32(System.Console.ReadLine());
                    pizzaCrust = _db.Crust.Find(crustId);
                    if(pizzaCrust == null)
                    {
                        System.Console.WriteLine("Please enter a valid id and try again...");
                        return;
                    }

                    System.Console.WriteLine("Selecting toppings...");
                    foreach(Data.Entities.Topping t in _db.Topping.ToList())
                    {
                        System.Console.WriteLine($"{t.ToppingId}: {t.Name} ${t.Price}");
                    }

                    System.Console.Write("Enter first topping id: ");
                    topping1Id = System.Convert.ToInt32(System.Console.ReadLine());
                    pizzaTopping1 = _db.Topping.Find(topping1Id);

                    System.Console.Write("Enter second topping id: ");
                    topping2Id = System.Convert.ToInt32(System.Console.ReadLine());
                    pizzaTopping2 = _db.Topping.Find(topping2Id);


                    pizza = new Pizza()
                    {
                        Size = new Size(pizzaSize.Name, pizzaSize.Price){Id = sizeId},
                        Crust = new Crust(pizzaCrust.Name, pizzaCrust.Price){Id = crustId}
                    };
                    if(pizzaTopping1 != null) pizza.AddTopping(new Topping(pizzaTopping1.Name, pizzaTopping1.Price){Id = topping1Id});
                    if(pizzaTopping2 != null) pizza.AddTopping(new Topping(pizzaTopping2.Name, pizzaTopping2.Price){Id = topping2Id});

                    _user.CurrentOrder.AddToOrder(pizza);
                    break;
                
                case "preset":
                    CreatePresetPizza();
                    break;
            }
        }
        
        public void CreatePresetPizza()
        {
            System.Console.Write("What kind of preset?: ");
            string presetType = System.Console.ReadLine();

            APizzaFactory factory;

            switch(presetType)
            {
                case "newyork":
                    factory = new NewYork();
                    break;
                
                case "chicago":
                    factory = new Chicago();
                    break;
                
                default:
                    factory = new NewYork();
                    System.Console.WriteLine("Please enter 'chicago' or 'newyork' and try again...");
                    break;
            }

            int sizeId, topping1Id, topping2Id;
            Data.Entities.Size pizzaSize;
            Data.Entities.Topping pizzaTopping1, pizzaTopping2;
            Pizza pizza;

            System.Console.WriteLine("Selecting size...");
            foreach(Data.Entities.Size s in _db.Size.ToList())
            {
                System.Console.WriteLine($"{s.SizeId}: {s.Name} ${s.Price}");
            }
            System.Console.Write("Enter size id: ");
            sizeId = System.Convert.ToInt32(System.Console.ReadLine());
            pizzaSize = _db.Size.Find(sizeId);
            if(pizzaSize == null)
            {
                System.Console.WriteLine("Please enter a valid id and try again...");
                return;
            }


            System.Console.WriteLine("Selecting toppings...");
            foreach(Data.Entities.Topping t in _db.Topping.ToList())
            {
                System.Console.WriteLine($"{t.ToppingId}: {t.Name} ${t.Price}");
            }

            System.Console.Write("Enter first topping id: ");
            topping1Id = System.Convert.ToInt32(System.Console.ReadLine());
                pizzaTopping1 = _db.Topping.Find(topping1Id);

            System.Console.Write("Enter second topping id: ");
            topping2Id = System.Convert.ToInt32(System.Console.ReadLine());
            pizzaTopping2 = _db.Topping.Find(topping2Id);


            List<Topping> toppingList = new List<Topping>();
            if(pizzaTopping1 != null) toppingList.Add(new Topping(pizzaTopping1.Name, pizzaTopping1.Price){Id = topping1Id});
            if(pizzaTopping2 != null) toppingList.Add(new Topping(pizzaTopping2.Name, pizzaTopping2.Price){Id = topping2Id});

            pizza = factory.Make(new Size(pizzaSize.Name, pizzaSize.Price){Id = sizeId}, toppingList);
            pizza.CalculatePrice();
            _user.CurrentOrder.AddToOrder(pizza);
        }

        public void ConfirmOrder()
        {
            if(_user == null)
            {
                System.Console.WriteLine("Please log in and create an order to confirm your order...");
            }
            else if(_user.CurrentOrder == null)
            {
                System.Console.WriteLine("Please create an order to confirm your order...");
            }
            else
            {
                ViewLocations();
                System.Console.Write("Enter location id: ");
                int locationId = System.Convert.ToInt32(System.Console.ReadLine());
                if(_db.Location.Find(locationId) == null)
                    {
                        System.Console.WriteLine("Please enter a valid id and try again...");
                        return;
                    }
                Data.Entities.Order dbOrder = new Data.Entities.Order()
                {
                    User = _db.User.Find(_user.Id),
                    Location = _db.Location.Find(locationId),
                    OrderTime = System.DateTime.Now
                };
                _db.Add(dbOrder);
                foreach(Pizza pizza in _user.CurrentOrder.ShoppingCart)
                {
                    Data.Entities.Pizza p = new Data.Entities.Pizza(){
                        Size = _db.Size.Find(pizza.Size.Id),
                        Crust = _db.Crust.Find(pizza.Crust.Id),
                        Price = pizza.Price
                    };
                    if(pizza.ToppingList.Count >= 1) p.ToppingId1 = pizza.ToppingList[0].Id;
                    if(pizza.ToppingList.Count >= 2) p.ToppingId2 = pizza.ToppingList[1].Id;
                    if(pizza.ToppingList.Count >= 3) p.ToppingId3 = pizza.ToppingList[2].Id;
                    if(pizza.ToppingList.Count >= 4) p.ToppingId4 = pizza.ToppingList[3].Id;
                    if(pizza.ToppingList.Count >= 5) p.ToppingId5 = pizza.ToppingList[4].Id;

                    p.OrderId = dbOrder.OrderId;
                    _db.Add(p);
                }
                _user.CurrentOrder.CalculatePrice();
                _user.OrderHistory.Add(_user.CurrentOrder);
                _user.CurrentOrder=null;
                _db.SaveChanges();
            }
        }

        public void View(string viewString)
        {
            switch(viewString)
            {
                case "locations":
                    ViewLocations();
                    break;
                
                case "users":
                    ViewUsers();
                    break;
                
                case "order":
                    foreach(Pizza pizza in _user.CurrentOrder.ShoppingCart)
                    {
                        System.Console.WriteLine(pizza.Size.Name);
                        System.Console.WriteLine(pizza.Crust.Name);
                        foreach(Topping topping in pizza.ToppingList)
                        {
                            System.Console.WriteLine(topping.Name);
                        }
                        System.Console.WriteLine();
                    }
                    break;
                case "history":
                    foreach(Order order in _user.OrderHistory)
                    {
                        System.Console.WriteLine($"Order: ${order.Price}");
                        foreach(Pizza pizza in order.ShoppingCart)
                        {
                            System.Console.WriteLine($"Pizza: ${pizza.Price}");
                            System.Console.WriteLine($"Size: {pizza.Size.Name}");
                            System.Console.WriteLine($"Crust: {pizza.Crust.Name}");
                            foreach(Topping topping in pizza.ToppingList)
                            {
                                System.Console.WriteLine($"Topping: {topping.Name}");
                            }
                            System.Console.WriteLine();
                        }
                        System.Console.WriteLine();
                        System.Console.WriteLine();
                    }
                    break;
            }
        }

        public void ViewLocations()
        {
            System.Console.WriteLine("Locations:");
            foreach(Data.Entities.Location location in _db.Location.Include("Address").ToList())
            {
                System.Console.WriteLine($"{location.LocationId}: {location.Address.Street}, {location.Address.City}, {location.Address.State}");
            }
        }

        public void ViewUsers()
        {
            foreach(Data.Entities.User user in new User().GetUserList())
            {
                System.Console.WriteLine($"{user.Name.FirstName} {user.Name.LastName}");
                System.Console.WriteLine();
            }
        }

        public void Login()
        {
            if(_user != null)
            {
                System.Console.WriteLine("Please log out before logging into a different acount...");
                return;
            }
            System.Console.WriteLine("Logging in...");
            System.Console.Write("Enter user id: ");
            int id = System.Convert.ToInt32(System.Console.ReadLine());
            
            Data.Entities.User dbUser = _db.User.Find(id);
            Data.Entities.Name dbName = _db.Name.Find(dbUser.NameId);
            if(dbUser == null)
            {
                System.Console.WriteLine("Invalid user id");
                return;
            }
            _user = new User()
            {
                Name = new Name()
                {
                    First = dbName.FirstName,
                    Last = dbName.LastName
                },
                Id = id
            };

            _user.OrderHistory = new List<Order>();
            foreach(Data.Entities.Order o in _db.Order.ToList())
            {
                if(o.UserId == id)
                {
                    Order order = new Order(_user);
                    foreach(Data.Entities.Pizza p in _db.Pizza.ToList())
                    {
                        if(p.OrderId == o.OrderId)
                        {
                            Data.Entities.Crust pizzaCrust = _db.Crust.Find(p.CrustId);
                            Data.Entities.Size pizzaSize = _db.Size.Find(p.SizeId);
                            Pizza pizza = new Pizza()
                            {
                                Crust = new Crust(p.Crust.Name, p.Crust.Price){Id = p.CrustId},
                                Size = new Size(p.Size.Name, p.Size.Price){Id = p.SizeId}
                            };

                            Data.Entities.Topping topping;

                            topping = _db.Topping.Find(p.ToppingId1);
                            if(p.ToppingId1 != null) pizza.AddTopping(new Topping(topping.Name, topping.Price){Id = topping.ToppingId});
                            topping = _db.Topping.Find(p.ToppingId2);
                            if(p.ToppingId2 != null) pizza.AddTopping(new Topping(topping.Name, topping.Price){Id = topping.ToppingId});
                            topping = _db.Topping.Find(p.ToppingId3);
                            if(p.ToppingId3 != null) pizza.AddTopping(new Topping(topping.Name, topping.Price){Id = topping.ToppingId});
                            topping = _db.Topping.Find(p.ToppingId4);
                            if(p.ToppingId4 != null) pizza.AddTopping(new Topping(topping.Name, topping.Price){Id = topping.ToppingId});
                            topping = _db.Topping.Find(p.ToppingId5);
                            if(p.ToppingId5 != null) pizza.AddTopping(new Topping(topping.Name, topping.Price){Id = topping.ToppingId});

                            order.AddToOrder(pizza);
                        }
                    }
                    order.CalculatePrice();
                    _user.OrderHistory.Add(order);
                }
            }
        }

        public void Logout()
        {
            System.Console.WriteLine("Logging out...");
            _user = null;
        }
    }
}