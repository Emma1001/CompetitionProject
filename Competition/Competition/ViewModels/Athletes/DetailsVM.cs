using Competition.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Competition.ViewModels.Athletes
{
    public class DetailsVM
    {
        public Athlete Athlete { get; set; }
        public Team Team { get; set; }
        public List<AthleteToDiscipline> DisciplinesList { get; set; }
    }
}