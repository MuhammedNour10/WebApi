using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.DTO;


public class LoginRequestDto{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = "";
       [Required]
       [DataType(DataType.Password)]
    public string Password { get; set; } = "";
}