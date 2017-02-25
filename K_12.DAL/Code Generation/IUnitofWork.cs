            using System;

public interface IUnitOfWork : IDisposable
{
    IPhonebookRepository PhoneBooks { get; }
    IGradeInfoRepository Grade_Infos { get; }
    IDocumentRepository Documents { get; }
    IContactRepository Contacts { get; }
    IApplicationRepository Applications { get; }
    IAddressRepository Addresss { get; }
    void Save();
System.Threading.Tasks.Task<int> SaveAsync();
    
}
