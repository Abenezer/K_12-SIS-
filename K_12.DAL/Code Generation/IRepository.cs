using System.Collections.Generic;
using System.Linq;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Add(T entity);
    void Delete(T entity);

	 void Delete(params object[] keyValues);


    T Find(params object[] keyValues);
    IQueryable<T> Queryable();

    void Update(T entity);
}
