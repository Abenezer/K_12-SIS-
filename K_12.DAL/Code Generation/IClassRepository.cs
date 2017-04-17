using K_12.Entity;
using System.Collections.Generic;

public interface IClassRepository : IRepository<Class>
{
    //Add any additional repository methods other than the generic ones (GetAll, GetById, Delete, Add)

    IEnumerable<Class> getBySection(int section_id);

    IEnumerable<Class> getBySubjectAndGrade(int subject_id,int grade_id);

}
