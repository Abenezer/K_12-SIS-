    
using K_12.Entity;
namespace K_12.BLL.Service
{
     
	 public interface IDocumentService : IService<Document>
    {


    }
    public class DocumentService : Service<Document>, IDocumentService
    {
        public DocumentService(IDocumentRepository repository) : base(repository)
        {
        }
    }
	 
	          
	

}

