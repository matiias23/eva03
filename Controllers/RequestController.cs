using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api2.Data;
using Api2.DTOs;

namespace Api2.Controllers
{
    public class RequestController : BaseApiController
    {
        private readonly ItemContext _context;
        private readonly IMapper _mapper;

        public RequestController(ItemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("1")]
        public async Task<ActionResult<IEnumerable<UserDto>>> FirstEndPoint()
        {
            var startDate = DateOnly.FromDateTime(DateTime.Today.AddMonths(-1));
            startDate = startDate.AddDays(-1);
            var endDate = DateOnly.FromDateTime(DateTime.Today);

            var userReserves = await _context.Users
                .Include(u => u.Reserves)
                .ThenInclude(r => r.Book)
                .ToListAsync();

            var userDtos = userReserves.Select(user =>
            {
                var lastMonthReserves = user.Reserves
                    .Where(r => r.ReservedAt >= startDate && r.ReservedAt <= endDate)
                    .ToList();

                var bookDtos = lastMonthReserves.Select(reserve => _mapper.Map<BookDto>(reserve.Book)).ToList();

                return new UserDto
                {
                    Name = user.Name,
                    Faculty = user.Faculty,
                    DateLastReserve = lastMonthReserves.OrderByDescending(r => r.ReservedAt).FirstOrDefault()?.ReservedAt,
                    CantReservesLastMonth = lastMonthReserves.Count,
                    Reserves = bookDtos
                };
            }).ToList();

            var userNamesWithReserves = userDtos.Select(ud => ud.Name).ToList();

            var usersWithoutReserves = await _context.Users
                .Where(u => !userNamesWithReserves.Contains(u.Name))
                .ToListAsync();

            var usersWithoutReservesDtos = usersWithoutReserves.Select(user => new UserDto
            {
                Name = user.Name,
                Faculty = user.Faculty,
                DateLastReserve = null,
                CantReservesLastMonth = 0,
                Reserves = new List<BookDto>()
            }).ToList();

            userDtos.AddRange(usersWithoutReservesDtos);

            return Ok(userDtos);
        }

        [HttpGet("2")]
        public async Task<ActionResult<IEnumerable<BookReserveDto>>> SecondEndPoint()
        {
            var books = await _context.Books
                .Include(b => b.Reserves)
                .ThenInclude(r => r.User)
                .ToListAsync();

            var bookReserveDtos = books.Select(book =>
            {
                var usersReserveBookDtos = book.Reserves.Select(reserve => new UsersReserveBookDto
                {
                    Id = reserve.User.Id,
                    Name = reserve.User.Name,
                    Faculty = reserve.User.Faculty
                }).ToList();

                return new BookReserveDto
                {
                    Title = book.Title,
                    Description = book.Description,
                    Users = usersReserveBookDtos
                };
            }).ToList();

            return Ok(bookReserveDtos);
        }

    }
}
    
