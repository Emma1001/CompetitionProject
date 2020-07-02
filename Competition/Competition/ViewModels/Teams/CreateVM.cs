using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Competition.ViewModels.Teams
{
    public class CreateVM
    {
        [DisplayName("Country: ")]
        [Required(ErrorMessage = "This field is required!")]
        public string Country { get; set; }
    }
}