    
using K_12.Entity;
namespace K_12.BLL.Service
{
     
	 public interface IApplicationService : IService<Application>
    {


    }
    public class ApplicationService : Service<Application>, IApplicationService
    {
        public ApplicationService(IApplicationRepository repository) : base(repository)
        {
        }
    }
	 
	          
	

}

