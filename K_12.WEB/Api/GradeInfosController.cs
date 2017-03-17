using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using K_12.BLL.Service;
using K_12.Entity;

namespace K_12.WEB.Api
{
    public class GradeInfosController : Controller<Entity.Grade_Info>
    {
        public GradeInfosController(IUnitOfWork unitOfWork, IGradeInfoService service) : base(unitOfWork, service)
        {
        }
    }
}