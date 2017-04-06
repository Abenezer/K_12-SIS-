                
using K_12.Entity;
              
public class ClassRepository : Repository<Class>, IClassRepository
{
    private K_12Entities _context;

    public ClassRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IClassRepository.cs file
}
