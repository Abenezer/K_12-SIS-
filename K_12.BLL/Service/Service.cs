using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_12.BLL.Service
{

    public interface IService<TEntity>
    {

        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);

        TEntity Find(params object[] keyValues);
        IQueryable<TEntity> SelectQuery(string query, params object[] parameters);

        IQueryable<TEntity> Queryable();




    }
   public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        #region Private Fields
        private readonly IRepository<TEntity> _repository;
        #endregion Private Fields

        #region Constructor
        protected Service(IRepository<TEntity> repository) { _repository = repository; }
        #endregion Constructor




        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public void Delete(object id)
        {
            _repository.Delete(id); 
        }

        public TEntity Find(params object[] keyValues)
        {
            return _repository.Find(keyValues);
        }

        public void Insert(TEntity entity)
        {
            _repository.Add(entity);
        }

        public void InsertRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Insert(entity);
            }
        }

        public IQueryable<TEntity> Queryable()
        {
          return   _repository.Queryable();
        }

        public IQueryable<TEntity> SelectQuery(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }
    }
}
