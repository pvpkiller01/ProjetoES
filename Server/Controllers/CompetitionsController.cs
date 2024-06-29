using Blazorise;
using ESProjeto.Server.Data;
using ESProjeto.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ESProjeto.Server.Controllers
{
    [Route("api/competitions")]
    [ApiController]
    public class CompetitionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CompetitionsController(ApplicationDbContext applicationDbContext) 
        {
            _context = applicationDbContext;
        } 
        [HttpGet]
        public async Task<ActionResult<List<Competition>>> GetCompetitions()
        {
			var competitions = await _context.Competitions
                .ToListAsync();
			return Ok(competitions);
        }

		[HttpGet("{id}")]
        public async Task<ActionResult<Competition>> GetByID(int id)
        {
            var comp = await _context.Competitions.FirstOrDefaultAsync(h => h.Id == id);

            if (comp != null)
				return Ok(comp);

			return NotFound("Competition not found");

		}

        [HttpPost]
        public async Task<ActionResult<Competition>> CreateCompetition(Competition competition)
        {
			_context.Competitions.Add(competition);
            await _context.SaveChangesAsync();
            var newCompetition = await _context.Competitions.ToListAsync();
			return Ok(newCompetition);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Competition>> UpdateCompetition(Competition competition)
        {
            try {
                var dbCompetition = await _context.Competitions.FirstOrDefaultAsync(h => h.Id == competition.Id);

                if (dbCompetition == null)
                {
                    return NotFound("There is no competition with that id.");
                }

                dbCompetition.Name = competition.Name;
                dbCompetition.StartDate = competition.StartDate;
                dbCompetition.EndDate = competition.EndDate;
                dbCompetition.State = competition.State;
                await _context.SaveChangesAsync();
                return dbCompetition;
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Competition>> DeleteCompetition(int id)
        {
            var dbCompetition = await _context.Competitions.FirstOrDefaultAsync(h => h.Id == id);
            if (dbCompetition == null)
            {
                return NotFound("There is no competition with that id.");
            }
            _context.Competitions.Remove(dbCompetition);
            await _context.SaveChangesAsync();

            return Ok(await _context.Competitions.ToListAsync());
        }
    }
}
