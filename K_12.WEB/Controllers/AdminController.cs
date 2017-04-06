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

        public AdminController(IUnitOfWork unitofwork, IApplicationService applicationservice)
        {
            _unitOfWork = unitofwork;
            _applicationService = applicationservice; 
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

        public ActionResult GetGradeSections(int? ID, [DataSourceRequest] DataSourceRequest request)
        {
            if (ID != null)
            {
                var json = JsonConvert.SerializeObject(_unitOfWork.Grade_Infos.Find(ID).Sections.ToDataSourceResult(request), Formatting.Indented,
                              new JsonSerializerSettings
                              {
                                  ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                              });

                return Content(json, "application/json");
            }

            return Content("");



      
         
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


    }
}