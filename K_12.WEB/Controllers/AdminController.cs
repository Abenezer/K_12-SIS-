using K_12.BLL.Service;
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
    [Authorize (Roles ="Admin")]
    public class AdminController : Controller
    {
        protected readonly IApplicationService _applicationService; 
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IStaffService _staffService;

        public AdminController(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
            _applicationService = new ApplicationService(_unitOfWork.Applications);
            _staffService = new StaffService(_unitOfWork.Staffs); 
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProcessApplication()
        {

            return View(); 
        }

        public ActionResult GetApplications([DataSourceRequest] DataSourceRequest request, string Grade)
        {

            IQueryable<Models.Admin.ApplicationListViewModel> applications = _applicationService.Queryable()
                .Select(app => new Models.Admin.ApplicationListViewModel()
                {
                    ID = app.ID,
                    FName = app.Applicant.FName,
                    MName = app.Applicant.MName,
                    Gender = app.Applicant.Gender,
                    DOB = app.Applicant.DOB.Value,
                    Grade = app.Grade_Info.Grade,
                    Status = app.app_status,
                    AppDate = app.application_date.Value

                }).Where (a=>(Grade == null || Grade == "" || a.Grade == Grade));

            
            var json = JsonConvert.SerializeObject(applications.ToDataSourceResult(request), Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });

            return Content(json, "application/json");
        }


        public ActionResult ApplicationDetail (int ID)
        {
          return PartialView(_applicationService.Find(ID));
        }



        [HttpPost]
        public async Task<ActionResult> SetStatus(Entity.Application app , string ButtonType)
        {  var updatedApp = _applicationService.Find(app.ID);
            if (BLL.Constants.ApplicationStatuses.avarailbleStatuses.Contains(ButtonType))
            {

              
                updatedApp.app_status = ButtonType;
                _applicationService.Update(updatedApp);

                try
                {
                    await _unitOfWork.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                }
               
            }
          
 return PartialView("ApplicationDetail", updatedApp);
        }
        

      

        public ActionResult ConfigureAdmission ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConfigureAdmission(string method)
        {
            BLL.BLL.Configuration.AdmisssionMethod = method;
            BLL.BLL.Configuration.Write();
            return Json(new { });
        }

        public ActionResult Sections()
        {

            return View();
        }

        public ActionResult GetGradeSections(int? grade_id, [DataSourceRequest] DataSourceRequest request)
        {
            if (grade_id != null)
            {
                var json = JsonConvert.SerializeObject(_unitOfWork.Grade_Infos.Find(grade_id).Sections.Select(s=> new Models.Registration.SectionViewModel{
               ID = s.ID,
               Name = s.Name


                }).ToDataSourceResult(request), Formatting.Indented,
                              new JsonSerializerSettings
                              {
                                  ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                              });

                return Content(json, "application/json");
            }

            return Content("");

            
         
        }

        public ActionResult GetTeachers()
        {

            var json = JsonConvert.SerializeObject(_unitOfWork.Teachers.Queryable().Select(t => new Models.Staff.StaffListViewModel()
            {
                FullName = t.Staff.FName + " " + t.Staff.MName,
                ID = t.ID,
                StaffType = t.Staff.StaffType,
                  
                
                })
                    
                  , Formatting.Indented,
                              new JsonSerializerSettings
                              {
                                  ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                              });

                return Content(json, "application/json");
           

        }

        public ActionResult AddSection(int? grade_id)
        {
            return View(new Entity.Section() {grade_id = grade_id });
        }



        [HttpPost]
        public async Task<ActionResult> AddSection(Entity.Section section)
        {
            if (section.Name != null)
            {
                if (section.ID == 0)
                    _unitOfWork.Sections.Add(section);
                else
                    _unitOfWork.Sections.Update(section);
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


        public ActionResult EditSection(int ID)
        {
            return View(_unitOfWork.Sections.Find(ID));
        }


        public ActionResult StaffClaims()
        {
            return View();
        }


        public ActionResult StaffClaimDetail(int ID)
        {


            return View(_staffService.Find(ID));
        }

        public async Task<ActionResult> ConfirmStaff(Entity.Staff staff)
        {

            staff = _unitOfWork.Staffs.Find(staff.ID);


            staff.Status = BLL.Constants.StaffStatus.CONFIRMED;
            _staffService.Update(staff);
            //if (staff.StaffType == BLL.Constants.StaffTypes.TEACHER)
            //{
            //    var teacher = new Entity.Teacher();
            //    teacher.Staff = staff; 
            //     _unitOfWork.Teachers.Add(teacher);
            //}
            
          

            
            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }
            return Content("");
        }

        public ActionResult GetGrades()
        {
            IQueryable<Models.GradeViewModel> grades = _unitOfWork.Grade_Infos.Queryable()
                .Select(g => new Models.GradeViewModel()
                {
                    ID = g.ID,
                    Grade = g.Grade


                });

            return Json(grades, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetGradeSubjects(int? ID, [DataSourceRequest] DataSourceRequest request)
        {
            if (ID != null)
            {
                var json = JsonConvert.SerializeObject(_unitOfWork.Grade_Infos.Find(ID).Subjects.Select(s=> new Models.Admin.SubjectListViewModel() {

                    grade_id = ID,
                    subject_id = s.ID,
                    Name = s.Name,
                    
                }).ToDataSourceResult(request), Formatting.Indented,
                              new JsonSerializerSettings
                              {
                                  ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                  
                              });

                return Content(json, "application/json");
            }

            return Content("");
            
        }


        public ActionResult GetSubjects()
        {
            return Json(_unitOfWork.Subjects.Queryable().Select(s => new { s.ID, s.Name }),JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetClassesBySection(int? section_id, [DataSourceRequest] DataSourceRequest request)
        {
            IEnumerable<Entity.Class> classes;
            if(section_id!=null)
            {
                classes = _unitOfWork.Classs.getBySection(section_id.Value);

            }
            else { classes = _unitOfWork.Classs.GetAll(); }

            var json = JsonConvert.SerializeObject(classes.ToDataSourceResult(request), Formatting.Indented,
                             new JsonSerializerSettings
                             {
                                 ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                             });

            return Content(json, "application/json");

        }

        public ActionResult GetClassesBySubject(int? subject_id, int? grade_id ,[DataSourceRequest] DataSourceRequest request)
        {
            IEnumerable<Models.Admin.ClassListViewModel> classes;
            if (subject_id != null && grade_id!=null)
            {
                classes = _unitOfWork.Classs.getBySubjectAndGrade(subject_id.Value, grade_id.Value).Select(c=> new Models.Admin.ClassListViewModel() {
                    section_id = c.section_id,
                    subject_id = c.subject_id,
                    SectionName = c.Section.Name,
                    TeacherName = c.Teacher.Staff.FName + " " + c.Teacher.Staff.MName
                    

                });

            }
            else { classes = new HashSet<Models.Admin.ClassListViewModel> (); }

            var json = JsonConvert.SerializeObject(classes.ToDataSourceResult(request), Formatting.Indented,
                             new JsonSerializerSettings
                             {
                                 ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                             });

            return Content(json, "application/json");

        }

      

        public ActionResult Classes ()
        {
            return View();
        }

        public ActionResult AddEditClass(int? subject_id, int? section_id)
        {
          
            if (subject_id!=null&&section_id!=null)
            {
                Entity.Class cls = _unitOfWork.Classs.Find(section_id,subject_id); 
                if(cls!=null)
                {
                    return View(cls);
                }
            }

            return View(new Entity.Class() { subject_id = subject_id.Value});
        }

        [HttpPost]
        public async Task<ActionResult> AddEditClass(Entity.Class cls)
        {
         
                if (_unitOfWork.Classs.Find(cls.section_id, cls.subject_id) != null)
                    _unitOfWork.Classs.Update(cls);
                else
                    _unitOfWork.Classs.Add(cls);
                try
                {
                    await _unitOfWork.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Json("");
            

        }



        [HttpPost]
       public async Task<ActionResult> addSubjectToGrade(Models.Admin.SubjectListViewModel subjectModel)
        {
            if(subjectModel.grade_id != null)
            {
                Entity.Subject subject = _unitOfWork.Subjects.Find(subjectModel.subject_id);
             
                if(subject==null)
                {
                    subject = new Entity.Subject() { Name = subjectModel.Name };
                }


                _unitOfWork.Grade_Infos.Find(subjectModel.grade_id).Subjects.Add(subject);
                try
                {
                    await _unitOfWork.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                }
            }

            return Json(subjectModel);
        }
    }
}