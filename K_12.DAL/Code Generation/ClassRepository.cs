
using System;
using System.Collections.Generic;
using K_12.Entity;
using System.Linq;

public class ClassRepository : Repository<Class>, IClassRepository
{
    private K_12Entities _context;

    public ClassRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    public IEnumerable<Class> getBySection(int section_id)
    {
        return Queryable().Where(c => c.section_id == section_id);
    }

    public IEnumerable<Class> getBySubjectAndGrade(int subject_id, int grade_id)
    {
      // return  from c in Queryable() where c.subject_id == subject_id && c.Section.grade_id == grade_id;
        return Queryable().Where(c => c.subject_id == subject_id && c.Section.grade_id == grade_id);
    }


    //Override any generic method for your own custom implemention, add new repository methods to the IClassRepository.cs file
}
