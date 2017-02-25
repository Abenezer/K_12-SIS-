    
using K_12.Entity;
namespace K_12.BLL.Service
{
     
	 public interface IContactService : IService<Contact>
    {


    }
    public class ContactService : Service<Contact>, IContactService
    {
        public ContactService(IContactRepository repository) : base(repository)
        {
        }
    }
	 
	          
	

}

