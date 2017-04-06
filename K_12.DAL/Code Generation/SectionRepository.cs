                
using K_12.Entity;
              
public class SectionRepository : Repository<Section>, ISectionRepository
{
    private K_12Entities _context;

    public SectionRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the ISectionRepository.cs file
}
