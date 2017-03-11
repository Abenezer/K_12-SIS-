using K_12.BLL.Service;
using K_12.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;
using System.Data.Entity.Infrastructure;
using System.Web.Http.OData.Routing;
using System.Web.Http.OData.Extensions;
using Microsoft.Data.Edm;

namespace K_12.WEB.Api
{
    public class Controller<TEntity> : ODataController where TEntity : BaseEntity
    {
        protected readonly IService<TEntity> _service;
        protected readonly IUnitOfWork _unitOfWork;

        public Controller(
            IUnitOfWork unitOfWork,
            IService<TEntity> service)
        {
            _unitOfWork = unitOfWork;
            _service = service;
        }



        // GET: odata/Address
        [HttpGet]
        [Queryable]
        public IQueryable<TEntity> Get()
        {
            return _service.Queryable();
        }

        
        // GET: odata/Customers(5)
        [Queryable]
        public SingleResult<TEntity> Get([FromODataUri] int key)
        {
            return SingleResult.Create(_service.Queryable().Where(t => t.ID == key)); //TO-DO solve
        }
        

        // PUT: odata/Customers(5)
        public async Task<IHttpActionResult> Put(int key, TEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            if (key != entity.ID)
            {
               return BadRequest();
            }

            // customer.ObjectState = ObjectState.Modified;
            _service.Update(entity);

            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(entity);
        }









        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntityExists(int key)
        {
            return _service.Find(key) != null;
        }
    }

}
