namespace Api2.DTOs
{
    public class DishOrderDto
    {
        public string Name { get; set; } = null!;
        public string Price { get; set; } = null!;
        public List<ClienOrderDish> Users { get; set; } = new();
    }
}