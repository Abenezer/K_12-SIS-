using K_12.BLL.Service;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace K_12.WEB.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }


        protected readonly ITeacherService _service;
        private readonly IUnitOfWork _unitOfWork;

        public TeacherController(
            IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
            _service = new TeacherService(_unitOfWork.Teachers);
        }


        private Entity.Teacher CurrentTeacher
        {
            get
            {

                if (Session["current_teacher_profile"] == null)
                {

                    Session["current_teacher_profile"] = _unitOfWork.Teachers.GetByUserId(User.Identity.GetUserId());
                }
                return (Entity.Teacher)Session["current_teacher_profile"];


            }

        }

        public JsonResult GetClasses()
        {
            return Json(CurrentTeacher.Classes.Select(c => new Models.Teacher.ClassListViewModel
            {
                Subject = c.Subject.Name,
                subject_id = c.subject_id,
                SectionName = c.Section.Name,
                section_id = c.section_id,
            }), JsonRequestBehavior.AllowGet);
        }


        public ActionResult Classes(int section_id, int subject_id)
        {
            var cls = _unitOfWork.Classs.Find(section_id, subject_id); 
            return View(new Models.Teacher.ClassListViewModel { section_id=cls.section_id, subject_id = cls.subject_id, SectionName = cls.Section.Name, Subject=cls.Subject.Name}); 
        }

        public ActionResult Activities ()
        {
            
            return View();
        }


        public  ActionResult AddActivity (int section_id , int subject_id)
        {
            return View(new Entity.Activity
            {
                section_id = section_id, 
                subject_id = subject_id,
                
            }
            );
        }

       [HttpPost]
       public async Task<ActionResult> AddActivity (Entity.Activity activity)
        {
            if (ModelState.IsValid)
            {
                activity.Time_Given = DateTime.Today;
                _unitOfWork.Activitys.Add(activity);

                try
                {
                    await _unitOfWork.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Json("");
            }

            else return View();
        }

        

        public JsonResult getActivities (int section_id, int subject_id, [DataSourceRequest] DataSourceRequest request)
        {
           var res=  _unitOfWork.Classs.Find(section_id,subject_id).Activities.Select(
                a => new Models.Teacher.ActivityListViewModel
                {
                    ID = a.ID,
                    Title = a.Title,
                    date_time_given = a.Time_Given.Value,
                    Type = ""

                });


            return Json(res.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


    }
}