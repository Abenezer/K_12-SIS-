                
using K_12.Entity;
              
public class MedicationRepository : Repository<Medication>, IMedicationRepository
{
    private K_12Entities _context;

    public MedicationRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IMedicationRepository.cs file
}
