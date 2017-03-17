                
using K_12.Entity;
              
public class StudentParentRepository : Repository<student_parent>, IStudentParentRepository
{
    private K_12Entities _context;

    public StudentParentRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IStudentParentRepository.cs file
}
