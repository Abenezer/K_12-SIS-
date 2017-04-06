    
using K_12.Entity;
namespace K_12.BLL.Service
{
     
	 public interface IActivityService : IService<Activity>
    {


    }
    public class ActivityService : Service<Activity>, IActivityService
    {
        public ActivityService(IActivityRepository repository) : base(repository)
        {
        }
    }
	 
	          
	

}

