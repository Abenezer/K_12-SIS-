using K_12.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_12.BLL.Service
{
    public interface IStudentService : IService<Student>
    {


    }
    public class StudentService : Service<Student>, IStudentService
    {
        public StudentService(IRepository<Student> repository) : base(repository)
        {
        }
    }
}
