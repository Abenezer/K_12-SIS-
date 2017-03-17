    
using K_12.Entity;
namespace K_12.BLL.Service
{
     
	 public interface IMedicationService : IService<Medication>
    {


    }
    public class MedicationService : Service<Medication>, IMedicationService
    {
        public MedicationService(IMedicationRepository repository) : base(repository)
        {
        }
    }
	 
	          
	

}

