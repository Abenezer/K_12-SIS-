using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K_12.WEB.Models.Registration
{
    public class StudentListViewModel
    {
        public string ID { get { return section_id.ToString() + '_' + student_id.ToString(); } set { } }
        public int student_id { get; set; }
        public int section_id { get; set; }
        public string FullName { get; set; }
        public string PhotoPath { get; set; }
    }
}