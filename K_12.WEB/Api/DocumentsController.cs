using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using K_12.BLL.Service;
using K_12.Entity;

namespace K_12.WEB.Api
{
    public class DocumentsController : Controller<Entity.Document>
    {
        public DocumentsController(IUnitOfWork unitOfWork, IDocumentService service) : base(unitOfWork, service)
        {
        }
    }
}