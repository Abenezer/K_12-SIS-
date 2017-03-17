                
using K_12.Entity;
              
public class StudentRepository : Repository<Student>, IStudentRepository
{
    private K_12Entities _context;

    public StudentRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IStudentRepository.cs file
}
