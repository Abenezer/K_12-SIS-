using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K_12.WEB.Controllers
{
    public class UploadController : Controller
    {


        private ICollection<HttpPostedFileBase> GetDocuments()
        {
            if (Session["applicantDocuments"] == null)
            {
                ICollection<HttpPostedFileBase> applicantDocuments = new HashSet<HttpPostedFileBase>();


                Session["applicantDocuments"] = applicantDocuments;
            }
            return (ICollection<HttpPostedFileBase>) Session["applicantDocuments"];
        }




        public ActionResult SaveFile(IEnumerable<HttpPostedFileBase> files)
        {
            // The Name of the Upload component is "files"

            ICollection<HttpPostedFileBase> applicantDocuments = GetDocuments(); 
            if (files != null)
            {


                foreach (var file in files)
                {
                    applicantDocuments.Add(file);
                    //// Some browsers send file names with full path.
                    //// We are only interested in the file name.
                    //var fileName = Path.GetFileName(file.FileName);
                    //var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

                    //// The files are not actually saved in this demo
                    //file.SaveAs(physicalPath);
                }
            }

            // Return an empty string to signify success
            return Content("");
        }

        public ActionResult RemoveFile(string[] fileNames)
        {
            // The parameter of the Remove action must be called "fileNames"

            if (fileNames != null)
            {
                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);
                    var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

                    // TODO: Verify user permissions

                    if (System.IO.File.Exists(physicalPath))
                    {
                        // The files are not actually removed in this demo
                         System.IO.File.Delete(physicalPath);
                    }
                }
            }

            // Return an empty string to signify success
            return Content("");
        }










    }
}