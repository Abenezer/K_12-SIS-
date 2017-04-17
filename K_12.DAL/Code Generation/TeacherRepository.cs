
using System;
using K_12.Entity;
using System.Linq;

public class TeacherRepository : Repository<Teacher>, ITeacherRepository
{
    private K_12Entities _context;

    public TeacherRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    public Teacher GetByUserId(string user_id)
    {
      return   Queryable().Where(p => p.Staff.user_id == user_id).First();
    }

    //Override any generic method for your own custom implemention, add new repository methods to the ITeacherRepository.cs file
}
