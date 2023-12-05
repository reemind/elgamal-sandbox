using ElgamalSandbox.Core.Abstractions;

namespace ElgamalSandbox.Web.Authorization;

public class UserContext : IUserContext
{
    /// <inheritdoc />
    public Guid CurrentUserId { get; }

    /// <inheritdoc />
    public string? UserName { get; }
}