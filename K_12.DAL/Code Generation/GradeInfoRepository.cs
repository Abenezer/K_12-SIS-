                
using K_12.Entity;
              
public class GradeInfoRepository : Repository<Grade_Info>, IGradeInfoRepository
{
    private K_12Entities _context;

    public GradeInfoRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IGradeInfoRepository.cs file
}
