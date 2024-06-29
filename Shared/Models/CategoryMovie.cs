using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESProjeto.Shared.Models
{
    public class CategoryMovie
    {
        public int Id { get; set; }
        public int  MovieReference { get; set; }
        public int Votes { get; set; }
        public Category Category { get; set; }
    }
}
