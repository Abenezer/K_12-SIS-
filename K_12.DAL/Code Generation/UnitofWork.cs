using System;
using K_12.Entity;
using System.Data.Entity.Validation;
using System.Linq;

public class UnitOfWork : IUnitOfWork
{
    private K_12Entities _context;

    public UnitOfWork(K_12Entities context)
    {
        _context = context;
    }

	//Delete this default constructor if using an IoC container
	//public UnitOfWork()
	//{
		//_context = new K_12Entities();
	//}
	
    public IPhonebookRepository PhoneBooks
    {
        get { return new PhonebookRepository(_context); }
    }

 

    public IGradeInfoRepository Grade_Infos
    {
        get { return new GradeInfoRepository(_context); }
    }

    public IDocumentRepository Documents
    {
        get { return new DocumentRepository(_context); }
    }

    public IContactRepository Contacts
    {
        get { return new ContactRepository(_context); }
    }


    public IApplicantRepository Applicants
    {
        get { return new ApplicantRepository(_context); }
    }

    public IAddressRepository Addresss
    {
        get { return new AddressRepository(_context); }
    }

    
    public void Save()
    {
        //_context.SaveChanges();

        try
        {
          _context.SaveChanges();
        }
        catch (DbEntityValidationException ex)
        {
            // Retrieve the error messages as a list of strings.
            var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

            // Join the list to a single string.
            var fullErrorMessage = string.Join("; ", errorMessages);

            // Combine the original exception message with the new one.
            var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

            // Throw a new DbEntityValidationException with the improved exception message.
            throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
        }




    }

	 public System.Threading.Tasks.Task<int> SaveAsync()
    {
       return _context.SaveChangesAsync();

    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}
