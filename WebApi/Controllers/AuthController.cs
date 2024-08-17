using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.DTO;
using WebApi.Repository.IRepository;

namespace WebApi.Controllers;
[ApiController]
[Route("Api/[controller]")]
public class AuthController:ControllerBase{

    private readonly UserManager<IdentityUser> userManager;
    private readonly ITokenService tokenService;

   public AuthController(UserManager<IdentityUser> userManager,ITokenService tokenService)
    {   
        this.userManager = userManager;
        this.tokenService = tokenService;
    }

[HttpPost]
[Route("Register")]
public async Task <IActionResult> Rigester([FromBody] AuthRigesterDto authRigesterDto){

        var identityUser = new IdentityUser()
        {
            UserName=authRigesterDto.username,
            Email=authRigesterDto.Email

        };

       var identityResult=await userManager.CreateAsync(identityUser,authRigesterDto.Password);

       if(identityResult.Succeeded){
               if(authRigesterDto.Roles!=null && authRigesterDto.Roles.Any() )
               identityResult = await userManager.AddToRolesAsync(identityUser, authRigesterDto.Roles);
            if (identityResult.Succeeded)
                return Ok("user was register!please login");
       }


        return BadRequest("Something went wrong");


}

[HttpPost]
[Route("Login")]
public async Task <IActionResult> Login([FromBody] LoginRequestDto login){
            //get user by email
      var user= await userManager.FindByEmailAsync(login.Email);
          //check user is exist
          if(user!=null){
            //chek if password is correct
         var CheckPasswordResult=  await userManager.CheckPasswordAsync(user, login.Password);

            if (CheckPasswordResult){
                var role = await userManager.GetRolesAsync(user);
               if(role!=null)
               {
                    //create token (JWT)
                    var jwsToken = tokenService.GenerateToken(user, role.ToList());

                    var response = new LoginResponseDto()
                    {
                        JwtToken = jwsToken
                    };


                return Ok(response);
               }

                 
            }


          }

        return BadRequest("Email or Password incorrrect");
          

}

}