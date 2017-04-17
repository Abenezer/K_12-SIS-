using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K_12.WEB.Models.Admin
{
    public class SubjectListViewModel
    {
        public string ID { get { return subject_id.ToString() + '_' + grade_id.ToString(); } }

        public int? subject_id { get; set; }
        public int? grade_id { get; set; }

        public string Name { get; set; }
    }
}