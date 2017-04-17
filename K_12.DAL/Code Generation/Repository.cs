using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using K_12.Entity;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbSet<TEntity> _entities;
    private K_12Entities _context;
    protected Repository(K_12Entities context)
    {
        _entities = context.Set<TEntity>();
        _context = context;
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _entities.ToList();
    }

    public TEntity GetById(int id)
    {
        return _entities.Find(id);
    }

    public void Add(TEntity entity)
    {
        _entities.Add(entity);
    }

    public void Delete(TEntity entity)
    {
        _entities.Remove(entity);
      //  _context.Entry(entity).State = EntityState.Modified;
    }

	public void Delete(params object[] keyValues)
    {
        var entity = _entities.Find(keyValues);
        Delete(entity);
       
    }

    public  TEntity Find(params object[] keyValues)
    {
        return _entities.Find(keyValues);
    }


    public IQueryable<TEntity> Queryable()
    {
        return _entities;
    }


    public void Update(TEntity entity)
    {
        //entity.ObjectState = ObjectState.Modified;
        _entities.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }


}

