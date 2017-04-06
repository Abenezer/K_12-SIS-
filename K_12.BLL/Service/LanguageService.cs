    
using K_12.Entity;
namespace K_12.BLL.Service
{
     
	 public interface ILanguageService : IService<Language>
    {


    }
    public class LanguageService : Service<Language>, ILanguageService
    {
        public LanguageService(ILanguageRepository repository) : base(repository)
        {
        }
    }
	 
	          
	

}

