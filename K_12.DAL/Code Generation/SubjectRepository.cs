                
using K_12.Entity;
              
public class SubjectRepository : Repository<Subject>, ISubjectRepository
{
    private K_12Entities _context;

    public SubjectRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the ISubjectRepository.cs file
}
