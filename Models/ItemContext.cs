using Microsoft.EntityFrameworkCore;

namespace Api2.Models;

public class ItemContext : DbContext
{
    public ItemContext(DbContextOptions<ItemContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Reserve> Reserves { get; set; } = null!;
}