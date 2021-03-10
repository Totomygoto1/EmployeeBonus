using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendApplication.Models;

namespace BackendApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/Tutorials")]
    public class TutorialsController : Controller
    {
        private readonly TutorialContext _context;

        public TutorialsController(TutorialContext context)
        {
            _context = context;
        }

        // GET: api/Tutorials
        [HttpGet]
        public IEnumerable<Tutorial> GetTutorial()
        {
            return _context.Tutorial;
        }

        // GET: api/Tutorials/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTutorial([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tutorial = await _context.Tutorial.SingleOrDefaultAsync(m => m.id == id);

            if (tutorial == null)
            {
                return NotFound();
            }

            return Ok(tutorial);
        }

        // PUT: api/Tutorials/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTutorial([FromRoute] int id, [FromBody] Tutorial tutorial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tutorial.id)
            {
                return BadRequest();
            }

            _context.Entry(tutorial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorialExists(id))
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

        // POST: api/Tutorials
        [HttpPost]
        public async Task<IActionResult> PostTutorial([FromBody] Tutorial tutorial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tutorial.Add(tutorial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTutorial", new { id = tutorial.id }, tutorial);
        }

        // DELETE: api/Tutorials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTutorial([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tutorial = await _context.Tutorial.SingleOrDefaultAsync(m => m.id == id);
            if (tutorial == null)
            {
                return NotFound();
            }

            _context.Tutorial.Remove(tutorial);
            await _context.SaveChangesAsync();

            return Ok(tutorial);
        }

        private bool TutorialExists(int id)
        {
            return _context.Tutorial.Any(e => e.id == id);
        }
    }
}