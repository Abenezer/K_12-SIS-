using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K_12.WEB.Models.Admission
{
    public class SuccessAdmissionViewModel
    {
      

        public string StudentFullName { get; set; }
        public string ParentFullName { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }

        public string Relation { get; set; }
    }
}