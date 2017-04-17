using Kendo.Mvc.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K_12.WEB.Models.Profile
{
    public class SideMenuViewModel
    {
        public IEnumerable<MenuItem> MainListItems { get; set; }

        public  string  MainListText { get; set; }

    }
}