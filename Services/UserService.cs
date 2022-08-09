using OnlineBingoAPI.Contracts;
using OnlineBingoAPI.Models;
using OnlineBingoAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBingoAPI.Services
{
    public class UserService : IUserService
    {
        private UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Create(User newUser)
        {
            await _userRepository.Add(newUser);
        }

        public async Task Delete(User user)
        {
            await _userRepository.Delete(user);
        }

        public async Task<User> Get(Guid ReferenceId)
        {
            return await _userRepository.Get(ReferenceId);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task Update(User user)
        {
            await _userRepository.Update(user);
        }
    }
}
