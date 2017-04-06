    
using K_12.Entity;
namespace K_12.BLL.Service
{
     
	 public interface IClassService : IService<Class>
    {


    }
    public class ClassService : Service<Class>, IClassService
    {
        public ClassService(IClassRepository repository) : base(repository)
        {
        }
    }
	 
	          
	

}

