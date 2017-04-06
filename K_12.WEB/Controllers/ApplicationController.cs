using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using K_12.BLL.Service;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace K_12.WEB.Controllers
{
    public class ApplicationController : Controller
    {

        protected readonly IApplicantService _service;
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationController(
            IUnitOfWork unitOfWork,
            IApplicantService service)
        {
            _unitOfWork = unitOfWork;
            _service = service;
        }


        private Models.GradeViewModel SelectedGrade
        {
            get {

                if (Session["selected_grade"] == null)
                {

                    Session["selected_grade"] = new Models.GradeViewModel(); 
                }
                return (Models.GradeViewModel)Session["selected_grade"];
                

            }

           
           
        }

        private Entity.Applicant GetApplicant()
        {
            if (Session["applicant"] == null)
            {
                Entity.Applicant app = new Entity.Applicant();
                //Entity.Address address = new Entity.Address();

                //address.PhoneBooks.Add(new Entity.PhoneBook() { Type = "Mobile" });
                //address.PhoneBooks.Add(new Entity.PhoneBook() { Type = "Office" });

                //app.Contacts.Add(new Entity.Contact() { Address = address });

                Session["applicant"] = app;
            }
            return (Entity.Applicant)Session["applicant"];
        }

    

        private ICollection<Models.FileUploadViewModel> GetDocuments()
        {
            if (Session["applicantDocuments"] == null)
            {
               

                ICollection<Models.FileUploadViewModel> fileList = new HashSet<Models.FileUploadViewModel>();


                fileList.Add(new Models.FileUploadViewModel() { Type = "Vacination" });
                fileList.Add(new Models.FileUploadViewModel() { Type = "PreviousRecord" });
                fileList.Add(new Models.FileUploadViewModel() { Type = "BirthCeritificate" });
                fileList.Add(new Models.FileUploadViewModel() { Type = "Other" });




                Session["applicantDocuments"] = fileList;
            }
            return (ICollection<Models.FileUploadViewModel>)Session["applicantDocuments"];
        }




        // GET: Administration
        public ActionResult Index()
        {
            Session.Clear();
      


            // ViewBag.Title = BLL.BLL.Configuration.ApplicationTitle;
            return View();
        }


        public ActionResult GradeSelection()
        {


           
            return View();
        }


        [HttpPost]
        public ActionResult GradeSelection(Models.GradeViewModel grade, string ButtonType)
        {
           
            if (ButtonType == "Next")
            {
                if (ModelState.IsValid)
                {
                    Entity.Applicant currentApplicant = GetApplicant();
                    SelectedGrade.ID = grade.ID;
                    Models.ApplicantBasicViewModel appViewModel = new Models.ApplicantBasicViewModel(); 

                    //if(currentApplicant.Contacts.Count!=0)
                   appViewModel = AutoMapper.Mapper.Map<Entity.Applicant, Models.ApplicantBasicViewModel>(currentApplicant);

                    //ModelState.Clear();
                    return View("ApplicationForm", appViewModel);
                }
            }
            return View();

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

        public ActionResult GradeInfo(int ID)
        {
            
            return PartialView(_unitOfWork.Grade_Infos.Find(ID));
        }



        //public ActionResult ApplicationForm()
        //{
        //    Entity.Applicant app = new Entity.Applicant();
        //    Entity.Address address = new Entity.Address();
        //    address.PhoneBooks.Add(new Entity.PhoneBook() { Type="Mobile"});
        //    address.PhoneBooks.Add(new Entity.PhoneBook() { Type="Office"});

        //    app.Contacts.Add(new Entity.Contact() {Address = address });


        //    return View(app);
        //}



        [HttpPost]
        public ActionResult ApplicationForm(Models.ApplicantBasicViewModel applicantData, string ButtonType)
        {
            // return PartialView("Confirmation", app);

            Entity.Applicant currentApplicant = GetApplicant(); 

            if(ButtonType == "Reset")
            {
                var NewModel = new Models.ApplicantBasicViewModel();
                ModelState.Clear();
                return View(NewModel);

            }



            if (ButtonType == "Back")
            {
                Models.GradeViewModel grade = new Models.GradeViewModel();
                grade.ID = SelectedGrade.ID;
               // grade.Grade = _unitOfWork.Grade_Infos.Find(grade.ID).Grade;
                return View("GradeSelection", grade);
            }


            if (ButtonType == "Next")
            {
                if (ModelState.IsValid)
                {
                    currentApplicant.FName = applicantData.FName;  //To-Do use automapper 
                    currentApplicant.MName = applicantData.MName;
                    currentApplicant.LName = applicantData.LName;
                    currentApplicant.DOB = applicantData.DOB;
                    currentApplicant.Gender = applicantData.Gender;

                    Entity.Address address = new Entity.Address();
                    address.Email = applicantData.Contact_Email;
                    address.PhoneBooks.Add(new Entity.PhoneBook() { Type = "Mobile", Phone = applicantData.Contact_MobilePhone });
                    address.PhoneBooks.Add(new Entity.PhoneBook() { Type = "Office" , Phone = applicantData.Contact_OfficePhone});

                    Entity.Contact contact = new Entity.Contact() { FName = applicantData.Contact_FName, MName = applicantData.Contact_MName, Address = address };

                    currentApplicant.Contacts.Add(contact);



                  

                    return View("DocumentUpload", GetDocuments());
                }
            }


            return View(); 


        }








        





        [HttpPost]
        public ActionResult DocumentUpload(string ButtonType)
        {
            // return PartialView("Confirmation", app);

            Entity.Applicant currentApplicant = GetApplicant();
            if (ButtonType == "Back")
            {
                Models.ApplicantBasicViewModel applicantViewModel = AutoMapper.Mapper.Map<Entity.Applicant, Models.ApplicantBasicViewModel>(currentApplicant);

                return View("ApplicationForm", applicantViewModel);
            }


            if (ButtonType == "Next")
            {

                

                return View("Confirmation",currentApplicant);
                
            }


            return View();


        }



        //[HttpPost]
        //public async Task<ActionResult> ApplicationForm(Entity.Applicant app)
        //{

        //    try
        //    {
        //        _service.Insert(app);
        //        await _unitOfWork.SaveAsync();

        //    }

        //    catch (DbUpdateConcurrencyException)
        //    {
        //    }


        //        return Json(app.ID, JsonRequestBehavior.AllowGet);
        //}






        [HttpPost]
        public ActionResult Confirmation(Models.FileUploadViewModel files, string ButtonType)
        {
            // return PartialView("Confirmation", app);

            Entity.Applicant currentApplicant = GetApplicant();
            if (ButtonType == "Back")
            {
               
                
                return View("DocumentUpload", GetDocuments());



            }


            if (ButtonType == "Next")
            {
                ICollection<Models.FileUploadViewModel> applicantDocuments = GetDocuments();
             

                //// The files are not actually saved in this demo
                //file.SaveAs(physicalPath);


                

                //TODO save to db 
                try
                {
                   _service.Insert(currentApplicant);
                    _unitOfWork.Save(); //to get the autogenerated id 

                    Entity.Application currentApplication = new Entity.Application() { application_date = DateTime.Today, grade_applying_id = SelectedGrade.ID };

                    foreach (var doc in applicantDocuments)
                    {

                        if (doc.FileName != null)
                        {
                            
                            string localPath = Path.Combine(currentApplicant.ID.ToString(), currentApplication.application_date.Value.ToString("dd-MM-yyyy")); 

                            string physicalPath = Path.Combine(Server.MapPath("~/App_Data"), localPath);

                            Directory.CreateDirectory(physicalPath);

                            string tempPath = Path.Combine(Server.MapPath("~/App_Data/Temp"), doc.FileName);

                            physicalPath += "\\" + doc.Type + doc.Extention;

                            System.IO.File.Move(tempPath, physicalPath);

                            string localFilePath = localPath + "\\" + doc.Type + doc.Extention;
                            currentApplication.Documents.Add(new Entity.Document() { type = doc.Type, Doc_path = localFilePath, IsVerified = false });
                        }
                    }
                    currentApplication.app_status = BLL.Constants.ApplicationStatuses.PENDING;

                    currentApplicant.Applications.Add(currentApplication);
                    _service.Update(currentApplicant); //to update documet path 
                    _unitOfWork.Save(); 



                }

                catch (DbUpdateConcurrencyException)
                {
                    //TO-DO catch db eror 
                }

                Entity.Application app = currentApplicant.Applications.Last();
                if (BLL.BLL.Configuration.AdmisssionMethod==BLL.Constants.AdmissionMethods.FIFO)
                {
                    //if a place is available 
                    app.app_status = BLL.Constants.ApplicationStatuses.ACCEPTED;
                    _unitOfWork.Applications.Update(app);
                    _unitOfWork.Save();
                    return ApplicationResult(app.ID);
                }
                ViewBag.appId = app.ID;
                return View("FinishPage");

            }


            return View();


        }







        public ActionResult GetApplicants([DataSourceRequest]DataSourceRequest request)
        {
        

         var json = JsonConvert.SerializeObject(_service.Queryable().ToDataSourceResult(request), Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });

            return Content(json, "application/json");
        }



        public ActionResult SaveFile(HttpPostedFileBase file, string type)
        {
            // The Name of the Upload component is "files"

          
            if (file != null)
            {
                 ICollection<Models.FileUploadViewModel> applicantDocuments = GetDocuments();


                var doc = applicantDocuments.Where(d => d.Type == type).First(); 
                
                 //   doc.file = file;
                    doc.Extention = Path.GetExtension(file.FileName);
                    doc.Size = file.ContentLength;
                    doc.FileName = Path.GetFileName(file.FileName);

                var physicalPath = Path.Combine(Server.MapPath("~/App_Data/Temp"), doc.FileName);

                file.SaveAs(physicalPath);

                //// Some browsers send file names with full path.
                //// We are only interested in the file name.
                //var fileName = Path.GetFileName(file.FileName);


                //// The files are not actually saved in this demo


            }

            // Return an empty string to signify success
            return Content("");
        }

        public ActionResult RemoveFile(string fileName)
        {
            // The parameter of the Remove action must be called "fileNames"
           
            if (fileName != null)
            {
                ICollection<Models.FileUploadViewModel> applicantDocuments = GetDocuments();

               
                   
                    applicantDocuments.Remove(applicantDocuments.Where(f => f.FileName == Path.GetFileName(fileName)).First());
                    

                    //var fileName = Path.GetFileName(fullName);
                    var physicalPath = Path.Combine(Server.MapPath("~/App_Data/Temp"), Path.GetFileName(fileName));

                //// TODO: Verify user permissions

                if (System.IO.File.Exists(physicalPath))
                {
                   
                    System.IO.File.Delete(physicalPath);
                }

            }

            // Return an empty string to signify success
            return Content("");
        }




        [AcceptVerbs(HttpVerbs.Get)]
       // [OutputCache(CacheProfile = "ApplicationDocuments")]
       // [Route("documents/{id}/{filename}")]
        public FileResult Document(string filePath)
        {
            string physicalPath = Path.Combine(Server.MapPath("~/App_Data"), filePath);
            return new FileStreamResult(new FileStream(physicalPath, FileMode.Open), "image/jpeg");
        }


        public ActionResult CheckApplication ()
        {
            return View(); 
        }



        [HttpPost]
        public ActionResult ApplicationResult(int appID)
        {
            Entity.Application app = _unitOfWork.Applications.Find(appID);
            Models.ApplicationRessultViewModel resultViewModel = new Models.ApplicationRessultViewModel(); 

            if(app!=null)
            {
                resultViewModel.AppFound = true;
                resultViewModel.AppStatus = app.app_status;
                resultViewModel.AppID = app.ID;
                            
               
                if(app.app_status==BLL.Constants.ApplicationStatuses.ACCEPTED)
                {
                    

                    return View("ApplicationAccepted", resultViewModel);
                }

              
            }

           
            return View(resultViewModel);
        }



    }
}