using ElgamalSandbox.Core.Entities;
using ElgamalSandbox.Data.SqLite.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElgamalSandbox.Data.SqLite.Configurations;

internal class TaskAttemptConfiguration : EntityBaseConfiguration<TaskAttempt>
{
    /// <inheritdoc />
    public override void ConfigureChild(EntityTypeBuilder<TaskAttempt> builder)
    {
        builder.Property(x => x.Parameters)
            .HasJsonConversion();

        builder.Property(x => x.Playground)
            .HasJsonConversion();

        builder.HasOne(x => x.TaskDescription)
            .WithMany(x => x.Attempts)
            .HasForeignKey(x => x.TaskDescriptionId)
            .HasPrincipalKey(x => x.Id);

        builder.SetPropertyAccessModeField(x => x.TaskDescription, TaskAttempt.TaskDescriptionField);
    }
}