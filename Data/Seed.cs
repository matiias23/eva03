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
            if (context.Clients.Any()) return;

            var clients = new List<Client>{
                new Client(){
                    Name = "Cliente1",
                    Rut = "103458453",
                    TotalSumLastMonth = 3,
                },
                new Client(){
                    Name = "Cliente2",
                    Rut = "134558453",
                    TotalSumLastMonth = 5,
                }
            };

            context.Clients.AddRange(clients);
            context.SaveChanges();

            var dishes = new List<Dish>{
                new Dish(){
                    Id = 1,
                    Name = "Plato1",
                    Price = 5000,
                },
                new Dish(){
                    Id = 2,
                    Name = "Plato2",
                    Price = 3000,
                },
                new Dish(){
                    Id = 3,
                    Name = "Plato3",
                    Price = 10000,
                },
                new Dish(){
                    Id = 4,
                    Name = "Plato4",
                    Price = 150000,
                },
            };

            context.Dishes.AddRange(dishes);
            context.SaveChanges();

            var orders = new List<Order>{
                new Order(){
                    Id = 1,
                    ClientId = 1,
                    DishId = 1,
                },
                new Order(){
                    Id = 2,
                    ClientId = 1,
                    DishId = 2,
                },
                new Order(){
                    Id = 3,
                    ClientId = 2,
                    DishId = 4,
                },
            };

            context.Orders.AddRange(orders);
            context.SaveChanges();
        }
    }
}