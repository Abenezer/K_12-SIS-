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
    [Authorize(Roles = "Parent,Teacher")]
    public class ProfileController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;

        public ProfileController(
           IUnitOfWork unitOfWork
          )
        {
            _unitOfWork = unitOfWork;



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




        public ActionResult LeftMenu()
        {
            if (User.IsInRole("Parent"))
            {
                var currentParent = _unitOfWork.Parents.GetByUserId(User.Identity.GetUserId());

                return PartialView("_side_menu", new Models.Profile.SideMenuViewModel()
                {
                    MainListText = "Students",

                    MainListItems = currentParent.Students.GetStudentNames().Select(s => new Models.Profile.MenuItem
                    {

                        Text = s.Value,
                        URL = "#/student/" + s.Key,
                    })
                }

                );
            }

            if (User.IsInRole("Teacher"))
            {
                var currentTeacher = _unitOfWork.Teachers.GetByUserId(User.Identity.GetUserId());

                return PartialView("_side_menu", new Models.Profile.SideMenuViewModel()
                {
                    MainListText = "Classes",

                    MainListItems = currentTeacher.Classes.Select(c => new Models.Profile.MenuItem
                    {

                        Text = c.Section.Name + " " + c.Subject.Name,
                        URL = "#/class/" + c.section_id + "/" + c.subject_id,
                    })
                }

                );
            }

            return PartialView("_side_menu");
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