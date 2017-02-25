using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using K_12.BLL.Service;
using K_12.Entity;

namespace K_12.WEB.Api
{
    public class ApplicationController : Controller<Entity.Application>
    {
        public ApplicationController(IUnitOfWork unitOfWork, IApplicationService service) : base(unitOfWork, service)
        {
        }
    }
}