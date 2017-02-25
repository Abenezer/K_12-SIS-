

    
using K_12.Entity;
namespace K_12.BLL.Service
{
     
	 public interface IPhonebookService : IService<PhoneBook>
    {


    }
    public class PhonebookService : Service<PhoneBook>, IPhonebookService
    {
        public PhonebookService(IPhonebookRepository repository) : base(repository)
        {
        }
    }
	 
	          
	

}

