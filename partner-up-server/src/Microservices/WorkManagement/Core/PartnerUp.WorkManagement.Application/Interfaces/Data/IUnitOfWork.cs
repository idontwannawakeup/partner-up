using PartnerUp.WorkManagement.Application.Interfaces.Data.Repositories;

namespace PartnerUp.WorkManagement.Application.Interfaces.Data;

public interface IUnitOfWork
{
    IProjectsRepository ProjectsRepository { get; }
    ITeamsRepository TeamsRepository { get; }
    ITicketsRepository TicketsRepository { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
