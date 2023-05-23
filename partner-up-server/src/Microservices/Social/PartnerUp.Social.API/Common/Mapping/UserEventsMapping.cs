using AutoMapper;
using PartnerUp.EventBus.Messages;
using PartnerUp.Social.DataAccess.Data.Entities;

namespace PartnerUp.Social.API.Common.Mapping;

public class UserEventsMapping : Profile
{
    public UserEventsMapping()
    {
        CreateMap<UserCreatedEvent, UserProfile>()
            .ForMember(profile => profile.Avatar, configuration => configuration.Ignore());
    }
}
