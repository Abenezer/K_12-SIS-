﻿using K_12.BLL.Service;
using K_12.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;
using System.Data.Entity.Infrastructure;

namespace K_12.WEB.Api
{
    public class AddressController : Controller<Address>
    {
        public AddressController(IUnitOfWork unitOfWork, IAddressService service) : base(unitOfWork, service)
        {
        }
    }
}