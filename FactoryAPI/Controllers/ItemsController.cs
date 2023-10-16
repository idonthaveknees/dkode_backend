using FactoryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FactoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        FactoryDbContext _context = new FactoryDbContext();

        // Create a new item
        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return new CreatedAtActionResult(nameof(GetById),
                                             "Items",
                                             new { id = item.Id },
                                             item);
        }

        // Retrieve a single item
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _context.Items.Find(id);
            return item == null ? NotFound() : Ok(item);
        }

        // Retrieve all items (only if you'll be using an ORM framework)
        [HttpGet]
        public Task<List<Item>> GetAll() =>
            _context.Items.OrderBy(p => p.Id).ToListAsync();

        // Update an existing item


        // Delete an item


    }
}
