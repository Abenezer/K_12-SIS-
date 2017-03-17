                
using K_12.Entity;
              
public class StudentMedicationRepository : Repository<student_medication>, IStudentMedicationRepository
{
    private K_12Entities _context;

    public StudentMedicationRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IStudentMedicationRepository.cs file
}
