using ElgamalSandbox.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElgamalSandbox.Data.Postgres.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    private const string GuidCommand = "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)";

    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired()
            .HasDefaultValueSql(GuidCommand);

        builder.HasData(
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "Teacher",
                NormalizedName = "TEACHER"
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "Student",
                NormalizedName = "STUDENT"
            });
    }
}