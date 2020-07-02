using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Competition.Entities
{
    public class Discipline : BaseEntity
    {
        public string DisciplineName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}