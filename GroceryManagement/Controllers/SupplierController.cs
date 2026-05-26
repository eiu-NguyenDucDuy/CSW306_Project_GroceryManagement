using GroceryManagement.Data;
using GroceryManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroceryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : Controller
    {
        private readonly AppDbContext _context;

        public SupplierController(AppDbContext context)
        {
            _context = context;
        }

        // READ: api/supplier
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetAll()
        {
            return await _context.Suppliers.ToListAsync();
        }

        // READ: api/supplier/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetById(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return supplier;
        }

        // CREATE: api/supplier
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Supplier>> Create(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById),
                new { id = supplier.Id }, supplier);
        }

        // UPDATE: api/supplier/1
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Supplier supplier)
        {
            if (id != supplier.Id)
            {
                return BadRequest();
            }

            var exisiting = await _context.Suppliers.FindAsync(id);

            if (exisiting == null)
            {
                return NotFound();
            }

            exisiting.Name = supplier.Name;
            exisiting.Phone = supplier.Phone;
            exisiting.Address = supplier.Address;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/supplier/1
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            _context.Suppliers.Remove(supplier);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
