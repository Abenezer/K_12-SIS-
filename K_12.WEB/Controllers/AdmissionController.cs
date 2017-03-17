using K_12.BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K_12.WEB.Controllers
{
    public class AdmissionController : Controller
    {

        protected readonly IAdmissionService _service;
        private readonly IUnitOfWork _unitOfWork;

        public AdmissionController(
           IUnitOfWork unitOfWork,
           IAdmissionService service)
        {
            _unitOfWork = unitOfWork;
            _service = service;
        }


        private Entity.Student CurrentStudent
        {
            get
            {

                if (Session["current_student"] == null)
                {

                    Session["current_student"] = new Entity.Student();
                }
                return (Entity.Student)Session["current_student"];


            }

            set
            {
                if(value!=null)
                Session["current_student"] = value;

            }



        }



        private Entity.Parent CreateNewParent()
        {
            Entity.Parent parent = new Entity.Parent();
            parent.Address = new Entity.Address();
            parent.Address.PhoneBooks.Add(new Entity.PhoneBook() { Type = "Mobile" });
            parent.Address.PhoneBooks.Add(new Entity.PhoneBook() { Type = "Office" });
            return parent;
        }
        private IList<Entity.student_parent> CurrentParents
        {
            get
            {

                if (Session["current_parents"] == null)
                {
                    List<Entity.student_parent> _p = new List<Entity.student_parent>();
                    _p.Add(new Entity.student_parent() { Parent = CreateNewParent() });
                    Session["current_parents"] = _p;

                }
                return (IList<Entity.student_parent>)Session["current_parents"];


            }

            set
            {
                if (value != null)
                    Session["current_parents"] = value;

            }



        }


        private int CurrentParentIndex
        {
            get
            {

                if (Session["current_parent_index"] == null)
                {

                    Session["current_parent_index"] = 0; 
                }
                return (int)Session["current_parent_index"];


            }

            set
            {
                Session["current_parent_index"] = value;

            }



        }


        private Models.UserViewModel CurrentUserModel
        {
            get
            {

                if (Session["current_user_model"] == null)
                {

                    Session["current_user_model"] = new Models.UserViewModel() { Email = CurrentParents.First().Parent.Address.Email};

                }
                return (Models.UserViewModel)Session["current_user_model"];


            }

            set
            {
                Session["current_user_model"] = value;

            }



        }



        public ActionResult GetSchools()
        {
           return Json(_unitOfWork.Schools.Queryable(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMedications()
        {
            return Json(_unitOfWork.Medications.Queryable(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLanguages()
        {
            return Json(_unitOfWork.Languages.Queryable(), JsonRequestBehavior.AllowGet);
        }


        // GET: Admission
        public ActionResult Index()
        {
            Session.Clear();

            return View();
        }

        public ActionResult StudentInfo()
        {
            return View();
        }


        [HttpPost]
        public ActionResult StudentInfo(Models.Admission.StudentInfoViewModel studentInfo, string ButtonType)
        {
            if (ButtonType == "Reset")
            {
                var NewModel = new Models.Admission.StudentInfoViewModel();
                ModelState.Clear();
                return View(NewModel);

            }

            else if (ButtonType == "Next")
            {
                if (ModelState.IsValid)
                {

                   //To-Do check if this nullify when empty 
                    CurrentStudent = AutoMapper.Mapper.Map<Models.Admission.StudentInfoViewModel, Entity.Student>(studentInfo);
                    //Entity.Student currentStudent = CurrentStudent;
                    //  Models.Admission.ParnetViewModel studentViewModel = new Models.Admission.StudentInfoViewModel();
                    // appViewModel = AutoMapper.Mapper.Map<Entity.Applicant, Models.ApplicantBasicViewModel>(currentApplicant);
                   

                    ModelState.Clear();
                    CurrentParentIndex = 0;
                    return View("ParentInfo", CurrentParents.First());
                }
            }

        
            return View();

        }

        [HttpPost]
        public ActionResult ParentInfo(Entity.student_parent parentInfo, string ButtonType)
        {
            if (ButtonType == "Reset")
            {
                var NewModel = new Entity.student_parent() { Parent = CreateNewParent() };
                ModelState.Clear();
                return View(NewModel);

            }

            else if (ButtonType == "Next")
            {
               
                   if(CurrentParents.Count()-1 == CurrentParentIndex)
                    {
                        if (ModelState.IsValid)
                            {

                                CurrentParents[CurrentParentIndex] = parentInfo;
                                ModelState.Clear();
                                return View("StudentExtraInfo", StudentExtraInfoModel);

                            }
                      
                    }

                   else
                {
                    if (ModelState.IsValid)
                    {
                        CurrentParents[CurrentParentIndex] = parentInfo;
                        CurrentParentIndex++;
                        ModelState.Clear();
                        return View("ParentInfo", CurrentParents[CurrentParentIndex]);
                    }

                }
            }

            else if (ButtonType == "Add")
            {
                if (ModelState.IsValid)
                {

                    CurrentParents.Add(parentInfo);
                    CurrentParentIndex++;
                    ModelState.Clear();
                    return View("ParentInfo",new Entity.student_parent() { Parent = CreateNewParent()});
                }
            }

            else if (ButtonType == "Back")
            {
               
                if(CurrentParentIndex==0)
                {
                    Models.Admission.StudentInfoViewModel studentInfo = AutoMapper.Mapper.Map<Entity.Student, Models.Admission.StudentInfoViewModel>(CurrentStudent);

                    ModelState.Clear();
                    return View("StudentInfo", studentInfo);

                }

                else
                {
                    CurrentParentIndex--;
                    ModelState.Clear();
                    return View("ParentInfo", CurrentParents[CurrentParentIndex]);
                }

                
                
            }



            return View();

        }

        private  Models.Admission.StudentExtraInfoViewModel StudentExtraInfoModel {

            get
            {
                Models.Admission.StudentExtraInfoViewModel studentExtraInfo = new Models.Admission.StudentExtraInfoViewModel();
                studentExtraInfo.PrevSchoolId = CurrentStudent.Prev_School_id;

                foreach (Entity.Language lang in CurrentStudent.Languages)
                { studentExtraInfo.Languages.Add(lang.ID); }


                studentExtraInfo.MedicationsList = (CurrentStudent.Medications.Count>0) ? CurrentStudent.Medications.ToList(): studentExtraInfo.MedicationsList;
                studentExtraInfo.Contacts =   CurrentStudent.Contacts.Count>0 ? CurrentStudent.Contacts: studentExtraInfo.Contacts;
                return studentExtraInfo;
            }
            }


        [HttpPost]
        public ActionResult StudentExtraInfo(Models.Admission.StudentExtraInfoViewModel studentExtraInfo, string ButtonType)
        {
            if (ButtonType == "Reset")
            {
                var NewModel = new Models.Admission.StudentInfoViewModel();
                ModelState.Clear();
                return View(NewModel);

            }

            else if (ButtonType == "Next")
            {
                if (ModelState.IsValid)
                {
                    CurrentStudent.Prev_School_id = studentExtraInfo.PrevSchoolId;
                  
                    foreach (string lan_id in studentExtraInfo.Languages)
                    {
                        CurrentStudent.Languages.Add(_unitOfWork.Languages.Find(lan_id));
                    }


                        CurrentStudent.Medications = studentExtraInfo.MedicationsList;
                    CurrentStudent.Contacts = studentExtraInfo.Contacts;


                    ModelState.Clear();
                    return View("UserRegistration", CurrentUserModel);


                }
            }

            
            else if (ButtonType == "Back")
            {

               
                ModelState.Clear();
                return View("ParentInfo", CurrentParents.Last());

            }



            return View();

        }





        [HttpPost]
        public ActionResult UserRegistration(Models.UserViewModel userViewModel, string ButtonType)
        {

            if (ButtonType == "Next")
            {

                if (ModelState.IsValid)
                {
                    //check user_exists 
                    CurrentUserModel = userViewModel;
                    CurrentParents.First().Parent.K12User = new Entity.K12User() { Username = userViewModel.Username, Password = userViewModel.Password, Email = userViewModel.Email };
                    CurrentStudent.Parents = CurrentParents;
                    ModelState.Clear();
                    return View("Confirmation", CurrentStudent);


                }
            }


            else if (ButtonType == "Back")
            {

                return View("StudentExtraInfo", StudentExtraInfoModel);


            }



            return View();

        }




        [HttpPost]
        public ActionResult Confirmation(string ButtonType)
        {
           
             if (ButtonType == "Next")
            {


              



            }


            else if (ButtonType == "Back")
            {
                return View("UserRegistration", CurrentUserModel);

            

            }



            return View();

        }





    }
}