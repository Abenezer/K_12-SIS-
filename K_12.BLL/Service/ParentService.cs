
using K_12.Entity;
using System.Collections.Generic;
using System.Linq;

namespace K_12.BLL.Service
{
     
	 public interface IParentService : IService<Parent>
    {
     

    }
    public class ParentService : Service<Parent>, IParentService
    {
        public ParentService(IParentRepository repository) : base(repository)
        {
        }



    }
	 
	          
	

}

