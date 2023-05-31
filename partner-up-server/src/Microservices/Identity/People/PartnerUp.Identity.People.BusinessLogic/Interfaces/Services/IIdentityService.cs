using PartnerUp.Identity.People.BusinessLogic.Common.Models.Requests;
using PartnerUp.Identity.People.BusinessLogic.Common.Models.Responses;

namespace PartnerUp.Identity.People.BusinessLogic.Interfaces.Services;

public interface IIdentityService
{
    Task<JwtResponse> SignInAsync(UserSignInRequest request);
    Task<JwtResponse> SignUpAsync(UserSignUpRequest request);
}
