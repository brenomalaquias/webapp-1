namespace webapp_1.Dtos;

public record class CreateNewDto(
 int Id,
 string Name,
 string Genre,
 decimal Price,
 DateOnly ReleaseDate
);
