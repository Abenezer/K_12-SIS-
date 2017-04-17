using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace K_12.WEB.Models.Staff
{
    public class StaffClaimViewModel
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
        public string Email { get; set; }

        [Required]
        public string MobilePhone { get; set; }

        public string StaffType { get; set; }
    }
}