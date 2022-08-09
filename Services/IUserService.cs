using OnlineBingoAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBingoAPI.Services
{
    public interface IUserService
    {
        public Task Create(User newUser);
        public Task<User> Get(Guid ReferenceId);
        public Task<IEnumerable<User>> GetAll();
        public Task Update(User user);
        public Task Delete(User user);
    }
}
