using ElgamalSandbox.Core.Entities;
using ElgamalSandbox.Data.SqLite.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElgamalSandbox.Data.SqLite.Configurations;

internal class TaskTestConfiguration : EntityBaseConfiguration<TaskTest>
{
    /// <inheritdoc />
    public override void ConfigureChild(EntityTypeBuilder<TaskTest> builder)
    {
        builder.Property(x => x.InputVars).HasJsonConversion();
        builder.Property(x => x.OutputVars).HasJsonConversion();

        builder.Property(x => x.TaskId);

        builder.HasOne(x => x.Task)
            .WithMany(x => x.Tests)
            .HasForeignKey(x => x.TaskId)
            .HasPrincipalKey(x => x.Id);

        builder.HasMany(x => x.Attempts)
            .WithOne(x => x.Test)
            .HasForeignKey(x => x.TestId)
            .HasPrincipalKey(x => x.Id);

        builder.SetPropertyAccessModeField(x => x.Task, TaskTest.TaskField);
    }
}