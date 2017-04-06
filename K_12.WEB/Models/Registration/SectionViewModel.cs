using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K_12.WEB.Models.Registration
{
    public class SectionViewModel
    {
        public SectionViewModel()
        {
            Students = new HashSet<StudentListViewModel>();
        }

        public string Name { get; set; }
        public int ID { get; set; }
        public ICollection<StudentListViewModel> Students { get; set; }
    }
}