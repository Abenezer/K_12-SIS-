using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace K_12.WEB.Models
{
    public class GradeViewModel
    {
        [Required]
        public int? ID { get; set; }
        public string Grade { get; set; }

    }
}