                
using K_12.Entity;
              
public class StaffRepository : Repository<Staff>, IStaffRepository
{
    private K_12Entities _context;

    public StaffRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IStaffclaimRepository.cs file
}
