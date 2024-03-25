using ElgamalSandbox.Core.Entities;
using ElgamalSandbox.Data.SqLite.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElgamalSandbox.Data.SqLite.Configurations;

/// <summary>
/// 
/// </summary>
internal class PerformanceTestAttemptConfiguration : EntityBaseConfiguration<PerformanceTestAttempt>
{
    /// <inheritdoc />
    public override void ConfigureChild(EntityTypeBuilder<PerformanceTestAttempt> builder)
    {
        builder.Property(x => x.Runs)
            .HasJsonConversion();
    }
}