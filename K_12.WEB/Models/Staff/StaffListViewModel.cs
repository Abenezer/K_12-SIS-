﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K_12.WEB.Models.Staff
{
    public class StaffListViewModel
    {
        public int ID{ get; set; }
        public string FullName {get;set;}

        public DateTime ClaimDate { get; set; }

        public string StaffType { get; set; }
    }
}