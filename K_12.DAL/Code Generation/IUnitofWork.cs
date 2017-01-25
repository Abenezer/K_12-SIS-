            using System;

public interface IUnitOfWork : IDisposable
{
    IParentRepository Parents { get; }
    IAddressRepository Addresss { get; }
    IStudentRepository Students { get; }
    void Save();
}
