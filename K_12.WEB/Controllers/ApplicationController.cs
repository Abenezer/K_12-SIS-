using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using K_12.BLL.Service;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace K_12.WEB.Controllers
{
    public class ApplicationController : Controller
    {

        protected readonly IApplicationService _service;
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationController(
            IUnitOfWork unitOfWork,
            IApplicationService service)
        {
            _unitOfWork = unitOfWork;
            _service = service;
        }



        // GET: Administration
        public ActionResult Index()
        {
            return View(new Models.GradeViewModel());
        }

        public ActionResult ApplicationForm()
        {
            Entity.Application app = new Entity.Application();
            Entity.Address address = new Entity.Address();
            address.PhoneBooks.Add(new Entity.PhoneBook());
            address.PhoneBooks.Add(new Entity.PhoneBook());

            app.Contacts.Add(new Entity.Contact() {Address = address });
            

            return View(app);
        }

        [HttpPost]
        public ActionResult ApplicationForm(Entity.Application app)
        {
            _service.Insert(app);
            _unitOfWork.SaveAsync();

         
            return Json(app.ID, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetApplications([DataSourceRequest]DataSourceRequest request)
        {
            return Json(_service.Queryable().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

    }
}