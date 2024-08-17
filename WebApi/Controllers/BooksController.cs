using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BooksController:Controller{
     [HttpGet]
    public IActionResult GetAllBook(){
        var booksName = new [] { "c++", "java", "c" };

        var  allowedExtension =new string[]{
             
        };
 
        return Ok(booksName);
    }

}