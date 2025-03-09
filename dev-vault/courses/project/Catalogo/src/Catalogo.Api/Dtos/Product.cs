namespace Catalogo.Api.Dtos;

public sealed record ProductRequest(
    string Name,
    string Description,
    decimal Price,
    Guid CategoryId
);
