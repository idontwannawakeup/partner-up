using PartnerUp.Social.DataAccess.Interfaces.Data.Repositories;

namespace PartnerUp.Social.DataAccess.Interfaces.Data;

public interface IUnitOfWork
{
    IRatingsRepository RatingsRepository { get; }
    IFriendsRepository FriendsRepository { get; }
}
