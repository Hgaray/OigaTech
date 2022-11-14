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

        public async Task<UserPaginatedResponse> GetAll()
        {
            var result = await _userRepository.GetAll();
            result.PageIndex = 1;
            result = Page(result);

            return result;
        }

        public async Task<UserPaginatedResponse> Search(UserPaginatedRequest parameters)
        {
            var queryList = parameters.Search.Split(" ");
            var taskList = new List<Task<IEnumerable<UserDto>>>();
            var result = new UserPaginatedResponse() { Users = new List<UserDto>()};

            foreach (var item in queryList)
            {
                taskList.Add(_userRepository.Search(item));
            }

            await Task.WhenAll(taskList);

            foreach (var item in taskList)
            {
                if (item.Result != null && item.Result.Any())
                {
                    result.Users.AddRange(item.Result);
                }

            }
            result.PageIndex = parameters.PageIndex;
            result = Page(result);

            return result;
        }

        private UserPaginatedResponse Page(UserPaginatedResponse data)
        {

            data.Users = data.Users.OrderBy(x => x.FullName).ThenBy(x => x.UserName).ToList();
            data.TotalCount = data.Users.Count();            
            data.TotalPages = data.Users.Any() ? Math.Ceiling((decimal)data.Users.Count() / 10) : 0;
            int start = (data.PageIndex * 10)-10;
            data.Users = data.Users.Skip(start).Take(10).ToList();
            return data;
        }
    }
}
