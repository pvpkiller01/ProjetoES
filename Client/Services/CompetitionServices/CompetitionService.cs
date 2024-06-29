using ESProjeto.Shared.Models;
using System.Net.Http.Json;


namespace ESProjeto.Client.Services.CompetitionServices
{
    public class CompetitionService : ICompetitionService
    {
        private readonly HttpClient _httpClient;
        public CompetitionService (HttpClient httpClient) {
            _httpClient = httpClient;
        }
        public List<Competition> Competitions { get ; set; }

        public async Task<Competition> GetSingleCompetition(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Competition>($"api/competitions/{id}");
			if (result != null)
                return result;
            throw new Exception("Competition not found.");
        }

        public async Task GetCompetitions()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Competition>>("api/competitions");
            if(result != null)
                Competitions  = result; 
        }

		public async Task CreateCompetition(Competition competition)
		{
			var result = await _httpClient.PostAsJsonAsync("api/competitions", competition);
            result.EnsureSuccessStatusCode();
		}

		public async  Task DeleteCompetition(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/competitions/{id}");
            var response = await result.Content.ReadFromJsonAsync<List<Competition>>();

            if (response != null)
                Competitions = response;
        }

        public async Task UpdateCompetition(Competition competition)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/competitions/{competition.Id}", competition);
            result.EnsureSuccessStatusCode();

        }
        public async Task GetCompetitionTotalVotes(Competition competition)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/competitions/{competition.Id}/votes", competition);
            result.EnsureSuccessStatusCode();
        }
    }
}
