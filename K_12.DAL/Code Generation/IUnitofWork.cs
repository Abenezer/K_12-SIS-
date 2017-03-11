            using System;

public interface IUnitOfWork : IDisposable
{
    IPhonebookRepository PhoneBooks { get; }
   
    IGradeInfoRepository Grade_Infos { get; }
    IDocumentRepository Documents { get; }
    IContactRepository Contacts { get; }
   
    IApplicantRepository Applicants { get; }
    IAddressRepository Addresss { get; }
    void Save();
System.Threading.Tasks.Task<int> SaveAsync();
    
}
