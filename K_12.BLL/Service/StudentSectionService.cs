    
using K_12.Entity;
namespace K_12.BLL.Service
{
     
	 public interface IStudentSectionService : IService<student_section>
    {


    }
    public class StudentSectionService : Service<student_section>, IStudentSectionService
    {
        public StudentSectionService(IStudentSectionRepository repository) : base(repository)
        {
        }
    }
	 
	          
	

}

