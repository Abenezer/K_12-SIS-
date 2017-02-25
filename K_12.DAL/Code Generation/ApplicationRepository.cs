                
using K_12.Entity;
              
public class ApplicationRepository : Repository<Application>, IApplicationRepository
{
    private K_12Entities _context;

    public ApplicationRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IApplicationRepository.cs file
}
