
using System;
using K_12.Entity;
using System.Linq;

public class ParentRepository : Repository<Parent>, IParentRepository
{
    private K_12Entities _context;

    public ParentRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    public Parent GetByUserId(string user_id)
    {
        return Queryable().Where(p => p.user_id == user_id).First();
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IParentRepository.cs file
}
