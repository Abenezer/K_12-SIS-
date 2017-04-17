using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K_12.Entity;

namespace K_12.BLL.Service
{
    public interface IProfileService
    {
        IParentService ParentService { get; }

       

    }


    public class ProfileService: IProfileService
    {

        public ProfileService(IUnitOfWork uw)
        {
            _parentService = new ParentService(uw.Parents);
        }

        private IParentService _parentService; 
       //private iTeacherSErvice 
       
        public IParentService ParentService { get { return _parentService; } }

       
    }
}
