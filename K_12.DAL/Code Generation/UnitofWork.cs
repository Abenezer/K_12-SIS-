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

    public IClassRepository Classs
    {
        get { return new ClassRepository(_context); }
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

    public ISectionRepository Sections
    {
        get { return new SectionRepository(_context); }
    }

    public IBaseentityRepository BaseEntitys
    {
        get { return new BaseentityRepository(_context); }
    }

    public IApplicationRepository Applications
    {
        get { return new ApplicationRepository(_context); }
    }

    public ITeacherRepository Teachers
    {
        get { return new TeacherRepository(_context); }
    }

    public ISubjectRepository Subjects
    {
        get { return new SubjectRepository(_context); }
    }

    public IStaffclaimRepository StaffClaims
    {
        get { return new StaffclaimRepository(_context); }
    }

    public IPersonRepository Persons
    {
        get { return new PersonRepository(_context); }
    }

    public IParentRepository Parents
    {
        get { return new ParentRepository(_context); }
    }

      public IActivityRepository Activitys
    {
        get { return new ActivityRepository(_context); }
    }

    public IRegistrationRepository Registrations
    {
        get { return new RegistrationRepository(_context); }
    }

    public IPhonebookRepository PhoneBooks
    {
        get { return new PhonebookRepository(_context); }
    }

    public IDocumentRepository Documents
    {
        get { return new DocumentRepository(_context); }
    }

    public IStudentSectionRepository student_sections
    {
        get { return new StudentSectionRepository(_context); }
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
