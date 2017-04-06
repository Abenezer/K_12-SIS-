    
using K_12.Entity;
namespace K_12.BLL.Service
{
     
	 public interface ISubjectService : IService<Subject>
    {


    }
    public class SubjectService : Service<Subject>, ISubjectService
    {
        public SubjectService(ISubjectRepository repository) : base(repository)
        {
        }
    }
	 
	          
	

}

