using ElgamalSandbox.Core.Entities;
using ElgamalSandbox.Data.SqLite.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElgamalSandbox.Data.SqLite.Configurations;

internal class TaskDescriptionConfiguration : EntityBaseConfiguration<TaskDescription>
{
    /// <inheritdoc />
    public override void ConfigureChild(EntityTypeBuilder<TaskDescription> builder)
    {
        builder.Property(x => x.Toolbox)
            .HasJsonConversion();

        builder.Property(x => x.Playground);

        builder.HasMany(x => x.Attempts)
            .WithOne(x => x.TaskDescription)
            .HasForeignKey(x => x.TaskDescriptionId)
            .HasPrincipalKey(x => x.Id);

        builder.HasMany(x => x.Tests)
            .WithOne(x => x.Task)
            .HasForeignKey(x => x.TaskId)
            .HasPrincipalKey(x => x.Id);
    }
}