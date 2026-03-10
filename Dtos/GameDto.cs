namespace GameStore.Api.Dtos;

//DTO is a contract between client and server about what will be passed between.

public record GameDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly releaseDate
);

