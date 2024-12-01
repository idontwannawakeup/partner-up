using System.Globalization;
using System.Text.Json;
using Bogus;
using CsvHelper;
using PartnerUp.Identity.Persistence.People;
using PartnerUp.Identity.Persistence.People.Data.Entities;
using PartnerUp.Identity.Persistence.People.Data.Seeders;
using PartnerUp.Social.DataAccess;
using PartnerUp.WorkManagement.Persistence;
using WorkUserProfile = PartnerUp.WorkManagement.Domain.Entities.UserProfile;
using SocialUserProfile = PartnerUp.Social.DataAccess.Data.Entities.UserProfile;

namespace PartnerUp.Recommendations.Seeding;

public class UserSeeder
{
    public static void SeedUsersForRecommendations(PeopleDbContext context, WorkManagementDbContext workContext, SocialDbContext socialContext)
    {
        List<RecommendationUser> recommendationsUsers;
        using (var reader = new StreamReader("recommendation-users.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<RecommendationUser>();
            recommendationsUsers = records.ToList();
        }

        var users = recommendationsUsers.Select((item, index) =>
        {
            var faker = new Faker();
            var firstName = faker.Person.FirstName;
            var lastName = faker.Person.LastName;
            var username = $"{faker.Internet.UserName(firstName, lastName)}_i{index}";
            var email = faker.Internet.Email(firstName, lastName);
            var normalizedUsername = username.ToUpperInvariant();
            var normalizedEmail = email.ToUpperInvariant();

            var trimmedSkills = item.Skills.Trim('"').Replace("\'", "\"");
            var skills = JsonSerializer.Deserialize<string[]>(trimmedSkills) ?? Array.Empty<string>();

            return new User
            {
                Id = Guid.NewGuid(),
                UserName = username,
                NormalizedUserName = normalizedUsername,
                Email = email,
                NormalizedEmail = normalizedEmail,
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEHIJxNS71yM2C19K8pJktzIg+gOfmz3ySn59bRPhmSrkabIMpXGGzKjZjhnEjFKqSA==",
                ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                SecurityStamp = Guid.NewGuid().ToString("D"),
                FirstName = firstName,
                LastName = lastName,
                Profession = item.JobTitle,
                Specialization = string.Join(", ", skills),
                RecommendationId = Guid.Parse(item.RecommendationId),
            };
        }).ToList();

        var workUserProfiles = users.Select(user => new WorkUserProfile
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Profession = user.Profession,
            Specialization = user.Specialization,
            Avatar = user.Avatar,
        }).ToList();

        var socialUserProfiles = users.Select(user => new SocialUserProfile
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Profession = user.Profession,
            Specialization = user.Specialization,
            Avatar = user.Avatar,
        }).ToList();

        context.Users.AddRange(users);

        socialContext.UserProfiles.AddRange(socialUserProfiles);

        workContext.UserProfiles.AddRange(workUserProfiles);
    }
}
