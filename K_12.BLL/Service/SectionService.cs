    
using K_12.Entity;
namespace K_12.BLL.Service
{
     
	 public interface ISectionService : IService<Section>
    {


    }
    public class SectionService : Service<Section>, ISectionService
    {
        public SectionService(ISectionRepository repository) : base(repository)
        {
        }
    }
	 
	          
	

}

