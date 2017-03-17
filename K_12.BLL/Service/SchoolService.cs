    
using K_12.Entity;
namespace K_12.BLL.Service
{
     
	 public interface ISchoolService : IService<School>
    {


    }
    public class SchoolService : Service<School>, ISchoolService
    {
        public SchoolService(ISchoolRepository repository) : base(repository)
        {
        }
    }
	 
	          
	

}

