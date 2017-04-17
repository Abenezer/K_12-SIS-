using K_12.Entity;

public interface IParentRepository : IRepository<Parent>
{
    //Add any additional repository methods other than the generic ones (GetAll, GetById, Delete, Add)

    Parent GetByUserId(string user_id);
}
