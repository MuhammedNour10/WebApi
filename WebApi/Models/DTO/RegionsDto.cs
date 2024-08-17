using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.DTO;

public class RegionsDTO{

    public Guid Id { get; set; }

    public string Code { get; set; } = "";

    public string name { get; set; } = "";
    public string? RegionImageUrl { get; set; }
    

}