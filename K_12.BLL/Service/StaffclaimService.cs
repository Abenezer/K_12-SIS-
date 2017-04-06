    
using K_12.Entity;
namespace K_12.BLL.Service
{
     
	 public interface IStaffclaimService : IService<StaffClaim>
    {


    }
    public class StaffclaimService : Service<StaffClaim>, IStaffclaimService
    {
        public StaffclaimService(IStaffclaimRepository repository) : base(repository)
        {
        }
    }
	 
	          
	

}

