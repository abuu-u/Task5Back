using Microsoft.AspNetCore.Mvc;
using Task5Back.Services;

namespace Task5Back.Controllers
{
    [ApiController]
    [Route("Task5/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Search(string search)
        {
            string[] response = _userService.Search(search);
            return Ok(response);
        }
    }
}