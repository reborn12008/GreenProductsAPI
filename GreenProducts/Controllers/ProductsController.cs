using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GreenProducts.Data;
using GreenProducts.Models;
using Microsoft.AspNetCore.Authorization;

namespace GreenProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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

        // GET: api/Products/producthints/{supermarket}/{search_string}
        [HttpGet("producthints/{supermarket}/{search_string}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(string search_string, string supermarket)
        {
            Supermarket currentSupermarket = await _context.Supermarkets.Where(s=> s.Name == supermarket ).FirstAsync();
            List<Product> matching_products = await _context.Products.Where(p => p.Name.Contains(search_string)).ToListAsync();
            List<Product> matching_products_result = new List<Product>();
            foreach (Product product in matching_products)
            {
                List<Supermarket_Product> sp_p = await _context.Supermarket_Products.Where(sp => sp.ProductId == product.Id).Where(sp => sp.SupermarketId == currentSupermarket.Id).ToListAsync();
                if (sp_p.Count()> 0)
                {
                    matching_products_result.Add(product);
                }
            }
            return matching_products;
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
        [HttpGet("{supermarket}/{product}/makegreen")]
        public async Task<ActionResult<List<Product>>> GetGreenProduct(String product, String supermarket)
        {
            List<Product> get_product = await _context.Products.Where(p=> p.Name == product).ToListAsync(); // Produto passado no url
            var current_product = get_product[0];
            var currentSupermarket = _context.Supermarkets.Where(s => s.Name.ToUpper() == supermarket.ToUpper()); // Supermercado escolhido na opção

            if (current_product == null)
            {
                return NotFound();
            }
            
            var product_impactId = current_product.ImpactId;
            var product_impact = await _context.ImpactCategories.FindAsync(product_impactId); // Impacto do produto em questão
            
            var product_type = current_product.CategoryId;
            List<Product> similarProducts = await _context.Products.Where(sp => sp.CategoryId == product_type).ToListAsync(); // Produtos do mesmo género
            List<Product> betterProducts = new List<Product>();
            betterProducts.Add(current_product);
            
            foreach (Product similarProduct in similarProducts)
            {
                if (similarProduct.Id != current_product.Id)
                {
                    ImpactCategory similarProductImpact = await _context.ImpactCategories.FindAsync(similarProduct.ImpactId);

                    if(similarProductImpact.SeverityLevel < product_impact.SeverityLevel)
                    {
                        betterProducts.Add(similarProduct);
                    }
                }
            }
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

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
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
