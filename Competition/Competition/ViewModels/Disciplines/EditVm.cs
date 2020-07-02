using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Competition.ViewModels.Disciplines
{
    public class EditVM
    {
        public int Id { get; set; }

        [DisplayName("Name: ")]
        [Required(ErrorMessage = "This field is required!")]
        public string DisciplineName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy hh:mm}")]
        [Display(Name = "Start")]
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy hh:mm}")]
        [Display(Name = "End")]
        [DataType(DataType.Date)]
        public DateTime End { get; set; }
    }
}