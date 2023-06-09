using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api2.Models;

namespace Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly Itemcontext _context;

        public ItemsController(Itemcontext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItem()
        {
          if (_context.Item == null)
          {
              return NotFound();
          }
            return await _context.Item.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(long id)
        {
          if (_context.Item == null)
          {
              return NotFound();
          }
            var item = await _context.Item.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
          if (_context.Item == null)
          {
              return Problem("Entity set 'Itemcontext.Item'  is null.");
          }
            _context.Item.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = item.Id }, item);
        }

        
        private bool ItemExists(long id)
        {
            return (_context.Item?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
