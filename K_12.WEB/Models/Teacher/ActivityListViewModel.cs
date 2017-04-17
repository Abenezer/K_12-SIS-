using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K_12.WEB.Models.Teacher
{
    public class ActivityListViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public DateTime date_time_given       {            get; set;        }

        public string Time_given { get {
                return date_time_given.ToShortTimeString();
            } }
        public string Date_given { get {
                return  date_time_given.ToShortDateString();
            } }
        public string Type { get; set; }
      
    }

}