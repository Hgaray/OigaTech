using OigaTech.DataAccess.Repositories;
using OigaTech.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OigaTech.BusinessRules
{
    public class UserBusinessRules : IUserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Add(UserDto user)
        {
            try
            {
                if (!_userRepository.ValidateUserName(user.UserName))
                {
                    return await _userRepository.Add(user);
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return users.OrderBy(x => x.FullName).ThenBy(x => x.UserName);
        }

        public async Task<IEnumerable<UserDto>> Search(string search)
        {
            var queryList = search.Split(" ");
            var userList = new List<UserDto>();
            var taskList = new List<Task<IEnumerable<UserDto>>>();
            foreach (var item in queryList)
            {
                taskList.Add(_userRepository.Search(item));
            }

            await Task.WhenAll(taskList);

            foreach (var item in taskList)
            {
                if (item.Result != null && item.Result.Any())
                {
                    userList.AddRange(item.Result);
                }

            }
            return userList.OrderBy(x => x.FullName).ThenBy(x => x.UserName);
        }
    }
}
