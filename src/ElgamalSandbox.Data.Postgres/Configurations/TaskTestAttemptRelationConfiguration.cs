using ElgamalSandbox.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElgamalSandbox.Data.SqLite.Configurations;

public class TaskTestAttemptRelationConfiguration : IEntityTypeConfiguration<TaskTestAttemptRelation>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<TaskTestAttemptRelation> builder)
    {
        builder.HasKey(x => new { x.AttemptId, x.TestId });

        builder.HasOne(x => x.Attempt)
            .WithMany(x => x.Tests)
            .HasForeignKey(x => x.AttemptId)
            .HasPrincipalKey(x => x.Id);

        builder.HasOne(x => x.Test)
            .WithMany(x => x.Attempts)
            .HasForeignKey(x => x.TestId)
            .HasPrincipalKey(x => x.Id);
    }
}