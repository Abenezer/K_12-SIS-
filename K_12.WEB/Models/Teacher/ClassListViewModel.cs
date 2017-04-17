using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K_12.WEB.Models.Teacher
{
    public class ClassListViewModel
    {

        public int section_id { get; set; }
        public int subject_id { get; set; }
        public string SectionName { get; set; }
        public string Subject { get; set; }
    }
}