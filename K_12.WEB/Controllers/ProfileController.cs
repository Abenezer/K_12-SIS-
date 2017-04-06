using K_12.BLL.Service;
using K_12.Entity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using K_12.WEB.Utilities;

namespace K_12.WEB.Controllers
{
    [Authorize(Roles = "Parent")]
    public class ProfileController : Controller
    {

        protected readonly IProfileService _service;
        private readonly IUnitOfWork _unitOfWork;

        public ProfileController(
           IUnitOfWork unitOfWork,
           IProfileService service)
        {
            _unitOfWork = unitOfWork;
            _service = service;
        }



        // GET: Profile
        [Authorize(Roles = "")]
        public ActionResult Index()
        {
           
            return View();
        }

       
        public ActionResult Main()
        {
            return View();
        }


        private Entity.Parent CurrentParent
        {
            get
            {

                if (Session["current_parent_profile"] == null)
                {

                    Session["current_parent_profile"] = _service.ParentService.GetParentByUserID(User.Identity.GetUserId());
                }
                return (Entity.Parent)Session["current_parent_profile"];


            }

           }


        public ActionResult LeftMenu() 
        {            
            if (User.IsInRole("Parent"))
            {
                
                return PartialView("_side_menu", new Models.Profile.SideMenuViewModel() { Students = CurrentParent.Students.GetStudentNames().ToDropDownList() }); 
            }


            return PartialView("_side_menu");
        }

        public ActionResult GetStudentList()
        {
            return Json(CurrentParent.Students.GetStudentNames().ToDropDownList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ActionMenu()
        {
            if (User.IsInRole("Parent"))
            {

               
            }


            return PartialView("_action_menu");
        }

    }
}