using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GreenProducts.Data;
using GreenProducts.Models;

namespace GreenProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupermarketsController : ControllerBase
    {
        private readonly GreenDbContext _context;

        public SupermarketsController(GreenDbContext context)
        {
            _context = context;
        }

        // GET: api/Supermarkets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supermarket>>> GetSupermarkets()
        {
            return await _context.Supermarkets.ToListAsync();
        }

        // GET: api/Supermarkets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supermarket>> GetSupermarket(int id)
        {
            var supermarket = await _context.Supermarkets.FindAsync(id);

            if (supermarket == null)
            {
                return NotFound();
            }

            return supermarket;
        }

        // PUT: api/Supermarkets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupermarket(int id, Supermarket supermarket)
        {
            if (id != supermarket.Id)
            {
                return BadRequest();
            }

            _context.Entry(supermarket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupermarketExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Supermarkets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Supermarket>> PostSupermarket(Supermarket supermarket)
        {
            _context.Supermarkets.Add(supermarket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupermarket", new { id = supermarket.Id }, supermarket);
        }

        // DELETE: api/Supermarkets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupermarket(int id)
        {
            var supermarket = await _context.Supermarkets.FindAsync(id);
            if (supermarket == null)
            {
                return NotFound();
            }

            _context.Supermarkets.Remove(supermarket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SupermarketExists(int id)
        {
            return _context.Supermarkets.Any(e => e.Id == id);
        }
    }
}
