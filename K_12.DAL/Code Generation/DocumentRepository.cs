                
using K_12.Entity;
              
public class DocumentRepository : Repository<Document>, IDocumentRepository
{
    private K_12Entities _context;

    public DocumentRepository(K_12Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IDocumentRepository.cs file
}
