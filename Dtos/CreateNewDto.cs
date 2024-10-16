namespace webapp_1.Dtos;

public record class CreateNewDto(
 string Name,
 string Genre,
 decimal Price,
 DateOnly ReleaseDate
);
