using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using WebApi.Models.Domain;

namespace WebApi.Models.DTO;

public class AddWalkDto{



[Required]
[MaxLength(50)]
    public string Name { get; set; } = "";
[Required]
[MaxLength(100)]
    public string Description { get; set; } = "";
 [Required]
 [Range(1,1000)]
   public double LengthKm { get; set; }

  public string? WalkImageUrl { get; set; }
[Required]
  public Guid RegionId { get; set; }
 [Required]
public Guid DifficultyId { get; set; }



}