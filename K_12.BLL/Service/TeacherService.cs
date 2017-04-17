
using System;
using K_12.Entity;
using System.Linq;

namespace K_12.BLL.Service
{
     
	 public interface ITeacherService : IService<Teacher>
    {
     

    }













    public class TeacherService : Service<Teacher>, ITeacherService
    {
        public TeacherService(ITeacherRepository repository) : base(repository)
        {
        }

       
    }
	 
	          
	

}

