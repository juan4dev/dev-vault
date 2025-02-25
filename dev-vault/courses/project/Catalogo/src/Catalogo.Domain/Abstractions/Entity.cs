namespace Catalogo.Domain.Abstractions;

public abstract class Entity
{

    private readonly List<IDomainEvents> _domainEvents = [];

    public Guid Id { get; set; }

    protected Entity(Guid id)
    {
        Id = id;
    }

    public IReadOnlyList<IDomainEvents> DomainEvents => _domainEvents;

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void AddDomainEvent(IDomainEvents domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}