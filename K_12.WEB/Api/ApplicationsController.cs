using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using K_12.BLL.Service;
using K_12.Entity;
using System.Web.Http;

namespace K_12.WEB.Api
{
    public class ApplicationsController : Controller<Entity.Applicant>
    {
        public ApplicationsController(IUnitOfWork unitOfWork, IApplicantService service) : base(unitOfWork, service)
        {
        }


        [HttpGet]
        [Queryable]
        public IQueryable<Contact> GetContacts(int key)
        {
            return _service.Find(key).Contacts.AsQueryable();

        }


    }
}