using MediatR;

namespace ElgamalSandbox.Core.DomainEvents
{
    /// <summary>
    /// Доменное событие
    /// </summary>
    public interface IDomainEvent : INotification;
}
