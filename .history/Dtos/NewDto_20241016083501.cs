namespace webapp_1.Dtos;

public record class NewDto(int Id,
 string Name,
 string Genre,
 decimal Price,
 DateOnly ReleaseDate);
