using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.DTO;

public class AddRegionRequestDto{

       [Required]
       [MaxLength(3,ErrorMessage ="Code character Maximum Should be 3")]
       [MinLength(3,ErrorMessage ="Code character Maximum Should be 3")]

    public string Code { get; set; } = "";
[Required]
[MaxLength(100)]
    public string name { get; set; } = "";
    public string? RegionImageUrl { get; set; }
    

}