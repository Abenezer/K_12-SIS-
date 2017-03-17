using System;
using K_12.Entity;

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
	
    public ISchoolRepository Schools
    {
        get { return new SchoolRepository(_context); }
    }

    public IStudentParentRepository student_parents
    {
        get { return new StudentParentRepository(_context); }
    }

    public IMedicationRepository Medications
    {
        get { return new MedicationRepository(_context); }
    }

    public IApplicantRepository Applicants
    {
        get { return new ApplicantRepository(_context); }
    }


    public IApplicationRepository Applications
    {
        get { return new ApplicationRepository(_context); }
    }


    public IParentRepository Parents
    {
        get { return new ParentRepository(_context); }
    }

    public IPhonebookRepository PhoneBooks
    {
        get { return new PhonebookRepository(_context); }
    }

    public IDocumentRepository Documents
    {
        get { return new DocumentRepository(_context); }
    }

    public IStudentMedicationRepository student_medications
    {
        get { return new StudentMedicationRepository(_context); }
    }

    public IAddressRepository Addresss
    {
        get { return new AddressRepository(_context); }
    }

    public ILanguageRepository Languages
    {
        get { return new LanguageRepository(_context); }
    }

    public IStudentRepository Students
    {
        get { return new StudentRepository(_context); }
    }

    public IContactRepository Contacts
    {
        get { return new ContactRepository(_context); }
    }

    public IGradeInfoRepository Grade_Infos
    {
        get { return new GradeInfoRepository(_context); }
    }

    
    public void Save()
    {
        _context.SaveChanges();
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
