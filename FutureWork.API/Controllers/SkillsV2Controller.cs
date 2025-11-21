using FutureWork.API.Data;
using FutureWork.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FutureWork.API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/v2/skills")]
    public class SkillsV2Controller : ControllerBase
    {
        private readonly FutureWorkDbContext _context;

        public SkillsV2Controller(FutureWorkDbContext context)
        {
            _context = context;
        }

        // GET: api/v2/skills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillResponseV2>>> GetAll()
        {
            var skills = await _context.Skills.AsNoTracking()
                .Select(s => new SkillResponseV2
                {
                    Id = s.Id,
                    Name = s.Name,
                    Category = s.Category,
                    Description = s.Description,
                    IsFutureCritical = s.IsFutureCritical
                })
                .ToListAsync();

            return Ok(skills); // 200
        }

        // GET: api/v2/skills/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<SkillResponseV2>> GetById(int id)
        {
            var skill = await _context.Skills.AsNoTracking()
                .Where(s => s.Id == id)
                .Select(s => new SkillResponseV2
                {
                    Id = s.Id,
                    Name = s.Name,
                    Category = s.Category,
                    Description = s.Description,
                    IsFutureCritical = s.IsFutureCritical
                })
                .FirstOrDefaultAsync();

            if (skill == null)
                return NotFound(); // 404

            return Ok(skill); // 200
        }
    }
}
