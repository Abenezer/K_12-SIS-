                
using K_12.Entity;
              
public class AddressRepository : Repository<Address>, IAddressRepository
{
    private K_12Entities _context;

    public AddressRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IAddressRepository.cs file
}
