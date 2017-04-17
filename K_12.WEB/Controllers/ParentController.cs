using K_12.BLL.Service;
using K_12.Entity;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K_12.WEB.Controllers
{
    public class ParentController : Controller
    {



        protected readonly IParentService _service;
        private readonly IUnitOfWork _unitOfWork;

        public ParentController(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _service = new ParentService(_unitOfWork.Parents);
        }



        // GET: Parent
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Student(int ID)
        {

            var student = _unitOfWork.Students.Find(ID);
            return View(new Models.Parent.StudentViewModel {
                FullName = student.GetFullName(),
                ID = student.ID,
                section_id = student.student_section.section_id.Value,
                

            });
        }


       public ActionResult StudentActivities()
        {
          
            return View();
        }


        public JsonResult GetStudentActivities (int section_id, [DataSourceRequest] DataSourceRequest request)
        {
            IQueryable<Models.Parent.StudentActivityViewModel> res = _unitOfWork.Activitys.Queryable().Where(a=>a.section_id==section_id).Select(
               a => new Models.Parent.StudentActivityViewModel
               {
                   ID = a.ID,
                   Title = a.Title,
                   date_time_given = a.Time_Given.Value,
                   Type = "",
                   subject_id = a.subject_id.Value,
                   Subject = a.Class.Subject.Name,

                   

               });


            return Json(res.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        private Entity.Parent CurrentParent
        {
            get
            {

                if (Session["current_parent_profile"] == null)
                {

                    Session["current_parent_profile"] = _unitOfWork.Parents.GetByUserId(User.Identity.GetUserId());
                }
                return (Entity.Parent)Session["current_parent_profile"];


            }

        }

    }
}