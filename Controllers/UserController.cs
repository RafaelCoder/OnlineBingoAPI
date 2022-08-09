using Microsoft.AspNetCore.Mvc;
using OnlineBingoAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using OnlineBingoAPI.Services;
using OnlineBingoAPI.Contracts;
using System.Linq;

namespace OnlineBingoAPI.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAll();
            var usersReturn = users.Select(u => u.Adapt<UserReadContract>()).ToList();

            return Ok(usersReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateContract newUser)
        {
            var user = newUser.Adapt<User>();
            await _userService.Create(user);
            return Ok();
        }
    }
}
