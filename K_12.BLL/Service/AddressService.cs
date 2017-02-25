    
using K_12.Entity;
namespace K_12.BLL.Service
{
     
	 public interface IAddressService : IService<Address>
    {


    }
    public class AddressService : Service<Address>, IAddressService
    {
        public AddressService(IAddressRepository repository) : base(repository)
        {
        }
    }
	 
	          
	

}

