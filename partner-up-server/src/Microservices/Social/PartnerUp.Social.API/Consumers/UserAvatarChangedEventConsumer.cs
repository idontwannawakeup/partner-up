using MassTransit;
using PartnerUp.EventBus.Messages;
using PartnerUp.Social.DataAccess;

namespace PartnerUp.Social.API.Consumers;

public class UserAvatarChangedEventConsumer : IConsumer<UserAvatarChangedEvent>
{
    private readonly SocialDbContext _dbContext;

    public UserAvatarChangedEventConsumer(SocialDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Consume(ConsumeContext<UserAvatarChangedEvent> context)
    {
        var userProfile = await _dbContext.UserProfiles.FindAsync(context.Message.UserId);
        userProfile!.Avatar = context.Message.Avatar;
        _dbContext.UserProfiles.Update(userProfile);
        await _dbContext.SaveChangesAsync();
    }
}

