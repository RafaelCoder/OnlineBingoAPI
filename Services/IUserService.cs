using OnlineBingoAPI.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBingoAPI.Services
{
    public interface IUserService
    {
        public Task<UserReadContract> Create(UserCreateContract newUser);
        public Task<UserReadContract> Get(Guid ReferenceId);
        public Task<IEnumerable<UserReadContract>> GetAll();
        public Task Update(UserUpdateContract user);
        public Task Delete(Guid id);
        public Task<UserReadContract> GetByName(string username);
    }
}
