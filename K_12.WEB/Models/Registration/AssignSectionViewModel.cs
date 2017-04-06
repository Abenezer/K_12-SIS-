using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K_12.WEB.Models.Registration
{
    public class AssignSectionViewModel
    {

        private IList<string> _studentList = new List<string>(); 

        public AssignSectionViewModel()
        {

            _studentList.Add("Abebbe");
            _studentList.Add("kebede");
        }
        public IList<string> studentList
        {
            get
            {
                return _studentList;
            }
        }
    }
}