                
using K_12.Entity;
              
public class PersonRepository : Repository<Person>, IPersonRepository
{
    private K_12Entities _context;

    public PersonRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IPersonRepository.cs file
}
