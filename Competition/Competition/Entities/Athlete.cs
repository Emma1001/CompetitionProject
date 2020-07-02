using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Competition.Entities
{
    public class Athlete : BaseEntity
    {
        public string Name { get; set; }
        public int TeamId { get; set; }
        public string Discipline { get; set; }


        [ForeignKey("TeamId")]
        public Team Team { get; set; }
    }
}