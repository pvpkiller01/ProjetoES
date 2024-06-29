using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESProjeto.Shared.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Votes { get; set; }
        public int CompetitionId { get; set; }
        public List<CategoryMovie> MoviesId { get; set; }
    }
}
