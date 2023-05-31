using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using PartnerUp.Identity.People.BusinessLogic.Common.Models.Configurations;
using PartnerUp.Identity.People.BusinessLogic.Interfaces;
using PartnerUp.Identity.Persistence.People.Data.Entities;

namespace PartnerUp.Identity.People.BusinessLogic.Common.Factories;

public class JwtSecurityTokenFactory : IJwtSecurityTokenFactory
{
    private readonly JwtTokenConfiguration _jwtTokenConfiguration;

    public JwtSecurityTokenFactory(JwtTokenConfiguration jwtTokenConfiguration) =>
        _jwtTokenConfiguration = jwtTokenConfiguration;

    public JwtSecurityToken BuildToken(User user) => new(
        _jwtTokenConfiguration.Issuer,
        _jwtTokenConfiguration.Audience,
        GetClaims(user),
        expires: JwtTokenConfiguration.ExpirationDate,
        signingCredentials: _jwtTokenConfiguration.Credentials);

    private static IEnumerable<Claim> GetClaims(User user) => new List<Claim>
    {
        new(JwtRegisteredClaimNames.UniqueName, user.UserName),
        new(ClaimTypes.Name, user.UserName),
        new(ClaimTypes.Authentication, user.Id.ToString())
    };
}
