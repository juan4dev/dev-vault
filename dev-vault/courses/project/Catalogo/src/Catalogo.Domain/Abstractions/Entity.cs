namespace Catalogo.Domain.Abstractions;

public abstract class Entity(Guid id)
{
    private readonly List<IDomainEvents> _domainEvents = [];

    public Guid Id { get; set; } = id;

    public IReadOnlyList<IDomainEvents> DomainEvents => _domainEvents.ToList();

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public void RaiseDomainEvent(IDomainEvents domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}