                
using K_12.Entity;
              
public class ApplicantRepository : Repository<Applicant>, IApplicantRepository
{
    private K_12Entities _context;

    public ApplicantRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IApplicantRepository.cs file
}
