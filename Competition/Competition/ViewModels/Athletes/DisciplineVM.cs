using Competition.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Competition.ViewModels.Athletes
{
    public class DisciplineVM
    {
        public Athlete Athlete { get; set; }
        public List<AthleteToDiscipline> Shared { get; set; }
        public List<Discipline> Disciplines { get; set; }
    }
}