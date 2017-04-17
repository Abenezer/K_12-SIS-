
using K_12.Entity;
using System.Collections.Generic;
using System.Linq;

namespace K_12.BLL.Service
{
     
	 public interface IStaffService : IService<Staff>
    {

        IQueryable<Staff> GetPendingStaffs();
    }
    public class StaffService : Service<Staff>, IStaffService
    {
        public StaffService(IStaffRepository repository) : base(repository)
        {
        }

        public IQueryable<Staff> GetPendingStaffs ()
        {
           return  Queryable().Where(s => s.Status == Constants.StaffStatus.PENDING);
            
        }
    }
	 
	          
	

}

