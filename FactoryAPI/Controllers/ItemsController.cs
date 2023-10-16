using FactoryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FactoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly FactoryDbContext _context;

        public ItemsController(FactoryDbContext context)
        {
            _context = context;
        }

        // Create a new item
        [HttpPost]
        public async Task<ActionResult<List<Item>>> Create(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return Ok(await _context.Items.ToListAsync());
        }

        // Retrieve a single item
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetById(int id)
        {
            var item = await _context.Items.FindAsync(id);
            return item == null ? BadRequest("Item not found.") : Ok(item);
        }

        // Retrieve all items (only if you'll be using an ORM framework)
        [HttpGet]
        public async Task<ActionResult<List<Item>>> GetAll() 
        {
            return Ok(await _context.Items.ToListAsync());
        }

        // Update an existing item
        [HttpPut]
        public async Task<ActionResult<List<Item>>> Update(Item request)
        {
            var item = await _context.Items.FindAsync(request.Id);

            if (item == null) 
            {
                return BadRequest("Item not found.");
            }

            item.Name = request.Name;
            item.Description = request.Description;
            item.Price = request.Price;
            await _context.SaveChangesAsync();

            return Ok(await _context.Items.ToListAsync());
        }

        // Delete an item
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Item>>> Delete(int id) 
        {
            var item = await _context.Items.FindAsync(id);
            
            if (item == null) 
            {
                return BadRequest("Item not found.");
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return Ok(await _context.Items.ToListAsync());
        } 
    }
}
