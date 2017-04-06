                
using K_12.Entity;
              
public class StudentSectionRepository : Repository<student_section>, IStudentSectionRepository
{
    private K_12Entities _context;

    public StudentSectionRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IStudentSectionRepository.cs file
}
