using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using K_12.BLL.Service;
using K_12.Entity;

namespace K_12.WEB.Api
{
    public class PhoneBookController : Controller<Entity.PhoneBook>
    {
        public PhoneBookController(IUnitOfWork unitOfWork, IPhonebookService service) : base(unitOfWork, service)
        {
        }
    }
}