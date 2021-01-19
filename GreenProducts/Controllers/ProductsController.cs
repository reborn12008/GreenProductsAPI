using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GreenProducts.Data;
using GreenProducts.Models;
using System.Net.Http;
using System.Net;

namespace GreenProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly GreenDbContext _context;

        public ProductsController(GreenDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // GET: api/Products/makegreen/1
        
        [HttpGet("{supermarket}/{id}/makegreen")]
        public async Task<ActionResult<List<Product>>> GetGreenProduct(int id, String supermarket)
        {
            var product = await _context.Products.FindAsync(id); // Produto passado no url

            var currentSupermarket = _context.Supermarkets.Where(s => s.Name.ToUpper() == supermarket.ToUpper()); // Supermercado escolhido na opção

            if (product == null)
            {
                return NotFound();
            }
            
            var product_impactId = product.ImpactId;
            var product_impact = await _context.ImpactCategories.FindAsync(product_impactId); // Impacto do produto em questão
            
            var product_type = product.CategoryId;
            var similarProducts = _context.Products.Where(sp => sp.CategoryId == product_type); // Produtos do mesmo género
            
            System.Diagnostics.Debug.WriteLine(supermarket);
            List<Product> betterProducts = new List<Product>();
            
            foreach (Product similarProduct in similarProducts)
            {
                var pId = similarProduct.Id;
                if (pId != id)
                {
                    var currentProduct = await _context.Products.FindAsync(pId);
                    int currentProductImpactId = (int) currentProduct.ImpactId;
                    var currentProductImpact = await _context.ImpactCategories.FindAsync(currentProductImpactId);

                    if(currentProductImpact.SeverityLevel < product_impact.SeverityLevel)
                    {
                        betterProducts.Add(currentProduct);
                    }
                }
            }
            // replace-----> betterProducts[0] = betterProducts[1];
            return betterProducts;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
