using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_12.BLL
{
   public class BussinessConfiguration : Westwind.Utilities.Configuration.AppConfiguration
    {
        public BussinessConfiguration()
        {
            AdmisssionMethod = Constants.AdmissionMethods.MANUAL;
            
        }

        // Create properties for values to read or persist to/from the config store
        public string AdmisssionMethod { get; set; }

        


    }
}
