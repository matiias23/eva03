namespace Api2.DTOs
{
    public class BookReserveDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public List<UsersReserveBookDto> Users { get; set; } = new();
    }
}