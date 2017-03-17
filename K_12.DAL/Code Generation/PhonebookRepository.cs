                
using K_12.Entity;
              
public class PhonebookRepository : Repository<PhoneBook>, IPhonebookRepository
{
    private K_12Entities _context;

    public PhonebookRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IPhonebookRepository.cs file
}
