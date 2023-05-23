using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PartnerUp.Content.Domain.Entities;

namespace PartnerUp.Content.Persistence.Data.Configurations;

public class RecentRequestConfiguration : IEntityTypeConfiguration<RecentRequest>
{
    public void Configure(EntityTypeBuilder<RecentRequest> builder)
    {
        builder.HasKey(e => new { UserId = e.UserProfileId, e.RequestedEntityId, e.RecentRequestEntityType });
    }
}
