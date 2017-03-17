
    
using K_12.Entity;
              
public class SchoolRepository : Repository<School>, ISchoolRepository
{
    private K_12Entities _context;

    public SchoolRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the ISchoolRepository.cs file
}
