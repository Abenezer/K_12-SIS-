using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using K_12.BLL.Service;
using K_12.Entity;

namespace K_12.WEB.Api
{
    public class PhoneBooksController : Controller<Entity.PhoneBook>
    {
        public PhoneBooksController(IUnitOfWork unitOfWork, IPhonebookService service) : base(unitOfWork, service)
        {
        }
    }
}