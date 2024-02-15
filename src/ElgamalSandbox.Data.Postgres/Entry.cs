﻿using ElgamalSandbox.Core.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ElgamalSandbox.Data.SqLite
{
    /// <summary>
	/// Класс - входная точка проекта, регистрирующий реализованные зависимости текущим проектом
	/// </summary>
	public static class Entry
    {
        /// <summary>
        /// Добавить службы проекта с SqLite
        /// </summary>
        /// <param name="services">Коллекция служб</param>
        /// <param name="optionsAction">Параметры подключения к SqLite</param>
        /// <returns>Обновленная коллекция служб</returns>
        public static IServiceCollection AddSqLite(
            this IServiceCollection services,
            Action<SqLiteDbOptions>? optionsAction)
        {
            var options = new SqLiteDbOptions();
            optionsAction?.Invoke(options);

            return services.AddSqLite(options);
        }

        /// <summary>
        /// Добавить службы проекта с SqLite
        /// </summary>
        /// <param name="services">Коллекция служб</param>
        /// <param name="options">Конфиг подключения к SqLite</param>
        /// <returns>Обновленная коллекция служб</returns>
        public static IServiceCollection AddSqLite(
            this IServiceCollection services,
            SqLiteDbOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            if (string.IsNullOrWhiteSpace(options.Path))
                throw new ArgumentException(nameof(options.Path));

            services.AddDbContext<EfContext>(opt =>
            {
                if (options?.SqlLoggerFactory != null)
                    opt.UseLoggerFactory(options.SqlLoggerFactory);
                opt.UseSqlite($"Data Source={options!.Path}");
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                opt.UseSnakeCaseNamingConvention();
                opt.EnableSensitiveDataLogging();
            });

            services.AddTransient<DbMigrator>();
            services.AddScoped<IDbContext>(x => x.GetRequiredService<EfContext>());

            return services;
        }
    }
}