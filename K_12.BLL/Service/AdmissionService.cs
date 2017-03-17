using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_12.BLL.Service
{

    public interface IAdmissionService
    {
        IStudentService StudentService { get; }
        IParentService ParentService { get; }



    }

    public class AdmissionService : IAdmissionService
    {
        private IStudentService _studentService ;
        private IParentService _parentService;

        public AdmissionService(IStudentService studnetService, IParentService parentService)
        {
            _studentService = studnetService;
            _parentService = parentService;

           
            
        }


        public IParentService ParentService
        {
            get
            {
                return _parentService;
            }
        }

        public IStudentService StudentService
        {
            get
            {
                return _studentService;
            }
        }
    }
}
