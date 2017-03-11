using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K_12.WEB.Models
{
    public class FileUploadViewModel
    {
        public HttpPostedFileBase file { get; set; }
        public String FileName { get; set; }
        public String Extention { get; set; }

        public long Size { get; set; }
        public String Type { get; set; }

    }
}