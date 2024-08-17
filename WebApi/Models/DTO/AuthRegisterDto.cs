using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace WebApi.Models.DTO;


public class AuthRigesterDto{
      [Required]
      
    public string username { get; set; } = "";
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = "";
[Required]
  [DataType(DataType.Password)]
    public string Password { get; set; } = "";

    public string[] Roles { get; set; }

}