namespace PartnerUp.WebClient.ViewModels;

public class UserViewModel
{
    public Guid Id { get; set; }

    public string UserName { get; set; }

    public string FullName { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Profession { get; set; }

    public string Specialization { get; set; }

    public string SpecializationTrimmed =>
        Specialization.Length <= 49 ? Specialization : Specialization.Substring(0, 49) + "...";

    public string Avatar { get; set; }
}
