using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
using System.ComponentModel.DataAnnotations;

namespace MovieWebApp.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }
}