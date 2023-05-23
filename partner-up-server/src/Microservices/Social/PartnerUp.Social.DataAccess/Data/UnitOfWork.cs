using PartnerUp.Social.DataAccess.Interfaces.Data;
using PartnerUp.Social.DataAccess.Interfaces.Data.Repositories;

namespace PartnerUp.Social.DataAccess.Data;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IRatingsRepository ratingsRepository, IFriendsRepository friendsRepository)
    {
        RatingsRepository = ratingsRepository;
        FriendsRepository = friendsRepository;
    }

    public IRatingsRepository RatingsRepository { get; }
    public IFriendsRepository FriendsRepository { get; }
}
