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
	public UnitOfWork()
	{
		_context = new K_12Entities();
	}
	
    public IParentRepository Parents
    {
        get { return new ParentRepository(_context); }
    }

    public IAddressRepository Addresss
    {
        get { return new AddressRepository(_context); }
    }

    public IStudentRepository Students
    {
        get { return new StudentRepository(_context); }
    }

    
    public void Save()
    {
        _context.SaveChanges();
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
