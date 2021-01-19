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
    public class ImpactCategoriesController : ControllerBase
    {
        private readonly GreenDbContext _context;

        public ImpactCategoriesController(GreenDbContext context)
        {
            _context = context;
        }

        // GET: api/ImpactCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImpactCategory>>> GetImpactCategories()
        {
            return await _context.ImpactCategories.ToListAsync();
        }

        // GET: api/ImpactCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImpactCategory>> GetImpactCategory(int id)
        {
            var impactCategory = await _context.ImpactCategories.FindAsync(id);

            if (impactCategory == null)
            {
                return NotFound();
            }

            return impactCategory;
        }

        // PUT: api/ImpactCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImpactCategory(int id, ImpactCategory impactCategory)
        {
            if (id != impactCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(impactCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImpactCategoryExists(id))
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

        // POST: api/ImpactCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImpactCategory>> PostImpactCategory(ImpactCategory impactCategory)
        {
            _context.ImpactCategories.Add(impactCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImpactCategory", new { id = impactCategory.Id }, impactCategory);
        }

        // DELETE: api/ImpactCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImpactCategory(int id)
        {
            var impactCategory = await _context.ImpactCategories.FindAsync(id);
            if (impactCategory == null)
            {
                return NotFound();
            }

            _context.ImpactCategories.Remove(impactCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImpactCategoryExists(int id)
        {
            return _context.ImpactCategories.Any(e => e.Id == id);
        }
    }
}
