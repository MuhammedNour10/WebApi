
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Domain;

public class Regions{


    public Guid Id { get; set; }
      
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";
    public string? RegionImageUrl { get; set; }
    

}