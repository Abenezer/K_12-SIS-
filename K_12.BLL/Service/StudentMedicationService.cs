    
using K_12.Entity;
namespace K_12.BLL.Service
{
     
	 public interface IStudentMedicationService : IService<student_medication>
    {


    }
    public class StudentMedicationService : Service<student_medication>, IStudentMedicationService
    {
        public StudentMedicationService(IStudentMedicationRepository repository) : base(repository)
        {
        }
    }
	 
	          
	

}

