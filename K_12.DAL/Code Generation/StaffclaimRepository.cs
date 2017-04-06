                
using K_12.Entity;
              
public class StaffclaimRepository : Repository<StaffClaim>, IStaffclaimRepository
{
    private K_12Entities _context;

    public StaffclaimRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IStaffclaimRepository.cs file
}
