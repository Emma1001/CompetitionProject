using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Competition.Models
{
    public class Discipline
    {
        public int Id { get; set; }
        public string DisciplineName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}