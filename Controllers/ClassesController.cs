using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public ClassesController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/classes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetClasses()
        {
            return await _context.Classes.ToListAsync();
        }

        // GET: api/classes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> GetClass(int id)
        {
            var classObj = await _context.Classes.FindAsync(id);

            if (classObj == null)
            {
                return NotFound();
            }

            return classObj;
        }

        // POST: api/classes
        [HttpPost]
        public async Task<ActionResult<Class>> PostClass(Class classObj)
        {
            _context.Classes.Add(classObj);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClass), new { id = classObj.ClassID }, classObj);
        }

        // PUT: api/classes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClass(int id, Class classObj)
        {
            if (id != classObj.ClassID)
            {
                return BadRequest();
            }

            _context.Entry(classObj).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassExists(id))
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

        // DELETE: api/classes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var classObj = await _context.Classes.FindAsync(id);
            if (classObj == null)
            {
                return NotFound();
            }

            _context.Classes.Remove(classObj);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassExists(int id)
        {
            return _context.Classes.Any(e => e.ClassID == id);
        }
    }
}
