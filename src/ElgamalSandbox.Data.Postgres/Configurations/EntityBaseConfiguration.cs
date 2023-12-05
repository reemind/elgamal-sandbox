using ElgamalSandbox.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElgamalSandbox.Data.Postgres.Configurations
{
    /// <summary>
    /// Базовая конфигурация для базовой сущности <see cref="EntityBase"/>
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    internal abstract class EntityBaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
         where TEntity : EntityBase
    {
        private const string GuidCommand = "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)";

        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            ConfigureBase(builder);
            ConfigureChild(builder);
        }

        /// <summary>
        /// Конфигурация сущности, не считая полей базового класса  <see cref="EntityBase"/>
        /// </summary>
        /// <param name="builder">Строитель конфигурации</param>
        public abstract void ConfigureChild(EntityTypeBuilder<TEntity> builder);

        private static void ConfigureBase(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired()
                .HasDefaultValueSql(GuidCommand);
        }
    }
}
