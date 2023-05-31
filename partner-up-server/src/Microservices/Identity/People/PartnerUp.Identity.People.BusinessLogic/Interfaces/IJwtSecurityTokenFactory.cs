using System.IdentityModel.Tokens.Jwt;
using PartnerUp.Identity.Persistence.People.Data.Entities;

namespace PartnerUp.Identity.People.BusinessLogic.Interfaces;

public interface IJwtSecurityTokenFactory
{
    JwtSecurityToken BuildToken(User user);
}
