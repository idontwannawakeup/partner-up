using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PartnerUp.Identity.Persistence.People.Data.Entities;
using PartnerUp.Social.DataAccess;
using PartnerUp.WorkManagement.Domain.Entities;
using PartnerUp.WorkManagement.Persistence;
using WorkUserProfile = PartnerUp.WorkManagement.Domain.Entities.UserProfile;
using SocialUserProfile = PartnerUp.Social.DataAccess.Data.Entities.UserProfile;

namespace PartnerUp.Recommendations.Seeding.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeedingController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly WorkManagementDbContext _workContext;
    private readonly SocialDbContext _socialContext;

    public SeedingController(UserManager<User> userManager, WorkManagementDbContext workContext, SocialDbContext socialContext)
    {
        _userManager = userManager;
        _workContext = workContext;
        _socialContext = socialContext;
    }

    [HttpPost]
    public async Task Seed()
    {
        var faker = new Faker();

        // Define the professions and specializations
        var professions = new[] { "Software Engineer", "Software Architect", "Project Manager", "QA" };
        var specializations = new[] { "Backend", "Frontend", null };  // null for Project Manager
        var userAvatars = new[] { null, "202306172139282940.jpg", "1.jpg", "2.jpeg", "3.png", "4.jpeg", "5.png" };

        // Generating a list of 100 users
        var users = new List<User>();
        for (int id = 1; id <= 100; id++)
        {
            var profession = faker.PickRandom(professions);

            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                Profession = profession,
                Specialization = profession == "Project Manager" ? null : faker.PickRandom(specializations),
                Email = faker.Internet.Email(),
                UserName = faker.Internet.UserName(),
                NormalizedUserName = faker.Internet.UserName().ToUpper(),
                NormalizedEmail = faker.Internet.Email().ToUpper(),
                EmailConfirmed = faker.Random.Bool(),
                PhoneNumber = faker.Phone.PhoneNumber(),
                PhoneNumberConfirmed = faker.Random.Bool(),
                Avatar = faker.PickRandom(userAvatars),
            };

            var workUserProfile = new WorkUserProfile
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Profession = user.Profession,
                Specialization = user.Specialization,
                Avatar = user.Avatar,
            };

            var socialUserProfile = new SocialUserProfile
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Profession = user.Profession,
                Specialization = user.Specialization,
                Avatar = user.Avatar,
            };

            users.Add(user);
            await _userManager.CreateAsync(user, "Seed1234!");

            await _socialContext.UserProfiles.AddAsync(socialUserProfile);
            await _socialContext.SaveChangesAsync();

            await _workContext.UserProfiles.AddAsync(workUserProfile);
            await _workContext.SaveChangesAsync();
        }
    }
}
