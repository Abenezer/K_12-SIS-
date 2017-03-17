                
using K_12.Entity;
              
public class LanguageRepository : Repository<Language>, ILanguageRepository
{
    private K_12Entities _context;

    public LanguageRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the ILanguageRepository.cs file
}
