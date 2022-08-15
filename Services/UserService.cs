using OnlineBingoAPI.Contracts;
using OnlineBingoAPI.Models;
using OnlineBingoAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using System.Linq;
using OnlineBingoAPI.CustomException;

namespace OnlineBingoAPI.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserReadContract> Create(UserCreateContract newUser)
        {
            if (!(await GetByName(newUser.Username) is null))
                throw new BusinessRuleException("Username already exists");

            var user = newUser.Adapt<User>();
            await _userRepository.Add(user);
            return user.Adapt<UserReadContract>();
        }

        public async Task Delete(Guid id)
        {
            var user = await _userRepository.Get(id);
            if (user == null)
                throw new NotFoundException();
            await _userRepository.Delete(id);
        }

        public async Task<UserReadContract> Get(Guid id)
        {
            var user = await _userRepository.Get(id);
            if (user == null)
                throw new NotFoundException();
            return user.Adapt<UserReadContract>();
        }

        public async Task<IEnumerable<UserReadContract>> GetAll()
        {
            var users = await _userRepository.GetAll();
            if(users == null)
                throw new NotFoundException();
            var usersReturn = users.Select(u => u.Adapt<UserReadContract>()).ToList();
            return usersReturn;
        }

        public async Task<UserReadContract> GetByName(string username)
        {
            var user = await _userRepository.GetByName(username);
            return user.Adapt<UserReadContract>();
        }

        public async Task Update(UserUpdateContract user)
        {
            var exists = await _userRepository.Get(user.Id);
            if (exists == null)
                throw new NotFoundException("User not found");
            var usr = user.Adapt<User>();
            await _userRepository.Update(usr);
        }
    }
}
