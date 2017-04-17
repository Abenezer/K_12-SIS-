using K_12.BLL.Service;
using K_12.Entity;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace K_12.WEB.Controllers
{
    public class RegistrationController : Controller
    {

        protected readonly IRegistrationService _service;
        private readonly IUnitOfWork _unitOfWork;

        public RegistrationController(
            IUnitOfWork unitOfWork,
            IRegistrationService service)
        {
            _unitOfWork = unitOfWork;
            _service = service;
        }




        // GET: Registration
        public ActionResult Index()
        {
            Session.Clear();
            return View();
        }


        public ActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Apply(Models.Registration.ApplyViewModel applyViewModel)
        {

            if (ModelState.IsValid)
            {
                Entity.Registration reg = new Entity.Registration();
                reg.reg_date = DateTime.Today;
                reg.reg_status = BLL.Constants.RegistrationStatus.PENDING;
                reg.Year = applyViewModel.Reg_Year;
                reg.student_id = applyViewModel.Student_ID;
                reg.grade_id = applyViewModel.Grade.ID;

                _service.Insert(reg);
                try
                {
                    await _unitOfWork.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return View("RegistrationApplied");
            }


            return View();
        }


        public ActionResult AssignSection()
        {
            return View(new Models.Registration.AssignSectionViewModel());
        }

        public ActionResult GetUnassignedStudents(int? grade ,[DataSourceRequest] DataSourceRequest request)
        {
            if (grade != null)
            {
                var json = JsonConvert.SerializeObject(_service.GetRegisteredStudents(grade.Value).Where(s => s.student_section == null).Select(sel => new Models.Registration.StudentListViewModel
                {
                   
                    ID = sel.LName,
                    student_id = sel.ID,
                    
                    FullName = sel.FName + " " + sel.MName
                    //TO-DO PhotoPath =


                }).ToDataSourceResult(request), Formatting.Indented,
                                  new JsonSerializerSettings
                                  {
                                      ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                  });

                return Content(json, "application/json");
            }

            return Content("");
        }


        private ICollection<int> RemovedStudents
        {
            get
            {
                if(Session["Removed_students"]==null)

                {
                    Session["Removed_students"] = new HashSet<int>();
                }

                return (ICollection<int>)Session["Removed_students"];

            }
        }


        private ICollection<Models.Registration.SectionViewModel> GetCurrentSections(int? selected_grade) 
            {
                if (Session["Current_sections"]==null)
                    {

                ICollection<Models.Registration.SectionViewModel> x = _unitOfWork.Sections.Queryable().Where(s => s.grade_id == selected_grade).Select(s => new Models.Registration.SectionViewModel()
                {
                    ID = s.ID,
                    Name = s.Name,
                    Students = s.student_section.Select(std => new Models.Registration.StudentListViewModel() {
                        student_id= std.Student.ID,
                        section_id= s.ID,
                        FullName = std.Student.FName + " " + std.Student.MName,
                        //  PhotoPath =  
                    }).ToList()
                    
                    

                }).ToList();

                Session["Current_sections"] = x; 




                }

            return (ICollection<Models.Registration.SectionViewModel>)Session["Current_sections"];
            }

        public ActionResult GetGradeSections(int? ID, [DataSourceRequest] DataSourceRequest request)
        {
            if (ID != null)
            {
                var json = JsonConvert.SerializeObject(_unitOfWork.Grade_Infos.Find(ID).Sections.Select(s=>new {s.ID,s.Name}), Formatting.Indented,
                              new JsonSerializerSettings
                              {
                                  ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                              });

                return Content(json, "application/json");
            }

            return Content("");





        }
        public ActionResult GetSectionStudents (int? grade_id, int? section_id, [DataSourceRequest] DataSourceRequest request)
        {
            if (grade_id != null && section_id != null)
            {
                var json = JsonConvert.SerializeObject(GetCurrentSections(grade_id).Where(s => s.ID == section_id).First().Students.ToDataSourceResult(request), Formatting.Indented,
                                new JsonSerializerSettings
                                {
                                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                });

                return Content(json, "application/json");
            }


            return Content("");



        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddStudentToSection([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Models.Registration.StudentListViewModel> students, int? grade_id, int? section_id)
        {
            var results = new List<Models.Registration.StudentListViewModel>();

            if (students != null && ModelState.IsValid)
            {
                foreach (var student in students)
                {
                    GetCurrentSections(grade_id).Where(s => s.ID == section_id).First().Students.Add(student);
                    results.Add(student);
                }
            }

            return Json(results.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RemoveStudentFromSection([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Models.Registration.StudentListViewModel> students, int? grade_id, int? section_id)
        {
            var results = new List<Models.Registration.StudentListViewModel>();

            if (students != null && ModelState.IsValid)
            {
                foreach (var student in students)
                {
                   var obj =  GetCurrentSections(grade_id).Where(s => s.ID == section_id).First().Students.Where(std => std.student_id == student.student_id).First();

                    GetCurrentSections(grade_id).Where(s => s.ID == section_id).First().Students.Remove(obj);
                    RemovedStudents.Add(student.student_id);


                   results.Add(student);
                }
            }

            return Json(results.ToDataSourceResult(request, ModelState));
        }



        [HttpPost]
        public async Task<ActionResult> SaveSection (int? grade_id)
        {
            foreach (var section in GetCurrentSections(grade_id))
            {
                foreach (var student in section.Students)
                {
                    _unitOfWork.student_sections.Add(new student_section() { section_id = section.ID, student_id = student.student_id});

                }
                
            }

            foreach (int id in RemovedStudents)
            {
                _unitOfWork.student_sections.Delete(id);
            }

            try
            {
              //  _unitOfWork.Save();
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }
            return Content("");
        }


    }
}