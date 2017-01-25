using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using K_12.Entity;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbSet<TEntity> _entities;

    protected Repository(K_12Entities context)
    {
        _entities = context.Set<TEntity>();
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
    }

	public void Delete(object id)
    {
        var entity = _entities.Find(id);
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
       // _context.SyncObjectState(entity);
    }
}

