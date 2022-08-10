using Microsoft.AspNetCore.Mvc;
using OnlineBingoAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using OnlineBingoAPI.Services;
using OnlineBingoAPI.Contracts;
using System.Linq;
using System;

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
            if(users == null)
                return NotFound();
            var usersReturn = users.Select(u => u.Adapt<UserReadContract>()).ToList();

            return Ok(usersReturn);
        }

        [HttpGet("{id}", Name = "UserDatails")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _userService.Get(id);
            if (user == null)
                return NotFound();
            return Ok(user.Adapt<UserReadContract>());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateContract newUser)
        {
            try
            {
                if(!(await _userService.GetByName(newUser.Username) is null))
                    return StatusCode(409, "Já existe um usuário com este nome");

                var user = newUser.Adapt<User>();
                await _userService.Create(user);
                return CreatedAtRoute("UserDatails", new { Id = user.ReferenceId }, user.Adapt<UserReadContract>());
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
