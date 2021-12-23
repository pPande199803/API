using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly Dbcontext _context;

        public EmployeesController(Dbcontext context)
        {
            _context = context;
        }

        // GET: api/AllRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllRecords()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/AllRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetAllRecord(int id)
        {
            var allRecord = await _context.Employees.FindAsync(id);

            if (allRecord == null)
            {
                return NotFound();
            }

            return allRecord;
        }

        // PUT: api/AllRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllRecord(int id, Employee allRecord)
        {
            if (id != allRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(allRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllRecordExists(id))
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

        // POST: api/AllRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostAllRecord(Employee allRecord)
        {
            _context.Employees.Add(allRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllRecord", new { id = allRecord.Id }, allRecord);
        }

        // DELETE: api/AllRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllRecord(int id)
        {
            var allRecord = await _context.Employees.FindAsync(id);
            if (allRecord == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(allRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AllRecordExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
