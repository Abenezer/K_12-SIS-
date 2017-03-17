                
using K_12.Entity;
              
public class ParentRepository : Repository<Parent>, IParentRepository
{
    private K_12Entities _context;

    public ParentRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IParentRepository.cs file
}
