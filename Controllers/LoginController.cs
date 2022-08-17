using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBingoAPI.Contracts;
using OnlineBingoAPI.Services;
using System;
using System.Threading.Tasks;

namespace OnlineBingoAPI.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : DefaultController
    {
        private readonly ITokenService _tokenService;
        public LoginController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginContract login)
        {
            return await ExecuteCall(async () => { 
                var token = _tokenService.GetToken(login);
                return Ok(new
                {
                    token = token
                });
            });
        }
    }
}
