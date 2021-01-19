using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GreenProducts.Data;
using GreenProducts.Models;

namespace GreenProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Supermarket_ProductController : ControllerBase
    {
        private readonly GreenDbContext _context;

        public Supermarket_ProductController(GreenDbContext context)
        {
            _context = context;
        }

        // GET: api/Supermarket_Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supermarket_Product>>> GetSupermarket_Products()
        {
            return await _context.Supermarket_Products.ToListAsync();
        }

        // GET: api/Supermarket_Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supermarket_Product>> GetSupermarket_Product(int id)
        {
            var supermarket_Product = await _context.Supermarket_Products.FindAsync(id);

            if (supermarket_Product == null)
            {
                return NotFound();
            }

            return supermarket_Product;
        }

        // PUT: api/Supermarket_Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupermarket_Product(int id, Supermarket_Product supermarket_Product)
        {
            if (id != supermarket_Product.Id)
            {
                return BadRequest();
            }

            _context.Entry(supermarket_Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Supermarket_ProductExists(id))
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

        // POST: api/Supermarket_Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Supermarket_Product>> PostSupermarket_Product(Supermarket_Product supermarket_Product)
        {
            _context.Supermarket_Products.Add(supermarket_Product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupermarket_Product", new { id = supermarket_Product.Id }, supermarket_Product);
        }

        // DELETE: api/Supermarket_Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupermarket_Product(int id)
        {
            var supermarket_Product = await _context.Supermarket_Products.FindAsync(id);
            if (supermarket_Product == null)
            {
                return NotFound();
            }

            _context.Supermarket_Products.Remove(supermarket_Product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Supermarket_ProductExists(int id)
        {
            return _context.Supermarket_Products.Any(e => e.Id == id);
        }
    }
}
