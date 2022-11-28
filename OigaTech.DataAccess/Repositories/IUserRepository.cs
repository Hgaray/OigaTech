using OigaTech.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OigaTech.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<bool> Add(UserDto user);
        bool ValidateUserName(string userName);
        Task<UserPaginatedResponse> GetAll();
        Task<List<UserDto>> Search(string search);
    }
}
