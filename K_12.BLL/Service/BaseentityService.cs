    
using K_12.Entity;
namespace K_12.BLL.Service
{
     
	 public interface IBaseentityService : IService<BaseEntity>
    {


    }
    public class BaseentityService : Service<BaseEntity>, IBaseentityService
    {
        public BaseentityService(IBaseentityRepository repository) : base(repository)
        {
        }
    }
	 
	          
	

}

