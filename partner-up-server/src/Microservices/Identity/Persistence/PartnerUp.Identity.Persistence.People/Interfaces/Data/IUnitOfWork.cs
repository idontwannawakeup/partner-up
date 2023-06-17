using PartnerUp.Identity.Persistence.People.Interfaces.Data.Repositories;

namespace PartnerUp.Identity.Persistence.People.Interfaces.Data;

public interface IUnitOfWork
{
    IUsersRepository UsersRepository { get; set; }

    Task SaveChangesAsync();
}
