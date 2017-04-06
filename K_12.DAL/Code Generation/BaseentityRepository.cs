                
using K_12.Entity;
              
public class BaseentityRepository : Repository<BaseEntity>, IBaseentityRepository
{
    private K_12Entities _context;

    public BaseentityRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IBaseentityRepository.cs file
}
