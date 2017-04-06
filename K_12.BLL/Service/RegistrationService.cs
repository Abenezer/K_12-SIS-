
using K_12.Entity;
using System.Collections.Generic;
using System.Linq;

namespace K_12.BLL.Service
{
     
	 public interface IRegistrationService : IService<Registration>
    {

        IQueryable<Student> GetRegisteredStudents(int Grade_ID);
    }
    public class RegistrationService : Service<Registration>, IRegistrationService
    {
        public RegistrationService(IRegistrationRepository repository) : base(repository)
        {
        }


        public IQueryable<Student> GetRegisteredStudents(int Grade_ID)
        {
            return Queryable().Where(r => r.grade_id == Grade_ID).Select(r => r.Student); 

        }
 
    }
	 
	          
	

}

