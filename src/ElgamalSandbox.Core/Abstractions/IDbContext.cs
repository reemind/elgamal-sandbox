using ElgamalSandbox.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElgamalSandbox.Core.Abstractions
{
    /// <summary>
    /// Контекст EF Core для приложения
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// Пользователи
        /// </summary>
        DbSet<User> Users { get; }

        /// <summary>
        /// Роли
        /// </summary>
        DbSet<Role> Roles { get; }

        /// <summary>
        /// БД в памяти
        /// </summary>
        bool IsInMemory { get; }

        /// <summary>
        /// Очистить UnitOfWork
        /// </summary>
        void Clean();

        /// <summary>
        /// Сохранить изменения в БД
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">Применить изменения при успешном сохранении в контекст</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Количество обновленных записей</returns>
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

        /// <summary>
        /// Сохранить изменения в БД
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Количество обновленных записей</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
