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

        public Task<IEnumerable<UserDto>> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
}
