                
using K_12.Entity;
              
public class ContactRepository : Repository<Contact>, IContactRepository
{
    private K_12Entities _context;

    public ContactRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IContactRepository.cs file
}
