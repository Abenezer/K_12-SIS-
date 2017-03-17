    
using K_12.Entity;
namespace K_12.BLL.Service
{
     
	 public interface IStudentParentService : IService<student_parent>
    {


    }
    public class StudentParentService : Service<student_parent>, IStudentParentService
    {
        public StudentParentService(IStudentParentRepository repository) : base(repository)
        {
        }
    }
	 
	          
	

}

