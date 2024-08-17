using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = new [] { "Muhammed", "Mustafa", "AHMED" };
            return Json(new{data=students});
        }
    }
}
