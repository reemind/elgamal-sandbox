using ElgamalSandbox.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElgamalSandbox.Data.SqLite.Configurations;

/// <summary>
/// 
/// </summary>
internal class PerformanceTestConfiguration : EntityBaseConfiguration<PerformanceTest>
{
    /// <inheritdoc />
    public override void ConfigureChild(EntityTypeBuilder<PerformanceTest> builder)
    {
    }
}