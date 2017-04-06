                
using K_12.Entity;
              
public class TeacherRepository : Repository<Teacher>, ITeacherRepository
{
    private K_12Entities _context;

    public TeacherRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the ITeacherRepository.cs file
}
