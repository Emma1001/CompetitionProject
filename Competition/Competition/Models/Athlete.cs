using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Competition.Models
{
    public class Athlete 
    {
        public int AthleteId { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public int DisciplineId { get; set; }
    }
}