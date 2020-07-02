using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Competition.Entities
{
    public class AthleteToDiscipline
    {
        [Key]
        public int Id { get; set; }
        public int AthleteId { get; set; }
        public int DisciplineId { get; set; }

        [ForeignKey("AthleteId")]
        public virtual Athlete Athlete { get; set; }

        [ForeignKey("DisciplineId")]
        public virtual Discipline Discipline { get; set; }
    }
}