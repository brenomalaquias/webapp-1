using System.ComponentModel.DataAnnotations;

namespace webapp_1.Dtos;

public record class CreateNewDto(
 [Required][StringLength(50)]string Name,
 int GenreId,
 [Range(1,500)]decimal Price,
 DateOnly ReleaseDate
);
