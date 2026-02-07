using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PartnerUp.WorkManagement.Persistence.Data.Seeders;
using PartnerUp.WorkManagement.Domain.Entities;

namespace PartnerUp.WorkManagement.Persistence.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.HasKey(user => user.Id);

        builder.Property(user => user.FirstName)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(user => user.LastName)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(user => user.Profession)
               .HasColumnType("nvarchar(max)");

        builder.Property(user => user.Specialization)
               .HasColumnType("nvarchar(max)");

        new UserProfileSeeder().Seed(builder);
    }
}
