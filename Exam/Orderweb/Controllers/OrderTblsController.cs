using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orderweb.Data;
using Orderweb.Model;

namespace Orderweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderTblsController : ControllerBase
    {
        private readonly OrderwebContext _context;

        public OrderTblsController(OrderwebContext context)
        {
            _context = context;
        }

        // GET: api/OrderTbls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderTbl>>> GetOrderTbl()
        {
          if (_context.OrderTbl == null)
          {
              return NotFound();
          }
            return await _context.OrderTbl.ToListAsync();
        }

        // GET: api/OrderTbls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderTbl>> GetOrderTbl(int id)
        {
          if (_context.OrderTbl == null)
          {
              return NotFound();
          }
            var orderTbl = await _context.OrderTbl.FindAsync(id);

            if (orderTbl == null)
            {
                return NotFound();
            }

            return orderTbl;
        }

        // PUT: api/OrderTbls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderTbl(int id, OrderTbl orderTbl)
        {
            if (id != orderTbl.ItemCode)
            {
                return BadRequest();
            }

            _context.Entry(orderTbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderTblExists(id))
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

        // POST: api/OrderTbls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderTbl>> PostOrderTbl(OrderTbl orderTbl)
        {
          if (_context.OrderTbl == null)
          {
              return Problem("Entity set 'OrderwebContext.OrderTbl'  is null.");
          }
            _context.OrderTbl.Add(orderTbl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderTbl", new { id = orderTbl.ItemCode }, orderTbl);
        }

        // DELETE: api/OrderTbls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderTbl(int id)
        {
            if (_context.OrderTbl == null)
            {
                return NotFound();
            }
            var orderTbl = await _context.OrderTbl.FindAsync(id);
            if (orderTbl == null)
            {
                return NotFound();
            }

            _context.OrderTbl.Remove(orderTbl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderTblExists(int id)
        {
            return (_context.OrderTbl?.Any(e => e.ItemCode == id)).GetValueOrDefault();
        }
    }
}
