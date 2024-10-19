using System.ComponentModel.DataAnnotations;

namespace webapp_1.Dtos;

public record class UpdateDto(
 [Required][StringLength(50)]string Name,
 [Required][StringLength(50)]string Genre,
 [Range(1,500)]decimal Price,
 DateOnly ReleaseDate
);