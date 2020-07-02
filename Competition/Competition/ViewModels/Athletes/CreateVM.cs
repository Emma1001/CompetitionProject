using Competition.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Competition.ViewModels.Athletes
{
    public class CreateVM
    {
        [DisplayName("Name: ")]
        [Required(ErrorMessage = "This field is required!")]
        public string Name { get; set; }

        //[DisplayName("Country: ")]
        //[Required(ErrorMessage = "This field is required!")]
        //public string Country { get; set; }

    }
}