using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Competition.ViewModels.Athletes
{
    public class EditVM
    {
        public int Id { get; set; }

        [DisplayName("Name: ")]
        [Required(ErrorMessage = "This field is required!")]
        public string Name { get; set; }

        //[DisplayName("Country: ")]
        //[Required(ErrorMessage = "This field is required!")]
        //public string Country { get; set; }
    }
}