using ESProjeto.Client;


using System.Net.Http.Json;
using ESProjeto.Client.Models;

using ESProjeto.Client.Services.CrewMemberServices;


namespace ESProjeto.Client.Services.CrewMemberServices
{
    public class CrewMemberService : ICrewMemberService
    {
        private readonly HttpClient _httpClient;

        public CrewMemberService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CrewMember> GetCrewMemberByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"https://api.themoviedb.org/3/person/{id}?api_key=d1b13f196dd66ad0bd2e69e7eb503b06");
            response.EnsureSuccessStatusCode();
            var crewMember = await response.Content.ReadFromJsonAsync<CrewMember>();
            return crewMember;
        }

        public async Task<List<CrewMember>> GetCrewMembersByMovieIdAsync(int movieId)
        {
            var response = await _httpClient.GetAsync($"https://api.themoviedb.org/3/movie/{movieId}/credits?api_key=d1b13f196dd66ad0bd2e69e7eb503b06");
            response.EnsureSuccessStatusCode();
            var credits = await response.Content.ReadFromJsonAsync<Credits>();

            return credits?.Crew;
        }

    }
}
