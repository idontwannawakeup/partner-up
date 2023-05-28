using AutoMapper;
using PartnerUp.EventBus.Messages;
using PartnerUp.Identity.People.BusinessLogic.Common.Models.Requests;
using PartnerUp.Identity.People.BusinessLogic.Common.Models.Responses;

namespace PartnerUp.Identity.People.API.Common.Mapping;

public class UserEventsMapping : Profile
{
    public UserEventsMapping()
    {
        CreateMap<UserSignUpRequest, UserCreatedEvent>();
        CreateMap<UserResponse, UserChangedEvent>();
    }
}
