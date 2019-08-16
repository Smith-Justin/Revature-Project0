namespace PizzaBox.Domain.Models
{
    public class User{
        public int Id{ get; }
        public string Name{ get; private set; }

        public User(int userId, string userName)
        {
            Id = userId;
            Name = userName;
        }

        public void changeName(string newName)
        {
            Name = newName;
        }
    }
}