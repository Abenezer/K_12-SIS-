using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K_12.WEB.Models.Admin
{
    public class ApplicationListViewModel
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }

        public string Grade { get; set;  }

        public string Status { get; set; }

        public DateTime AppDate { 
           get;set;
        }

        public string AppDateString
        {
            get
            {

                return AppDate.ToLongDateString();
            }
        }

        public int Age
        {
            get
            {
                return DateTime.Today.Year - DOB.Year;
            }
        }

        public string FullName
        {
            get
            {
                return FName + " " + MName;
            }
        }
    }
}