namespace Topers_API.Contracts;

public record ItemsResponse
(
    Guid Id,
    string Title,
    string Description,
    Guid CategoryId
);

public record ItemsRequest
(
    Guid CategoryId,
    string Title,
    string Description
);