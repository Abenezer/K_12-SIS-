using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_12.BLL
{
public class BLL
    {
        public static BussinessConfiguration Configuration { get; set; }

      

     static BLL()
        {
           
            Configuration = new BussinessConfiguration();
            Configuration.Initialize();
        }
    }
}
