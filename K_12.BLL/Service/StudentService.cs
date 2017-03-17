    
using K_12.Entity;
namespace K_12.BLL.Service
{
     
	 public interface IStudentService : IService<Student>
    {


    }
    public class StudentService : Service<Student>, IStudentService
    {
        public StudentService(IStudentRepository repository) : base(repository)
        {
        }
    }
	 
	          
	

}

