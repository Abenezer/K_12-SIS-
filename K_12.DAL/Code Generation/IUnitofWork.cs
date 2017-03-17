            using System;

public interface IUnitOfWork : IDisposable
{
    ISchoolRepository Schools { get; }
    IStudentParentRepository student_parents { get; }
    IMedicationRepository Medications { get; }

    IApplicationRepository Applications { get; }

    IParentRepository Parents { get; }
    IPhonebookRepository PhoneBooks { get; }
    IDocumentRepository Documents { get; }
    IStudentMedicationRepository student_medications { get; }
    IAddressRepository Addresss { get; }
    ILanguageRepository Languages { get; }
    IStudentRepository Students { get; }
    IContactRepository Contacts { get; }
    IGradeInfoRepository Grade_Infos { get; }
    void Save();
System.Threading.Tasks.Task<int> SaveAsync();
    
}
