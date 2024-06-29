using ESProjeto.Shared.Models;
using System.Text.Json;

namespace ESProjeto.Client.Services.CategoryServices
{
    public interface ICategoryService
    {
        List<Category> Categories { get; set; }
        List<CategoryMovie> MoviesReference { get; set; }
        Task GetCategories();
        Task GetAllMovies();
        Task<Category> GetSingleCategory(int id);
        Task<List<CategoryMovie>> GetMoviesFromCategories(int id);
        Task VoteOnCategory(int categoryId, int MovieReference);
        Task UpdateAllVotes(Category category);
        Task UpdateCategory(Category category);
        Task CreateCategory(Category category);
        Task DeleteCategory(int id);

    }
}
