using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Domain;

public class Difficulty{

    public   Guid Id { get; set; }
    public string Name { get; set; } = "";
}