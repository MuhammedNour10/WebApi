using Microsoft.AspNetCore.Identity;

namespace WebApi.Repository.IRepository;

  public interface ITokenService
    {
        string GenerateToken(IdentityUser user,List<string> roles);
    }
