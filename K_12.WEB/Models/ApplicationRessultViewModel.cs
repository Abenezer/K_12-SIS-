using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K_12.WEB.Models
{
    public class ApplicationRessultViewModel
    {
        public bool AppFound { get; set; } = false; 
        public string AppStatus { get; set; }
        
        public int AppID { get ; set;  }
    }
}