using ESProjeto.Client.Services.CrewMemberServices;

using System.Collections.Generic;
using System.Threading.Tasks;
using ESProjeto.Client.Models;


namespace ESProjeto.Client.Services.CrewMemberServices
{
    public interface ICrewMemberService
    {
        Task<CrewMember> GetCrewMemberByIdAsync(int id);

        Task<List<CrewMember>> GetCrewMembersByMovieIdAsync(int movieId);
    }
    
    

}



