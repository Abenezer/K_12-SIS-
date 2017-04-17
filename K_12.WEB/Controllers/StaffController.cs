using K_12.BLL.Service;
using K_12.Entity;
using K_12.WEB.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace K_12.WEB.Controllers
{
    public class StaffController : Controller
    {

        protected readonly IStaffService _service;
        private readonly IUnitOfWork _unitOfWork;

        public StaffController(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
            _service = new StaffService(_unitOfWork.Staffs);
        }



        // GET: Staff
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Claim()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Claim(Models.Staff.StaffClaimViewModel staffClaimModel)
        {
            if(ModelState.IsValid)
            {

             Entity.Staff staff = AutoMapper.Mapper.Map<Models.Staff.StaffClaimViewModel,Entity.Staff>(staffClaimModel);
                staff.Status = BLL.Constants.StaffStatus.PENDING;
                staff.Claim_Date = DateTime.Today;
                _service.Insert(staff);

                try
                {
                    await _unitOfWork.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                }


                return View("SuccessClaim");

            }

            return View();
          
        }


        public ActionResult GetPendingStaffs([DataSourceRequest] DataSourceRequest request)
        {
            IQueryable pendingStaffs = _service.GetPendingStaffs().Select(s => new Models.Staff.StaffListViewModel()
            {
                ID = s.ID,
                FullName = s.FName + " " + s.MName,
                ClaimDate = s.Claim_Date.Value,
                StaffType = s.StaffType,
            });

            return Json(pendingStaffs.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }


        private Entity.Staff CurrentStaff
        {
            get
            {

                if (Session["current_staff"] == null)
                {

                    Session["current_staff"] = new Entity.Staff();
                }
                return (Entity.Staff)Session["current_staff"];


            }

            set
            {
                if (value != null)
                    Session["current_staff"] = value;

            }



        }


        private Models.UserViewModel CurrentUserModel
        {
            get
            {

                if (Session["current_user_model"] == null)
                {

                    Session["current_user_model"] = new Models.UserViewModel() { Email = CurrentStaff.Address.Email };

                }
                return (Models.UserViewModel)Session["current_user_model"];


            }

            set
            {
                Session["current_user_model"] = value;

            }



        }
        public ActionResult Register(int ID)
        {
            var staff = _service.Find(ID); 
            if(staff!=null)
            {
                if(staff.Status==BLL.Constants.StaffStatus.CONFIRMED)
                {
                    CurrentStaff = staff;
                    return View(staff);

                }

                return View("StaffNotConfirmed");
            }


            return View("StaffNotFound");

        }
        
        public ActionResult StaffInfo()
        {

            return View(CurrentStaff);
        }


        [HttpPost]
        public ActionResult StaffInfo(Staff staff, string ButtonType)
        {
            if (ButtonType == "Reset")
            {
                var NewModel = new Entity.Staff();
                ModelState.Clear();
                return View(NewModel);

            }

            else if (ButtonType == "Next")
            {
                if (ModelState.IsValid)
                {
                    var updated_staff = _service.Find(staff.ID);
                    updated_staff.FName = staff.FName;
                    updated_staff.MName = staff.MName;
                    updated_staff.LName = staff.LName;
                    updated_staff.DOB = staff.DOB;
                    updated_staff.Address.Subcity = staff.Address.Subcity;
                    updated_staff.Address.Woreda = staff.Address.Woreda;
                    updated_staff.Address.H_NO = staff.Address.H_NO;
                    updated_staff.Address.Email = staff.Address.Email;
                    updated_staff.Address.PhoneBooks.First().Phone = staff.Address.PhoneBooks.First().Phone;

                     CurrentStaff = updated_staff;
                     ModelState.Clear();
      
                    return View("UserRegistration", CurrentUserModel);
                }
            }


            return View();



        }


        [HttpPost]
        public async Task<ActionResult> UserRegistration(UserViewModel userViewModel, string ButtonType)
        {
            
            if (ButtonType == "Next")
            {

                if (ModelState.IsValid)
                {
                    CurrentUserModel = userViewModel;
                    ApplicationDbContext context = new ApplicationDbContext();

                    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                    var user = new ApplicationUser { UserName = CurrentUserModel.Username, Email = CurrentUserModel.Email, DisplayName = CurrentStaff.GetFullName() };
                    var result = await UserManager.CreateAsync(user, CurrentUserModel.Password);
                    if (result.Succeeded)
                    {
                        if (CurrentStaff.StaffType == BLL.Constants.StaffTypes.TEACHER)
                        {
                            UserManager.AddToRole(user.Id, "Teacher");
                            var teacher = new Teacher() {ID = CurrentStaff.ID};
                            _unitOfWork.Teachers.Add(teacher);
                        }
                      
                        
                            CurrentStaff.user_id = user.Id;
                       
                            _service.Update(CurrentStaff);
                        _unitOfWork.Addresss.Update(CurrentStaff.Address); // just to make sure



                        try
                        {
                                ApplicationSignInManager SignInManager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
                                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                                
                            await _unitOfWork.SaveAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {

                        }


                        ModelState.Clear();

                        return View("SuccessRegistration", CurrentStaff);


                    }
                }
            }


            else if (ButtonType == "Back")
            {

                return View("StaffInfo", CurrentStaff);


            }



                return View();

            }

        }
    }