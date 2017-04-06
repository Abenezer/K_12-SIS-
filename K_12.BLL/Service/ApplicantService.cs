    
using K_12.Entity;
namespace K_12.BLL.Service
{
     
	 public interface IApplicantService : IService<Applicant>
    {


    }
    public class ApplicantService : Service<Applicant>, IApplicantService
    {
        public ApplicantService(IApplicantRepository repository) : base(repository)
        {
        }
    }
	 
	          
	

}

