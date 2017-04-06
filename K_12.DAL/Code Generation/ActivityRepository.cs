                
using K_12.Entity;
              
public class ActivityRepository : Repository<Activity>, IActivityRepository
{
    private K_12Entities _context;

    public ActivityRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IActivityRepository.cs file
}
