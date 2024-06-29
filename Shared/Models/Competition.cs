using ESProjeto.Shared;
using ESProjeto.Shared.Patterns;
using System;

namespace ESProjeto.Shared.Models
{
    public class Competition : ICompetition
	{
        public string Name { get; set; }
        public  int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string State { get; set; }
        public List<Category> Categories { get; set; }
    }
}