using ESProjeto.Server.Data;
using ESProjeto.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ESProjeto.Server.Controllers
{
    [Route("api/categoryMovie")]
    [ApiController]
    public class CategoryMovieController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public CategoryMovieController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryMovie>>> GetAllMovies()
        {
            var categoriesMovie = await _context.CategoriesMovie.ToListAsync();
            return Ok(categoriesMovie);
        }
    }
}
