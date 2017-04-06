using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace K_12.WEB.Models.Registration
{
    public class ApplyViewModel
    {
        
        public  GradeViewModel Grade { get; set; }
        [Required]
        public int Student_ID { get; set; }
        [Required]
        public int Reg_Year { get; set; }

        public int[] AvailableYears { get
            {
                int currentYear = DateTime.Today.Year;

                return new[] { currentYear,currentYear+1,currentYear+2}; 

            } }
    }
}