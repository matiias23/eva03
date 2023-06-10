using Api2.Models;

namespace Api2.Data
{
    public class Seed
    {
        public static void SeedData(ItemContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            InternalSeed(context);
        }

        private static void InternalSeed(ItemContext context)
        {
            if (context.Users.Any()) return;

            var users = new List<User>{
                new User(){
                    Code = "001",
                    Name = "Nombre1",
                    Faculty = "Facultad1",
                },
                new User(){
                    Code = "002",
                    Name = "Nombre2",
                    Faculty = "Facultad2",
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var books = new List<Book>{
                new Book(){
                    Code = "001",
                    Title = "Libro1",
                    Description = "Descripcion1",
                },
                new Book(){
                    Code = "002",
                    Title = "Libro2",
                    Description = "Descripcion2",
                },
                new Book(){
                    Code = "003",
                    Title = "Libro3",
                    Description = "Descripcion3",
                },
                new Book(){
                    Code = "004",
                    Title = "Libro4",
                    Description = "Descripcion",
                },
            };

            context.Books.AddRange(books);
            context.SaveChanges();

            var reserves = new List<Reserve>{
                new Reserve(){
                    ReservedAt = DateOnly.FromDateTime(DateTime.Now),
                    UserId = 1,
                    BookId = 1,
                },
                new Reserve(){
                    ReservedAt = DateOnly.FromDateTime(DateTime.Now),
                    UserId = 1,
                    BookId = 4,
                },
                new Reserve(){
                    ReservedAt = DateOnly.FromDateTime(DateTime.Now),
                    UserId = 2,
                    BookId = 2,
                },
            };

            context.Reserves.AddRange(reserves);
            context.SaveChanges();
        }
    }
}