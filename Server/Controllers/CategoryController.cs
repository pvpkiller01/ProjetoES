using ESProjeto.Server.Data;
using ESProjeto.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ESProjeto.Server.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext applicationDbContext) 
        {
            _context = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet("/movies")]
        public async Task<ActionResult<List<CategoryMovie>>> GetAllMovies()
        {
            var categoriesMovie = await _context.CategoriesMovie.ToListAsync();
            return Ok(categoriesMovie);
        }

        [HttpGet("{id}/categories")]
        public async Task<ActionResult<List<Category>>> GetSingleCategory(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(h => h.Id == id);
            return Ok(category);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<CategoryMovie>>> GetMoviesFromCategory(int id) 
        {
            var movies = await _context.CategoriesMovie
                .Where(x => x.Category.Id == id)
                .ToListAsync();
          
            if (movies == null)
            {
                return NotFound("No movies");
            }

            return Ok(movies);
        }

		[HttpPost]
		public async Task<ActionResult<Competition>> CreateCategories(Category category)
		{
			_context.Categories.Add(category);
			
			await _context.SaveChangesAsync();
			var newCompetition = await _context.Competitions.ToListAsync();
			return Ok(newCompetition);
		}

        [HttpPost("{id}")]
        public async Task<ActionResult<Category>> UpdateCategory(Category category)
        {
            try
            {
                var dbCategory = await _context.Categories.FirstOrDefaultAsync(h => h.Id == category.Id);

                if (dbCategory == null)
                {
                    return NotFound("There is no competition with that id.");
                }

                dbCategory.Name = category.Name;

                await _context.SaveChangesAsync();
                return dbCategory;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        [HttpPost("{MovieReference}/votes")]
        public async Task<ActionResult<CategoryMovie>> UpdateMovieVotes(int MovieReference, [FromBody]int categoryId)
        {
            var subject = await _context.CategoriesMovie.FirstOrDefaultAsync(x => x.MovieReference == MovieReference && x.Category.Id == categoryId);

            if (subject == null)
            {
                return NotFound();
            }
            subject.Votes ++;

            await _context.SaveChangesAsync();
            // Process the found subject

            return subject;
        }
        [HttpPost("{id}/CategoryVotes")]
        public async Task<ActionResult<Category>> UpdateAllVotes(Category category)
        {
            try { 
                var dbCategory = await _context.Categories.FirstOrDefaultAsync(x => x.Id == category.Id); ;

                if (dbCategory == null)
                {
                    return NotFound();
                }
                dbCategory.Votes = category.Votes;
                dbCategory.MoviesId = category.MoviesId;
                dbCategory.Name = category.Name;
                await _context.SaveChangesAsync();

                return dbCategory;
            }catch (Exception) {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
                }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCompetition(int id)
        {
            var dbCategory = await _context.Categories.FirstOrDefaultAsync(h => h.Id == id);
            if (dbCategory == null)
            {
                return NotFound("There is no category with that id.");
            }
            _context.Categories.Remove(dbCategory);
            await _context.SaveChangesAsync();

            return Ok(await _context.Categories.ToListAsync());
        }

    }
}
