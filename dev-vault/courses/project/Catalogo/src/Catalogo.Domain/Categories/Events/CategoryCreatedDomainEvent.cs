using Catalogo.Domain.Abstractions;

namespace Catalogo.Domain.Categories.Events;

public sealed record CategoryCreatedEvent(Guid CategoryId) : IDomainEvents;