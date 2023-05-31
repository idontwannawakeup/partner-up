using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace PartnerUp.Identity.People.BusinessLogic.Common.Models.Configurations;


public class JwtTokenConfiguration
{
    public string? Issuer => null;
    public string? Audience => null;
    public static DateTime ExpirationDate => DateTime.UtcNow.AddYears(1);

    public SymmetricSecurityKey Key =>
        new(Encoding.UTF8.GetBytes("JwtSecurityKeyJwtSecurityKeyJwtSecurityKey"));

    public SigningCredentials Credentials =>
        new(Key, SecurityAlgorithms.HmacSha256);
}
