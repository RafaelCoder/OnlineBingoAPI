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
            if (users == null)
                return NotFound();
            return Ok(users);
        }

        [HttpGet("{id}", Name = "UserDatails")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _userService.Get(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateContract newUser)
        {
            try
            {
                var user = await _userService.Create(newUser);
                return CreatedAtRoute("UserDatails", new { Id = user.ReferenceId }, user.Adapt<UserReadContract>());
            }
            catch (BusinesRuleException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> EditUser(Guid id)
        {
            //await _userService.Update();
            return Ok();
        }
    }
}
