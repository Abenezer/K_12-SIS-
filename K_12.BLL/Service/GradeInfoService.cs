    
using K_12.Entity;
namespace K_12.BLL.Service
{
     
	 public interface IGradeInfoService : IService<Grade_Info>
    {


    }
    public class GradeInfoService : Service<Grade_Info>, IGradeInfoService
    {
        public GradeInfoService(IGradeInfoRepository repository) : base(repository)
        {
        }
    }
	 
	          
	

}

