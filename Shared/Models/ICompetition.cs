using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESProjeto.Shared.Models
{
	internal interface ICompetition
	{
		public string Name { get; set; }
		public int Id { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string State { get; set; }
		List<Category> Categories { get; set; }
	}
}
