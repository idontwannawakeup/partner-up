using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PartnerUp.Shared.Interfaces;

public interface ISeeder<T> where T : class
{
    void Seed(EntityTypeBuilder<T> builder);
}

public interface ISeeder
{
    void Seed(EntityTypeBuilder builder);
}
