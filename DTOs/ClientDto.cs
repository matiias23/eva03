namespace Api2.DTOs
{
    public class ClientDto
    {
        public string Name { get; set; }
        public string Rut { get; set; } = null!;
        public int TotalSumLastMonth { get; set; }
        public List<DishDto> Orders { get; set; } = new();
        
    }
}