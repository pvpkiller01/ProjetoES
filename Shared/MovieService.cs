using ESProjeto;
using ESProjeto.Client;
using System.Net.Http.Json;
using System.Text.Json;

namespace ESProjeto
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _httpClient;

        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> GetMovieIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"https://api.themoviedb.org/3/movie/{id}?api_key=d1b13f196dd66ad0bd2e69e7eb503b06");
            response.EnsureSuccessStatusCode();
            var movie = await response.Content.ReadFromJsonAsync<Movie>();
            return movie.Id;
        }
    }

}