namespace webapp_1.Dtos;

public record class UpdateDto(
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);