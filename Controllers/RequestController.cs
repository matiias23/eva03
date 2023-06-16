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
        public async Task<ActionResult<IEnumerable<ClientDto>>> FirstEndPoint()
        {
            var startDate = DateOnly.FromDateTime(DateTime.Today.AddMonths(-1));
            startDate = startDate.AddDays(-1);
            var endDate = DateOnly.FromDateTime(DateTime.Today);

            var clientOrders = await _context.Clients
                .Include(u => u.Orders)
                .ThenInclude(r => r.Dish)
                .ToListAsync();

            var clientDtos = clientOrders.Select(user =>
            {
                var lastMonthReserves = client.Orders
                    .Where(r => r.CreatedAt >= startDate && r.CreatedAt <= endDate)
                    .ToList();

                var DishDtos = lastMonthReserves.Select(reserve => _mapper.Map<DishDto>(reserve.Dish)).ToList();

                return new ClientDto
                {
                    Name = client.Name,
                    Rut = client.Rut,
                    TotalSumLastMonth = lastMonthReserves.Count,
                    Orders = DishDtos
                };
            }).ToList();

            var clientWithOrders = clientDtos.Select(ud => ud.Name).ToList();

            var clientWithOutOrders = await _context.Clients
                .Where(u => !clientWithOrders.Contains(u.Name))
                .ToListAsync();

            var clientWithOutOrdersDtos = clientWithOutOrders.Select(client => new ClientDto
            {
                Name = client.Name,
                Rut = client.Rut,
                TotalSumLastMonth = 0,
                Orders = new List<DishDto>()
            }).ToList();

            userDtos.AddRange(clientWithOutOrdersDtos);

            return Ok(clientDtos);
        }

        [HttpGet("2")]
        public async Task<ActionResult<IEnumerable<DishOrderDto>>> SecondEndPoint()
        {
            var didshes = await _context.Dishes
                .Include(b => b.Orders)
                .ThenInclude(r => r.Client)
                .ToListAsync();

            var DishOrderDto = dishes.Select(dish =>
            {
                var clientReservesOrdersDto = dish.Orders.Select(reserve => new ClienOrderDish
                {
                    Id = order.Client.Id,
                    Name = order.Client.Name,
                    Faculty = order.Client.Faculty
                }).ToList();

                return new DishOrderDto
                {
                    Name = dish.Name,
                    Price = dish.Price,
                    Clients = clientReservesOrdersDto
                };
            }).ToList();

            return Ok(DishOrderDto);
        }


}

}
    
