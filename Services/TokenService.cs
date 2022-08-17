using Microsoft.IdentityModel.Tokens;
using OnlineBingoAPI.Contracts;
using OnlineBingoAPI.CustomException;
using OnlineBingoAPI.Models;
using OnlineBingoAPI.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBingoAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUserRepository _userRepository;
        public TokenService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<string> GetToken(UserLoginContract userLogin)
        {
            var user = await GetUser(userLogin);
            var token = GenerateToken(user);
            return token;
        }

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(TokenSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private async Task<User> GetUser(UserLoginContract userLogin)
        {
            var user = await _userRepository.Get(userLogin.Username, userLogin.Password);
            if (user == null)
                throw new NotFoundException("Username or Password is wrong");
            return user;
        }
    }
}
