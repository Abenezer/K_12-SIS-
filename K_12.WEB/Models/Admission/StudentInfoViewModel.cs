using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace K_12.WEB.Models.Admission
{
    public class StudentInfoViewModel
    {
        [Required]
        public string FName { get; set; }

        [Required]
        public string MName { get; set; }

        [Required]
        public string LName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public Nullable<DateTime> DOB { get; set; }

        public string POB_City { get; set; }
        public string POB_Country { get; set; }

        public string Nationality { get; set; }


    }
}