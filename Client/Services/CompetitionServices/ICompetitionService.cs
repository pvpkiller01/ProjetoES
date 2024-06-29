using ESProjeto.Shared.Models;
namespace ESProjeto.Client.Services.CompetitionServices
{
    public interface ICompetitionService
    {
        List<Competition> Competitions { get; set; }
		Task GetCompetitions();
        Task<Competition> GetSingleCompetition(int id);
		Task CreateCompetition(Competition competition);
        Task DeleteCompetition(int id);
        Task UpdateCompetition(Competition competition);


	}
}
