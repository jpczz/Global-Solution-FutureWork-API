using FutureWork.API.Data;
using FutureWork.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FutureWork.API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v1/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly FutureWorkDbContext _context;

        public SkillsController(FutureWorkDbContext context)
        {
            _context = context;
        }

        // GET: api/v1/skills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skill>>> GetAll()
        {
            var skills = await _context.Skills.AsNoTracking().ToListAsync();
            return Ok(skills); // 200
        }

        // GET: api/v1/skills/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Skill>> GetById(int id)
        {
            var skill = await _context.Skills.FindAsync(id);

            if (skill == null)
                return NotFound(); // 404

            return Ok(skill); // 200
        }

        // POST: api/v1/skills
        [HttpPost]
        public async Task<ActionResult<Skill>> Create([FromBody] Skill skill)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // 400

            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = skill.Id }, skill); // 201
        }

        // PUT: api/v1/skills/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Skill skill)
        {
            if (id != skill.Id)
                return BadRequest("ID do body difere do ID da URL."); // 400

            var exists = await _context.Skills.AnyAsync(x => x.Id == id);
            if (!exists)
                return NotFound(); // 404

            _context.Entry(skill).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent(); // 204
        }

        // DELETE: api/v1/skills/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var skill = await _context.Skills.FindAsync(id);

            if (skill == null)
                return NotFound(); // 404

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();

            return NoContent(); // 204
        }
    }
}
