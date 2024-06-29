using ESProjeto.Shared.Models;  

namespace ESProjeto.Client.Services.MovieServices
{
    public interface IMovieService
    {
        List<Movie> MovieList { get; set; }    
		Task<Movie> GetMovieAsync(int id);
		Task<int> GetMovieIdAsync(int id);
    }
}
