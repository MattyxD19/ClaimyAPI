using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Application_for_Claimy.Models
{
    public class AuthenticateModel
    {
        [Required]
        public string fld_Email { get; set; }
        [Required]
        public string fld_Password { get; set; }
    }
}