using Microsoft.AspNetCore.Mvc;
using OnlineBingoAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using OnlineBingoAPI.Services;
using OnlineBingoAPI.Contracts;
using System.Linq;
using System;
using OnlineBingoAPI.CustomException;

namespace OnlineBingoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : DefaultController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return await ExecuteCall(async () =>
            {
                var users = await _userService.GetAll();
                return Ok(users);
            });
        }

        [HttpGet("{id}", Name = "UserDatails")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            return await ExecuteCall(async () =>
            {
                var user = await _userService.Get(id);
                return Ok(user);
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateContract newUser)
        {
            return await ExecuteCall( async () =>
            {
                var user = await _userService.Create(newUser);
                return CreatedAtRoute("UserDatails", new { Id = user.Id }, user);
            });
        }

        [HttpPut]
        public async Task<IActionResult> EditUser([FromBody] UserUpdateContract user)
        {
            return await ExecuteCall(async () =>
            {
                await _userService.Update(user);
                return NoContent();
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            return await ExecuteCall(async () =>
            {
                await _userService.Delete(id);
                return NoContent();
            });
        }
    }
}
