using OnlineBingoAPI.Contracts;
using System.Threading.Tasks;

namespace OnlineBingoAPI.Services
{
    public interface ITokenService
    {
        public Task<string> GetToken(UserLoginContract userLogin);
    }
}
