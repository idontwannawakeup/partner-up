using AutoMapper;
using PartnerUp.EventBus.Messages;
using PartnerUp.WorkManagement.Domain.Entities;

namespace PartnerUp.WorkManagement.API.Common.Mapping;

public class UserEventsMapping : Profile
{
    public UserEventsMapping()
    {
        CreateMap<UserCreatedEvent, UserProfile>()
            .ForMember(profile => profile.Avatar, configuration => configuration.Ignore());
    }
}
