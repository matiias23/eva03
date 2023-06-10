using Microsoft.EntityFrameworkCore;
using Api2.Models;

namespace Api2.Data
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Reserve> Reserves { get; set; } = null!;
    }
}