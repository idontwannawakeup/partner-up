using CsvHelper.Configuration.Attributes;

namespace PartnerUp.Identity.Persistence.People.Data.Seeders;

public class RecommendationUser
{
    [Index(7)]
    public string RecommendationId { get; set; }

    [Index(4)]
    public string JobTitle { get; set; }

    [Index(5)]
    public string Skills { get; set; }
}
