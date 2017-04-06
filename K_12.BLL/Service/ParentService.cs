
using K_12.Entity;
using System.Collections.Generic;
using System.Linq;

namespace K_12.BLL.Service
{
     
	 public interface IParentService : IService<Parent>
    {
        Parent GetParentByUserID(string user_id);

    }
    public class ParentService : Service<Parent>, IParentService
    {
        public ParentService(IParentRepository repository) : base(repository)
        {
        }

        public Parent GetParentByUserID(string user_id)
        {
            return  Queryable().Where(p => p.user_id == user_id).First();
        }


    }
	 
	          
	

}

