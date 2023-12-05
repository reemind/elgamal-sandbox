using ElgamalSandbox.Core.Abstractions;
using System;

namespace ElgamalSandbox.Data.Migrator
{
    /// <summary>
    /// Мок юзерконтекста для контекста БД
    /// </summary>
    internal class UserContext : IUserContext
    {
        /// <inheritdoc/>
        public Guid CurrentUserId => throw new NotImplementedException();

        /// <inheritdoc />
        public string UserName => throw new NotImplementedException();
    }
}
