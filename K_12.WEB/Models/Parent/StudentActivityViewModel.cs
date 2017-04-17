using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K_12.WEB.Models.Parent
{
    public class StudentActivityViewModel: Teacher.ActivityListViewModel
    {
        public  int subject_id { get; set; }
        public string Subject { get; set; }
    }
}