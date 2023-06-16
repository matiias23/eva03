using System.ComponentModel.DataAnnotations;

namespace Api2.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rut { get; set; }
        public string Faculty { get; set; }
        public int TotalSumLastMonth { get; set; }
        public List<Order> Orders { get; set; } = new();
    }

    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public List<Order> Orders { get; set; } = new(); 
    }

    public class Order
    {
        public int Id { get; set; }  
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        public DateOnly CreatedAt { get; set; }
    }
}
