using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace K_12.WEB.Models
{
    public class ApplicantBasicViewModel 
    {
        [Required]
        public string FName { get; set; }
    
        [Required]
        public string MName { get; set; }


        public string LName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public Nullable<DateTime> DOB { get; set; }

        [Required]
        public string Contact_FName { get; set; }
        [Required]
        public string Contact_MName { get; set; }

        public string Contact_Email { get; set; }

        [Required]
        public string Contact_MobilePhone { get; set; }
        public string Contact_OfficePhone { get; set; }
    }
}