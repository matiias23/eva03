namespace Api2.DTOs
{
    public class UserDto
    {
        public string Name { get; set; } = null!;
        public string Faculty { get; set; } = null!;
        public DateOnly? DateLastReserve { get; set; } = null!;
        public int CantReservesLastMonth { get; set; }
        public List<BookDto> Reserves { get; set; } = new();
    }
}