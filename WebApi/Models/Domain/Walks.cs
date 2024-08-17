using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApi.Models.Domain;

public class Walks{
 
   public Guid Id { get; set; }


    public string Name { get; set; } = "";

    public string Description { get; set; } = "";

  public double LengthKm { get; set; }

  public string? WalkImageUrl { get; set; }

  public Guid RegionId { get; set; }
 
public Guid DifficultyId { get; set; }

 //Navigations properties
  public Regions Region{ get; set; }

    
    public Difficulty Difficulty{ get; set; }

}