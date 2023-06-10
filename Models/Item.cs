using System.ComponentModel.DataAnnotations;

namespace Api2.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }
        public List<Reserve> Reserves { get; set; } = new();
    }

    public class Book
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Reserve> Reserves { get; set; } = new(); 
    }

    public class Reserve
    {
        public int Id { get; set; }
        public DateOnly ReservedAt { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
